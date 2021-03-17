using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Commands;
using System;

namespace Ofertas.Dominio.Commands.Oferta
{
    public class AlterarImagemOfertaCommand : Notifiable, ICommand
    {
        public  AlterarImagemOfertaCommand()
        {

        }
        
        public AlterarImagemOfertaCommand(Guid idOferta, string imagem )
        {
            IdOferta = idOferta;
            Imagem = imagem;
        }

        public Guid IdOferta { get; set; }
        public string Imagem { get; set; }


        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdOferta, Guid.Empty, "IdOferta", "Id do produto é inválido! (Package Error)")
               .IsNotNullOrEmpty(Imagem, "Imagem", "Informe a imagem do produto! (Package Error)")
               );
        }

        
    }
}
