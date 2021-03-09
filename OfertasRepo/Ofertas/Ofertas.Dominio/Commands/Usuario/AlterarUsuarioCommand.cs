using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using System;

namespace Ofertas.Dominio.Commands.Usuario
{
    public class AlterarUsuarioCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres!")
                .HasMaxLen(Nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres!")
                .IsEmail(Email, "Email", "Informe um e-mail válido!")
            );
        }
    }
}
