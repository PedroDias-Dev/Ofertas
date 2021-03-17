using Ofertas.Comum.Commands;
using Ofertas.Dominio.Commands.Pacote;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;

namespace Ofertas.Dominio.Handlers.Pacotes
{
    public class AlterarOfertaCommandHandler
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
            var pacote = _ofertaRepositorio.BuscarPorId(command.IdOferta);

            if (pacote == null)
                return new GenericCommandResult(false, "Oferta não encontrada!", null);

            //Altera as propriedades da oferta
            var oferta = new Oferta(command.NomeProduto, command.Descricao, command.Imagem, command.Ativo, command.IdOferta, command.Preco, command.PrecoAntigo, command.DataValidade, command.DisponivelDoacao, command.EstoqueTotal, command.Categoria);

            _ofertaRepositorio.Alterar(oferta);

            //Msg de Sucesso
            return new GenericCommandResult(true, "Oferta Alterada com sucesso!", oferta);
        }
    }
}
