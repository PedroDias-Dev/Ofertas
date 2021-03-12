using Ofertas.Comum.Commands;
using Ofertas.Comum.Enum;
using Ofertas.Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ofertas.Dominio.Commands.Reserva
{
    public class CriarReservaCommand : Notifiable, ICommand
    {
        public CriarReservaCommand(Guid idUsuario, Guid idOferta, int quantidadeReserva)
        {
            IdUsuario = idUsuario;
            IdOferta = idOferta;
            QuantidadeReserva = quantidadeReserva;
        }

        //public Guid IdReserva { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdOferta { get; set; }
        public int QuantidadeReserva { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                //.IsNotNullOrEmpty(QuantidadeReserva.ToString, "QuantidadeReserva", "Informe a quantidade!")
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário!")
                .AreNotEquals(IdOferta, Guid.Empty, "IdPacote", "Informe o Id da Reserva!")
            );
        }
    }
}
