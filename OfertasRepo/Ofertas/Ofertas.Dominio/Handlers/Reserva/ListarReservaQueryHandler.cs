using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Reserva;
using Ofertas.Dominio.Repositorios;
using System.Linq;

namespace Ofertas.Dominio.Handlers.Comentarios
{
    public class ListarReservaQueryHandler : IHandlerQuery<ListarReservasQuery>
    {
        private readonly IReservaRepositorio _reservaRepositorio;

        public ListarReservaQueryHandler(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        public IQueryResult Handle(ListarReservasQuery query)
        {
            var reserva = _reservaRepositorio.Listar();

            var retornoReservas = reserva.Select(
                x =>
                {
                    return new ListarReservasQueryResult()
                    {
                        IdReserva = x.IdReserva,
                        IdOferta = x.IdOferta,
                        IdUsuario = x.IdUsuario,
                        QuantidadeReserva = x.QuantidadeReserva
                    };
                }
            );

            return new GenericQueryResult(true, "Reservas:", retornoReservas);
        }
    }
}
