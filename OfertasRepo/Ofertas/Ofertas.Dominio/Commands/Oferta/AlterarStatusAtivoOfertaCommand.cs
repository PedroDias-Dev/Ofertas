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
    public class AlterarStatusAtivoOfertaCommand: Notifiable, ICommand
    {
        public AlterarStatusAtivoOfertaCommand(Guid idOferta, bool ativo)
        {
            IdOferta = idOferta;
            Ativo = ativo;
        }

        public Guid IdOferta { get; set; }
        public bool Ativo { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdOferta, Guid.Empty, "IdPacote", "Informe o Id da Reserva!")
            );
        }
    }
}
