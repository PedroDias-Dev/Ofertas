using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Commands.Oferta
{
    public class AlterarStatusDoacaoOfertaCommand: Notifiable, ICommand
    {
        public AlterarStatusDoacaoOfertaCommand(Guid idOferta, bool disponivelDoacao)
        {
            IdOferta = idOferta;
            DisponivelDoacao = disponivelDoacao;
        }

        public Guid IdOferta { get; set; }
        public bool DisponivelDoacao { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdOferta, Guid.Empty, "IdPacote", "Informe o Id da Reserva!")
            );
        }
    }
}
