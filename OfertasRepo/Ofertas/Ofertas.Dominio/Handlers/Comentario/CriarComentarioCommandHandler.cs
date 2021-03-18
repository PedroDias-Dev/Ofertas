using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Utils;
using Ofertas.Dominio.Commands.Comentario;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Handlers.Comentarios
{
    public class CriarComentarioCommandHandler : IHandlerCommand<CriarComentarioCommand>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public CriarComentarioCommandHandler(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public ICommandResult Handle(CriarComentarioCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", command.Notifications);

            //Valida texto, verifica moderação
            var resultado = new ModeradorConteudo().Moderar(command.Texto);

            if (resultado != null)
            {
                var palavras = resultado.Select(
                    r =>
                    {
                        return new
                        {
                            palavra = r.Term
                        };
                    }
                ).ToArray();

                return new GenericCommandResult(false, "Este comentário fere nossas politicas", palavras);
            }

            var comentario = new Comentario(command.Texto, command.IdUsuario, command.IdOferta);

            if (comentario.Invalid)
                return new GenericCommandResult(true, "Dados inválidos!", comentario.Notifications);

            _comentarioRepositorio.Adicionar(comentario);

            return new GenericCommandResult(true, "Comentário criado!", comentario);

        }

    }
}
