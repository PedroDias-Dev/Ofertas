using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Pacote;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;

namespace Ofertas.Dominio.Handlers.Pacotes
{
    public class AlterarOfertaCommandHandler : IHandlerCommand<AlterarOfertaCommand>
    {
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public AlterarOfertaCommandHandler(IOfertaRepositorio ofertaRepositorio)
        {
            _ofertaRepositorio = ofertaRepositorio;
        }

        public ICommandResult Handle(AlterarOfertaCommand command)
        {
            //Fail Test Validation
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            //verifica se a oferta existe
            var oferta = _ofertaRepositorio.BuscarPorId(command.IdOferta);

            if (oferta == null)
                return new GenericCommandResult(false, "Oferta não encontrada!", null);

            //Altera as propriedades da oferta
            oferta.AtualizarOferta(command.NomeProduto, command.Descricao, command.Preco, command.PrecoAntigo, command.DataValidade, command.EstoqueTotal, command.Categoria);

            _ofertaRepositorio.Alterar(oferta);

            //Msg de Sucesso
            return new GenericCommandResult(true, "Oferta Alterada com sucesso!", oferta);
        }
    }
}
