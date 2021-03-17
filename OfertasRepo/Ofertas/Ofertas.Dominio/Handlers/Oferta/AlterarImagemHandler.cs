using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Handlers.Oferta
{
    public class AlterarImagemHandler : IHandlerCommand<AlterarImagemOfertaCommand>
    {
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public AlterarImagemHandler(IOfertaRepositorio ofertaRepositorio)
        {
            _ofertaRepositorio = ofertaRepositorio;
        }

        public ICommandResult Handle(AlterarImagemOfertaCommand command)
        {
            //Fail Test Validation
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var oferta = _ofertaRepositorio.BuscarPorId(command.IdOferta);

            if (oferta == null)
                return new GenericCommandResult(false, "Pacote não encontrado", null);

            oferta.AtualizarImagem(command.Imagem);

            if (oferta.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", oferta.Notifications);


            _ofertaRepositorio.Alterar(oferta);

            //Msg de Sucesso
            return new GenericCommandResult(true, "Imagem da oferta alterada com sucesso!", oferta.Notifications);
        }
    }
}
