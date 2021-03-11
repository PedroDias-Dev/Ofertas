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

        //TO DO: Validar Tabelas em conjunto
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    
        //Modelagem de Tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            //TO DO: Mapear Tabela Usuario
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

            //TO DO: Mapear Tabela Ofertas
            #region Mapeamento Tabela Ofertas
            modelBuilder.Entity<Oferta>().ToTable("Ofertas");
            //Defini como chave primaria
            modelBuilder.Entity<Oferta>().Property(x => x.Id);
            //Nome Produto
            modelBuilder.Entity<Oferta>().Property(x => x.NomeProduto).HasMaxLength(50);
            modelBuilder.Entity<Oferta>().Property(x => x.NomeProduto).HasColumnType("varchar(50)");
            modelBuilder.Entity<Oferta>().Property(x => x.NomeProduto).IsRequired();
            //Descrição
            modelBuilder.Entity<Oferta>().Property(x => x.Descricao).HasColumnType("Text");
            modelBuilder.Entity<Oferta>().Property(x => x.Descricao).IsRequired();
            //Imagem
            modelBuilder.Entity<Oferta>().Property(x => x.Imagem).HasMaxLength(250);
            modelBuilder.Entity<Oferta>().Property(x => x.Imagem).HasColumnType("varchar(250)");
            modelBuilder.Entity<Oferta>().Property(x => x.Imagem).IsRequired();
            //Ativo
            modelBuilder.Entity<Oferta>().Property(x => x.Ativo).HasColumnType("bit");
            //IdUsuario - TipoEmpresa
            //Preço
            modelBuilder.Entity<Oferta>().Property(x => x.Preco).HasColumnType("float");
            modelBuilder.Entity<Oferta>().Property(x => x.Preco).IsRequired();
            //Preço Antigo
            modelBuilder.Entity<Oferta>().Property(x => x.PrecoAntigo).HasColumnType("float");
            modelBuilder.Entity<Oferta>().Property(x => x.PrecoAntigo).IsRequired();
            //Data de Validade
            modelBuilder.Entity<Oferta>().Property(t => t.DataValidade).HasColumnType("Date");
            modelBuilder.Entity<Oferta>().Property(t => t.DataValidade).HasDefaultValueSql("GetDate()");
            //Disponível para Doação
            modelBuilder.Entity<Oferta>().Property(x => x.DisponivelDoacao).HasColumnType("bit");
            //Estoque Total
            modelBuilder.Entity<Oferta>().Property(x => x.EstoqueTotal).HasColumnType("int");
            modelBuilder.Entity<Oferta>().Property(x => x.EstoqueTotal).IsRequired();
            //Tipo Categoria
            modelBuilder.Entity<Oferta>().Property(x => x.Categoria).HasColumnType("int");
            modelBuilder.Entity<Oferta>().Property(x => x.Categoria).IsRequired();
            //Relacionamento
            //Extra //modelBuilder.Entity<Oferta>().HasMany(c => c.Comentarios).WithOne(e => e.Pacote).HasForeignKey(x => x.IdPacote)
            ////DataCriacao
            modelBuilder.Entity<Oferta>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Oferta>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");
            //DataAlteracao     
            modelBuilder.Entity<Oferta>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Oferta>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            //TO DO: Mapear Tabela Reservas
            #region Mapeamento Tabela Reservas
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
