using Microsoft.EntityFrameworkCore;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using Ofertas.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofertas.Infra.Data.Repositorios
{
    public class OfertaRepositorio : IOfertaRepositorio
    {
        private readonly OfertasContext _context;

        public OfertaRepositorio(OfertasContext context)
        {
            _context = context;
        }

        public void Adicionar(Oferta oferta)
        {
            _context.Ofertas.Add(oferta);
            _context.SaveChanges();
        }

        public void Alterar(Oferta oferta)
        {
            throw new NotImplementedException();
        }

        public Oferta BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Oferta BuscarPorTitulo(string nomeProduto)
        {
            return _context
                        .Ofertas
                        .AsNoTracking()
                        .FirstOrDefault(p => p.NomeProduto.ToLower() == nomeProduto.ToLower());
        }

        public IEnumerable<Oferta> Listar(bool? ativo = null)
        {
            if (ativo == null)
                return _context
                            .Ofertas
                            .AsNoTracking()
                            .OrderBy(x => x.DataCriacao);
            else
                return _context
                            .Ofertas
                            .AsNoTracking()
                            .Where(x => x.Ativo == ativo)
                            .OrderBy(x => x.DataCriacao);
        }
    }
}
