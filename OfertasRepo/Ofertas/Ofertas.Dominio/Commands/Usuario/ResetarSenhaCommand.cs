using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;

namespace Ofertas.Dominio.Commands.Usuario
{
    public class ResetarSenhaCommand : Notifiable, ICommand
    {
        public string Email { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um e-mail válido!")
            );
        }
    }
}
