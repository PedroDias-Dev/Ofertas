using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Comentario;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using System.Linq;

namespace Ofertas.Dominio.Handlers.Comentarios
{
    public class CriarReservaCommandHandler : Notifiable, IHandlerCommand<CriarReservaCommand>
    {
        private readonly IReservaRepositorio _reservaRepositorio;

        public CriarReservaCommandHandler(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
        }

        public ICommandResult Handle(CriarReservaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            var reservaDisponivel = _reservaRepositorio.VerificarDisponibilidade(command.QuantidadeReserva);

            if (reservaDisponivel != null)
                return new GenericCommandResult(true, "Estoque Insuficiente", null);

            var reserva = new Reserva(command.IdOferta, command.IdUsuario, command.QuantidadeReserva);

            if (reserva.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", reserva.Notifications);

            _reservaRepositorio.Adicionar(reserva);

            return new GenericCommandResult(true, "Reserva efetuada!", reserva);

        }
    }
}
