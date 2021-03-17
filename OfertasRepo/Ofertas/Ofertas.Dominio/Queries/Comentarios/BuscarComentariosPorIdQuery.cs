using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.Comentarios
{
    public class BuscarComentariosPorIdQuery : Notifiable, IQuery
    {
        public BuscarComentariosPorIdQuery()
        {
        }

        public BuscarComentariosPorIdQuery(Guid idOferta)
        {
            IdOferta = idOferta;
        }

        public Guid IdOferta { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdOferta, Guid.Empty, "IdOferta", "Informe o Id da Oferta")
            );
        }

        public class BuscarComentariosPorIdQueryResult
        {
            public string Texto { get; set; }
            public Guid IdOferta { get; set; }
            public Guid IdUsuario { get; set; }
        }


    }
}
