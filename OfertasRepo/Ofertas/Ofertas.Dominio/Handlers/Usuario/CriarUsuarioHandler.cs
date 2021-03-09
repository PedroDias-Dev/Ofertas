using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Util;
using Ofertas.Dominio.Commands.Usuario;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;

namespace Ofertas.Dominio.Handlers.Usuarios
{
    public class CriarUsuarioHandler : Notifiable, IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CriarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handle(CriarContaCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Informe corretamente os dados do usuário!", command.Notifications);

            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if (usuarioExiste != null)
                return new GenericCommandResult(false, "E-mail já cadastrado no sistema, informe outro e-mail!", null);

            command.Senha = Senha.Criptografar(command.Senha);

            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);

            //if (!string.IsNullOrEmpty(command.Telefone))
              //  usuario.AlterarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Dados de usuário inválidos!", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);

            //EMAIL DE BOAS VINDAS ---- SENDGRID

            return new GenericCommandResult(true, "Usuário Criado com sucesso!", usuario);
        }
    }
}
