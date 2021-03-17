using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Comentarios;
using Ofertas.Dominio.Queries.Ofertas;
using Ofertas.Dominio.Repositorios;
using System.Linq;
using static Ofertas.Dominio.Queries.Comentarios.BuscarComentariosPorIdQuery;
using static Ofertas.Dominio.Queries.Ofertas.BuscarOfertaPorIdQuery;

namespace Ofertas.Dominio.Handlers.Comentarios
{
    public class BuscarComentariosPorIdQueryHandler : IHandlerQuery<BuscarComentariosPorIdQuery>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;
        public BuscarComentariosPorIdQueryHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public IQueryResult Handle(BuscarComentariosPorIdQuery query)
        {
            var comentarioId = _comentarioRepositorio.BuscarPorId(query.IdOferta);

            var retornoComentarios = comentarioId.Select(
                x =>
                {
                    return new BuscarComentariosPorIdQueryResult()
                    {
                        Texto = x.Texto,
                        IdUsuario = x.IdUsuario,
                        IdOferta = x.IdOferta

                    };
                }
            );

                    return new GenericQueryResult(true, "Comentarios", retornoComentarios);
        }

    }
}
