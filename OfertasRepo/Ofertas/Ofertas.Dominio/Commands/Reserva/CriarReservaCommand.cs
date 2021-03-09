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
    public class CriarReservaCommand : Notifiable, ICommand
    {
        public CriarReservaCommand(Guid idUsuario, Guid idOferta, int quantidadeReserva)
        {
            IdUsuario = idUsuario;
            IdOferta = idOferta;
            QuantidadeReserva = quantidadeReserva;
        }

        public Guid IdReserva { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdOferta { get; private set; }
        public int QuantidadeReserva { get; private set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Texto, "Texto", "Informe o Texto do comentário!")
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário!")
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "Informe o Id do Pacote!")
            );
        }
    }
}
