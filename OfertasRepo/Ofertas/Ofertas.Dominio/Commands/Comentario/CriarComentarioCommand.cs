using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Commands.Comentario
{
    public class CriarComentarioCommand: Notifiable, ICommand
    {
        public CriarComentarioCommand(string texto, Guid idUsuario, Guid idOferta)
        {
            Texto = texto;
            IdUsuario = idUsuario;
            IdOferta = idOferta;
        }

        public string Texto { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdOferta { get; set; }


        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Texto, "Texto", "Informe o Texto desse comentário!")
            );
        }
    }
}
