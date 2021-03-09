using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ofertas.Dominio.Commands.Comentario
{
    //TESTE
    public class AlterarReservaCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; private set; }
        public Guid IdOferta { get; private set; }
        public int QuantidadeReserva { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                //.(QuantidadeReserva, "QuantidadeReserva", "Informe a Quantidade!")
            );
        }
    }
}
