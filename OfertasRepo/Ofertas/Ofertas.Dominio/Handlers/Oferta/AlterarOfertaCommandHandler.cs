using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
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
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            //var pacoteexiste = _pacoteRepositorio.BuscarPorId(command.Id);
            //if (pacoteexiste != null)
                //return new GenericCommandResult(false, "Este Pacote não existe!", null);

            var oferta = new Oferta(command.NomeProduto, command.Descricao, command.Imagem, command.Ativo, command.IdUsuario, command.Preco, command.PrecoAntigo, command.DataValidade, command.DisponivelDoacao, command.EstoqueTotal, command.Categoria);

            _ofertaRepositorio.Alterar(oferta);

            return new GenericCommandResult(true, "Oferta Alterada!", oferta);
        }
    }
}
