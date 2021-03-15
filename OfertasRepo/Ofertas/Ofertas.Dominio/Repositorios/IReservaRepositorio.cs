
using Ofertas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Repositorios
{
    public interface IReservaRepositorio
    {
        void Adicionar(Reserva reserva);
        void Alterar(Reserva reserva);

        //Reserva VerificarDisponibilidade(int quantidade, Guid idOferta);

        IEnumerable<Reserva> Listar();

    }
}
