using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Reserva;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using System.Linq;

namespace Ofertas.Dominio.Handlers.Reservas
{
    public class CriarReservaCommandHandler : Notifiable, IHandlerCommand<CriarReservaCommand>
    {
        private readonly IReservaRepositorio _reservaRepositorio;
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public CriarReservaCommandHandler(IReservaRepositorio reservaRepositorio, IOfertaRepositorio ofertaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
            _ofertaRepositorio = ofertaRepositorio;
        }

        public ICommandResult Handle(CriarReservaCommand command)
        {
            //Validacao Básica
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            //Validacao do Valor da Reserva
            if (command.QuantidadeReserva < 0)
                return new GenericCommandResult(true, "A quantidade da reserva deve ser maior que 0!", command.Notifications);

            //Verifica se a Oferta Existe
            var oferta = _ofertaRepositorio.BuscarPorId(command.IdOferta);
            if (oferta == null)
                return new GenericCommandResult(true, "Informe uma Oferta válida!", command.Notifications);

            //Verifica se há estoque disponivel para reserva
            var estoqueDisponivel = oferta.EstoqueTotal;

            if (command.QuantidadeReserva > estoqueDisponivel)
                return new GenericCommandResult(true, "Estoque Insuficiente!", command.Notifications);

            var reserva = new Reserva(command.IdUsuario, command.IdOferta, command.QuantidadeReserva);

            if (reserva.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", reserva.Notifications);

            _reservaRepositorio.Adicionar(reserva);

            //Realiza alteração no Estoque da Oferta
            oferta.EstoqueTotal = estoqueDisponivel - command.QuantidadeReserva;
            if (oferta.EstoqueTotal == 0)
                oferta.Ativo = false;

            _ofertaRepositorio.Alterar(oferta);



            return new GenericCommandResult(true, "Reserva efetuada!", oferta);

        }
    }
}

//var reservaDisponivel = _reservaRepositorio.VerificarDisponibilidade(command.QuantidadeReserva, command.IdOferta);
//if (reservaDisponivel != null)
//return new GenericCommandResult(true, "Estoque Insuficiente", null);
