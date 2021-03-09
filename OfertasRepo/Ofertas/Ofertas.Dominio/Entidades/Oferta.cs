using Flunt.Validations;
using Ofertas.Comum.Entidades;
using Ofertas.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ofertas.Dominio.Entidades
{
    public class Oferta : Entidade
    {

        /// <summary>
        /// Construtor padrão para criar nova oferta
        /// </summary>
        /// <param name="nomeProduto">Nome do Produto</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <param name="imagem">Imagem referente ao produto</param>
        /// <param name="ativo">Disponível para reserva ou não</param>
        /// <param name="idUsuario">Id do comerciante</param>
        /// <param name="usuario"></param>
        /// <param name="preco">Valor atual do produto</param>
        /// <param name="precoAntigo">Valor anterior da oferta</param>
        /// <param name="dataValidade">Prazo para o produto ficar indisponível</param>
        /// <param name="disponivelDoacao">Disponibilidade para doação</param>
        /// <param name="estoqueTotal">Quantidade de produtos no estoque</param>
        /// <param name="categoria">Divisão por classes de produtos</param>
        public Oferta(string nomeProduto, string descricao, string imagem, bool ativo, Guid idUsuario, string preco, string precoAntigo, DateTime dataValidade, bool disponivelDoacao, int estoqueTotal, EnCategoria categoria)
        {
            NomeProduto = nomeProduto;
            Descricao = descricao;
            Imagem = imagem;
            Ativo = ativo;
            IdUsuario = idUsuario;
            Preco = preco;
            PrecoAntigo = precoAntigo;
            DataValidade = dataValidade;
            DisponivelDoacao = disponivelDoacao;
            EstoqueTotal = estoqueTotal;
            Categoria = categoria;
        }

        //props da classe
        public Guid IdOferta { get; private set; }
        public string NomeProduto { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public Guid IdUsuario { get; private set; }//empresa : comerciante ou varejista
        public virtual Usuario Usuario { get; private set; }
        public string Preco { get; private set; }// em R$ e p/unidade
        public string PrecoAntigo { get; private set; }// em R$ e p/unidade
        public DateTime DataValidade { get; private set; }
        public bool DisponivelDoacao { get; private set; }
        public int EstoqueTotal { get; private set; }
        public EnCategoria Categoria { get; private set; }


    }
}
