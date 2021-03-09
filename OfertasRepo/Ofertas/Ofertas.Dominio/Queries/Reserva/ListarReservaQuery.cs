using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Entidades;
using System;

namespace Ofertas.Dominio.Queries.Reserva
{
    public class ListarReservasQuery : IQuery
    {
        public void Validar()
        {

        }
    }

    public class ListarReservasQueryResult
    {
        public Guid IdReserva { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdOferta { get; set; }
        public int QuantidadeReserva { get; set; }
    }
}
