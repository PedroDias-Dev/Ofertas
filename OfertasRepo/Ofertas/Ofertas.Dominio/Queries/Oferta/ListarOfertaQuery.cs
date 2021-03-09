using Ofertas.Comum.Enum;
using Ofertas.Comum.Queries;
using System;

namespace Ofertas.Dominio.Queries.Oferta
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
        public string Preco { get; set; }// em R$ e p/unidade
        public string PrecoAntigo { get; set; }// em R$ e p/unidade
        public DateTime DataValidade { get; set; }
        public bool DisponivelDoacao { get; set; }
        public int EstoqueTotal { get; set; }
        public EnCategoria Categoria { get; set; }
    }
}
