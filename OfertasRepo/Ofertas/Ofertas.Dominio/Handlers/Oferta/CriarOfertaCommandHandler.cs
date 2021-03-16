using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Dominio.Commands.Oferta;
using Ofertas.Dominio.Commands.Pacote;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;

namespace Ofertas.Dominio.Handlers.Ofertas
{
    public class CriarOfertaCommandHandler : IHandlerCommand<CriarOfertaCommand>
    {
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public CriarOfertaCommandHandler(IOfertaRepositorio ofertaRepositorio)
        {
            _ofertaRepositorio = ofertaRepositorio;
        }

        public ICommandResult Handle(CriarOfertaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            if (command.EstoqueTotal < 10)
                return new GenericCommandResult(true, "A quantidade de estoque deve ser maior que 10!", command.Notifications);

            //var ofertaexiste = _ofertaRepositorio.BuscarPorTitulo(command.NomeProduto);

            //if (ofertaexiste != null)
            //    return new GenericCommandResult(true, "Titulo da oferta já cadastrado!", null);

            var oferta = new Entidades.Oferta(command.NomeProduto, command.Descricao, command.Imagem, command.Ativo, command.IdUsuario, command.Preco, command.PrecoAntigo, command.DataValidade, command.DisponivelDoacao, command.EstoqueTotal, command.Categoria);

            if (oferta.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", oferta.Notifications);

            _ofertaRepositorio.Adicionar(oferta);

            return new GenericCommandResult(true, "Oferta criada!", oferta);

        }
    }
}
