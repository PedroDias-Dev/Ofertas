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

        public Oferta(string nomeProduto, string descricao, string imagem, bool ativo, Guid idUsuario, string preco, string precoAntigo, DateTime dataValidade, bool disponivelDoacao, int estoqueTotal, EnCategoria categoria)
        {

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nomeProduto, 5, "NomeProduto", "O nome deve ter pelo menos 5 caracteres!")
                .HasMaxLen(nomeProduto, 25, "NomeProduto", "O nome deve ter no máximo 25 caracteres!")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descrição do produto")
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe a imagem do produto")
                .IsNotNullOrEmpty(precoAntigo, "PrecoAntigo", "Informe o valor antigo do produto")
                .IsNotNullOrEmpty(preco, "Preco", "Informe o valor atual do produto")
                .IsNotNullOrEmpty(dataValidade.ToString(), "DataValidade", "Informe a data de vencimento do produto")
                .IsNotNullOrEmpty(estoqueTotal.ToString(), "EstoqueTotal", "Informe a quantidade de produtos existentes em estoque para a oferta")
            );

            if (Valid)
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

        public void AtivarOferta()
        {
            Ativo = true;
        }

        public void DesativarOferta()
        {
            Ativo = false;
        }
        
        public void AtivarDisponivelDoacao()
        {
            Ativo = true;
        }

        public void DesativarDisponivelDoacao()
        {
            Ativo = false;
        }

        public void AtualizarOferta(string nomeProduto, string descricao)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(nomeProduto, "NomeProduto", "Informe o nome do produto")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe o descrição do produto")
            );

            if (Valid)
            {
                NomeProduto = nomeProduto;
                Descricao = descricao;
            }
        }

        //TO DO: Inserir mais funções


    }
}
