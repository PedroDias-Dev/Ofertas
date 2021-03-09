using Ofertas.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Ofertas.Dominio.Commands.Usuario
{
    public class AlterarSenhaCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }
        public string Senha { get; private set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe um Id de usuário válido!")
                .IsEmail(Senha, "Email", "Informe um e-mail válido!")
            );
        }
    }
}
