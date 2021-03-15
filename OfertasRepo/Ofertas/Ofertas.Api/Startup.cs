using CodeTur.Infra.Data.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ofertas.Dominio.Handlers.Ofertas;
using Ofertas.Dominio.Handlers.Pacotes;
using Ofertas.Dominio.Handlers.Reservas;
using Ofertas.Dominio.Handlers.Usuarios;
using Ofertas.Dominio.Repositorios;
using Ofertas.Infra.Data.Contexts;
using Ofertas.Infra.Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Correção do erro object cycle
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //Remover propriedades nulas
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            //Conexão
            //TO DO: Gerenciar strings de conexão

            services.AddDbContext<OfertasContext>(o => o.UseSqlServer("Data Source=DESKTOP-AUB5PDB\\SQLEXPRESS;Initial Catalog=Ofertas;user id=sa;password=sa132"));   //STRING PEDRO
            //services.AddDbContext<OfertasContext>(o => o.UseSqlServer("Data Source=DESKTOP-DA6MBAT\\SQLEXPRESS;Initial Catalog=Partilhado;user id=sa;password=ps132"));



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Partilhado", Version = "V1" });
            });

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "partilhado",
                        ValidAudience = "partilhado",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaPartilhadoApi"))
                    };
                });

            //TO DO: Injeção de Dependência 
            #region Injeção Dependência Usuário
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<CriarUsuarioHandler, CriarUsuarioHandler>();
            services.AddTransient<LoginCommandHandler, LoginCommandHandler>();

            #endregion

            #region Injeção Dependência Oferta
            services.AddTransient<IOfertaRepositorio, OfertaRepositorio>();
            services.AddTransient<CriarOfertaCommandHandler, CriarOfertaCommandHandler>();
            services.AddTransient<ListarOfertaQueryHandle, ListarOfertaQueryHandle>();

            #endregion

            #region Injeção Dependência Reserva
            services.AddTransient<IReservaRepositorio, ReservaRepositorio>();
            services.AddTransient<CriarReservaCommandHandler, CriarReservaCommandHandler>();
            services.AddTransient<ListarReservaQueryHandler, ListarReservaQueryHandler>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Partilhado V1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
