using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.Ofertas
{
    public class BuscarOfertaPorIdQuery : Notifiable, IQuery
    {
        public BuscarOfertaPorIdQuery()
        {
        }

        public BuscarOfertaPorIdQuery(Guid idOferta, EnTipoUsuario tipoUsuario)
        {
            IdOferta = idOferta;
            TipoUsuario = tipoUsuario;
        }

        public Guid IdOferta { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdOferta, Guid.Empty, "IdOferta", "Informe o Id da Oferta")
            );
        }

        public class BuscarOfertaPorIdQueryResult
        {
            public Guid Id { get; set; }
            public string NomeProduto { get; set; }
            public string Descricao { get; set; }
            public string Imagem { get; set; }
            public bool Ativo { get; set; }
            public Guid IdUsuario { get; set; }//empresa : comerciante ou varejista
            public float Preco { get; set; }// em R$ e p/unidade
            public float PrecoAntigo { get; set; }// em R$ e p/unidade
            public DateTime DataValidade { get; set; }
            public bool DisponivelDoacao { get; set; }
            public int EstoqueTotal { get; set; }
            public EnTipoCategoria Categoria { get; set; }
        }


    }
}
