using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Util;
using Ofertas.Dominio.Commands.Usuario;
using Ofertas.Dominio.Repositorios;

namespace Ofertas.Dominio.Handlers.Usuarios
{
    public class LoginCommandHandler : Notifiable, IHandlerCommand<LoginCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginCommandHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(LoginCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "E-mail inválido", null);

            if (!Senha.Validar(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida", null);

            return new GenericCommandResult(true, "Usuário Logado", usuario);
        }
    }
}
