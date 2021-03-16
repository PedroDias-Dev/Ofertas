using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Handlers.Ofertas
{
    public class AlterarStatusDoacaoOfertaCommandHandler : IHandlerCommand<AlterarStatusDoacaoOfertaCommand>
    {
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public AlterarStatusDoacaoOfertaCommandHandler(IOfertaRepositorio ofertaRepositorio)
        {
            _ofertaRepositorio = ofertaRepositorio;
        }

        public ICommandResult Handle(AlterarStatusDoacaoOfertaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            var oferta = _ofertaRepositorio.BuscarPorId(command.IdOferta);
            if (oferta == null)
                return new GenericCommandResult(true, "Informe uma Oferta válida!", command.Notifications);

            if (command.DisponivelDoacao == true)
                oferta.AtivarDisponivelDoacao();
            else
                oferta.DesativarDisponivelDoacao();

            _ofertaRepositorio.Alterar(oferta);

            return new GenericCommandResult(true, "Status Alterado!", oferta);
        }
    }
}
