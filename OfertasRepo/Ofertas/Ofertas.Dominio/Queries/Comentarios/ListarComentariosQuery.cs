using Ofertas.Comum.Queries;
using Ofertas.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Dominio.Queries.Comentarios
{
    public class ListarComentariosQuery : IQuery
    {
        public void Validar()
        {

        }
    }

    public class ListarComentariosQueryResult
    {
        public string Texto { get; set; }
        public Guid IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        public Guid IdOferta { get; set; }
        public virtual Oferta Oferta { get; set; }
    }
}
