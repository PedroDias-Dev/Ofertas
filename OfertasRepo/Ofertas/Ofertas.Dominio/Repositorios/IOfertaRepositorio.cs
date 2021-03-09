using Ofertas.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Repositorios
{
    public interface IOfertaRepositorio
    {
        void Adicionar(Oferta oferta);
        void Alterar(Oferta oferta);
        IEnumerable<Oferta> Listar(bool? ativo = null);
        Oferta BuscarPorTitulo(string titulo);
        Oferta BuscarPorId(Guid id);
    }
}
