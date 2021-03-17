using Flunt.Validations;
using Ofertas.Comum.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Entidades
{
    public class Comentario: Entidade
    {
        public Comentario(string texto, Guid idUsuario, Guid idOferta)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(texto, "Texto", "Informe o Texto do comentário!")
                .AreNotEquals(idUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário!")
                .AreNotEquals(idOferta, Guid.Empty, "IdPacote", "Informe o Id do Pacote do comentário!")
            );

            if (Valid)
            {
                Texto = texto;
                IdUsuario = idUsuario;
                IdOferta = idOferta;
            }
        }

        public string Texto { get; private set; }
        public Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid IdOferta { get; private set; }
        public virtual Oferta Oferta { get; private set; }
    }
}
