using Ofertas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Flunt.Notifications;

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
            modelBuilder.Ignore<Notification>();

            //TO DO:
            #region Mapeamento Tabela Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            //Chave Primaria
            modelBuilder.Entity<Usuario>().Property(x => x.Id);
            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();
            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();
            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
            //Tipo Usuario
            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).HasColumnType("int");
            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).IsRequired();
            //Telefone
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(11)");
            //Datas
            modelBuilder.Entity<Usuario>().Property(u => u.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(u => u.DataAlteracao).HasColumnType("DateTime");
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
