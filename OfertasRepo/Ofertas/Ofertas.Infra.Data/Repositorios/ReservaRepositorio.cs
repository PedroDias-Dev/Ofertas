using Microsoft.EntityFrameworkCore;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using Ofertas.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofertas.Infra.Data.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly OfertasContext _context;
        private readonly IOfertaRepositorio _ofertaRepositorio;

        public ReservaRepositorio(OfertasContext context, IOfertaRepositorio ofertaRepositorio)
        {
            _context = context;
            _ofertaRepositorio = ofertaRepositorio;
        }

        public void Adicionar(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }

        public void Alterar(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserva> Listar()
        {
             return _context
                         .Reservas
                         .AsNoTracking()
                         .OrderBy(x => x.DataCriacao);
        }

        //public Reserva VerificarDisponibilidade(int quantidade, Guid idOferta)
        //{
            
        //}
    }
}
