using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Oferta;
using Ofertas.Dominio.Repositorios;
using System.Linq;

namespace Ofertas.Dominio.Handlers.Pacotes
{
    public class ListarOfertaQueryHandle : IHandlerQuery<ListarOfertaQuery>
    {
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public ListarOfertaQueryHandle(IOfertaRepositorio ofertaRepositorio)
        {
            _ofertaRepositorio = ofertaRepositorio;
        }

        public IQueryResult Handle(ListarOfertaQuery query)
        {
            var ofertas = _ofertaRepositorio.Listar(query.Ativo);

            var retornoOfertas = ofertas.Select(
                x =>
                {
                    return new ListarOfertaQueryResult()
                    {
                        IdOferta = x.Id,
                        NomeProduto = x.NomeProduto,
                        Descricao = x.Descricao,
                        Ativo = x.Ativo,
                        Imagem = x.Imagem,
                        DataValidade = x.DataValidade,
                        PrecoAntigo = x.PrecoAntigo,
                        Preco = x.Preco,
                        Categoria = x.Categoria,
                        DisponivelDoacao = x.DisponivelDoacao,
                        EstoqueTotal = x.EstoqueTotal,
                        IdUsuario = x.IdUsuario
                    };
                }
            );

            return new GenericQueryResult(true, "Ofertas:", retornoOfertas);
        }
    }
}
