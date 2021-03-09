using Ofertas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Ofertas.Infra.Data.Contexts
{

    //Fluent API
    public class OfertasContext : DbContext
    {

        public OfertasContext(DbContextOptions<OfertasContext> options) : base(options)
        {

        }

        //TO DO:
        //Validar Tabelas em conjunto
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    
        //Modelagem de Tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<Notification>();

            //TO DO:
            #region Mapeamento Tabela Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuarios"); //Nome da tabela no SQL
            #endregion

            //TO DO:
            #region Mapeamento Tabela Ofertas
            #endregion

            //TO DO:
            #region Mapeamento Tabela Reservas
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
