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
    public class AlterarStatusAtivoOfertaCommandHandler : IHandlerCommand<AlterarStatusAtivoOfertaCommand>
    {
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public AlterarStatusAtivoOfertaCommandHandler(IOfertaRepositorio ofertaRepositorio)
        {
            _ofertaRepositorio = ofertaRepositorio;
        }

        public ICommandResult Handle(AlterarStatusAtivoOfertaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.IdOferta);

            var oferta = _ofertaRepositorio.BuscarPorId(command.IdOferta);
            if (oferta == null)
                return new GenericCommandResult(false, "Esta Oferta não existe!", command.IdOferta);

            if (command.Ativo == true)
                oferta.AtivarOferta();
            else
                oferta.DesativarOferta();

            _ofertaRepositorio.Alterar(oferta);

            return new GenericCommandResult(true, "Status Alterado!", oferta);
        }
    }
}
