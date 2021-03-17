using Microsoft.EntityFrameworkCore;
using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using Ofertas.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Infra.Data.Repositorios
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly OfertasContext _context;
        public ComentarioRepositorio(OfertasContext context)
        {
            _context = context;
        }

        public void Adicionar(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
        }

        public void Alterar(Comentario comentario)
        {
            _context.Entry(comentario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Comentario> Listar()
        {
            return _context
                        .Comentarios
                        .AsNoTracking()
                        .OrderBy(p => p.DataCriacao);
        }
    }
}
