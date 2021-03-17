using Ofertas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Repositorios
{
    public interface IComentarioRepositorio
    {
        void Adicionar(Comentario comentario);
        void Alterar(Comentario comentario);
        IEnumerable<Comentario> Listar();

        IEnumerable<Comentario> BuscarPorId(Guid id);

    }
}
