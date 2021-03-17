using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Queries.Comentarios;
using Ofertas.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Handlers.Comentarios
{
    public class ListarComentariosQueryHandler : IHandlerQuery<ListarComentariosQuery>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public ListarComentariosQueryHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public IQueryResult Handle(ListarComentariosQuery query)
        {
            var comentarios = _comentarioRepositorio.Listar();

            var retornoComentarios = comentarios.Select(
                x =>
                {
                    return new ListarComentariosQueryResult()
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
