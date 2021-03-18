using Flunt.Notifications;
using Ofertas.Comum.Commands;
using Ofertas.Comum.Handlers.Contracts;
using Ofertas.Comum.Util;
using Ofertas.Comum.Utils;
using Ofertas.Dominio.Commands.Usuario;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

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

            //var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            //if (usuarioExiste != null)
              //  return new GenericCommandResult(false, "E-mail já cadastrado no sistema, informe outro e-mail!", null);

            //Verificação CNPJ ===> Caso não tenha, usuario é de tipo comum
            if (command.CNPJ == null || command.CNPJ == "" || command.CNPJ.Length < 14)
                command.CNPJ = "";
                command.TipoUsuario = Comum.Enum.EnTipoUsuario.Comum;

            command.Senha = Senha.Criptografar(command.Senha);

            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.Telefone, command.TipoUsuario);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Dados de usuário inválidos!", usuario.Notifications);

           
            _usuarioRepositorio.Adicionar(usuario);

            //Sendgrid.SendConfirmationEmailAsync(command.Email, command.Nome);

            Sendgrid.SendWelcomeEmailAsync(command.Email, command.Nome);

            return new GenericCommandResult(true, "Usuário Criado com sucesso!", usuario);
        }

    }
}
