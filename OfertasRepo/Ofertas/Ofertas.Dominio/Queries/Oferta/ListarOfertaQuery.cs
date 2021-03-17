using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using Ofertas.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Ofertas.Dominio.Queries.Ofertas
{
    public class ListarOfertaQuery : IQuery
    {
        public bool? Ativo { get; set; } = null;
        public void Validar()
        {

        }
    }

    public class ListarOfertaQueryResult
    {
        public Guid IdOferta { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public Guid IdUsuario { get; set; }//empresa : comerciante ou varejista
        public float Preco { get; set; }// em R$ e p/unidade
        public float PrecoAntigo { get; set; }// em R$ e p/unidade
        public DateTime DataValidade { get; set; }
        public bool DisponivelDoacao { get; set; }
        public int EstoqueTotal { get; set; }
        public EnTipoCategoria Categoria { get; set; }
        public int QuantidadeComentarios { get; internal set; }
        public IReadOnlyCollection<Comentario> Comentarios { get; internal set; }
    }
}
