using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Ofertas;
using Ofertas.Dominio.Repositorios;
using static Ofertas.Dominio.Queries.Ofertas.BuscarOfertaPorIdQuery;

namespace Ofertas.Dominio.Handlers.Oferta
{
    public class BuscarOfertaPorIdQueryHandler : IHandlerQuery<BuscarOfertaPorIdQuery>
    {
        private readonly IOfertaRepositorio _ofertaRepositorio;
        public BuscarOfertaPorIdQueryHandler(IOfertaRepositorio ofertaRepositorio)
        {
            _ofertaRepositorio = ofertaRepositorio;
        }

        public ICommandResult Handle(BuscarOfertaPorIdQuery query)
        {
            var ofertaId = _ofertaRepositorio.BuscarPorId(query.IdOferta);

            if (ofertaId == null)
                return new GenericCommandResult(false, "Oferta não encontrado", null);

            var retorno = new BuscarOfertaPorIdQueryResult()
            {
                Id = ofertaId.Id,
                NomeProduto = ofertaId.NomeProduto,
                Descricao = ofertaId.Descricao,
                Imagem = ofertaId.Imagem,
                Ativo = ofertaId.Ativo,
                IdUsuario = ofertaId.IdUsuario,
                Preco = ofertaId.Preco,
                PrecoAntigo = ofertaId.PrecoAntigo,
                DataValidade = ofertaId.DataValidade,
                DisponivelDoacao = ofertaId.DisponivelDoacao,
                EstoqueTotal = ofertaId.EstoqueTotal,
                Categoria = ofertaId.Categoria
            };

            return new GenericCommandResult(true, "Dados do pacote", retorno);
        }

        IQueryResult IHandlerQuery<BuscarOfertaPorIdQuery>.Handle(BuscarOfertaPorIdQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
