using Ofertas.Comum.Entidades;
using Ofertas.Comum.Enum;
using System;
using Flunt.Validations;

namespace Ofertas.Dominio.Entidades
{
    public class Reserva : Entidade
    {
        /// <summary>
        /// Construtor padrão para solicitar reserva do produto
        /// </summary>
        /// <param name="idUsuario">Id consumidor interessado</param>
        /// <param name="usuario"></param>
        /// <param name="idOferta">Id da oferta</param>
        /// <param name="oferta"></param>
        /// <param name="quantidadeReserva">Quantidade de produtos reservados na oferta</param>
        public Reserva(Guid idUsuario, Guid idOferta, int quantidadeReserva)
        {
            IdUsuario = idUsuario;
            IdOferta = idOferta;
            QuantidadeReserva = quantidadeReserva;
        }

        public Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid IdOferta { get; private set; }
        public virtual Oferta Oferta { get; private set; }
        public int QuantidadeReserva { get; private set; }
    }
}
