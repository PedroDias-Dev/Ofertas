using Ofertas.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Enum;
using Ofertas.Comum.Entidades;
using System;

namespace Ofertas.Dominio.Commands.Pacote
{
    public class AlterarOfertaCommand : Notifiable, ICommand
    {
        public AlterarOfertaCommand()
        {

        }
        
        public AlterarOfertaCommand(Guid idOferta, string nomeProduto, string descricao, float preco, float precoAntigo, DateTime dataValidade, int estoqueTotal, EnTipoCategoria categoria)
        {
            IdOferta = idOferta;
            NomeProduto = nomeProduto;
            Descricao = descricao;
            Preco = preco;
            PrecoAntigo = precoAntigo;
            DataValidade = dataValidade;
            EstoqueTotal = estoqueTotal;
            Categoria = categoria;
        }

        public Guid IdOferta { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }// em R$ e p/unidade
        public float PrecoAntigo { get; set; }// em R$ e p/unidade
        public DateTime DataValidade { get; set; }
        public int EstoqueTotal { get; set; }
        public EnTipoCategoria Categoria { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdOferta, Guid.Empty, "IdOferta", "Id do produto é inválido! (Package Error)")
                .IsNotNullOrEmpty(NomeProduto, "Produto", "Informe o nome do produto! (Package Error)")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe o descrição do produto! (Package Error)")
                .IsNotNullOrEmpty(Preco.ToString(), "Preco", "Informe o valor atual do produto! (Package Error)")
                .IsNotNullOrEmpty(PrecoAntigo.ToString(), "PrecoAntigo", "Informe o valor antigo do produto! (Package Error)")
                .IsNotNullOrEmpty(DataValidade.ToString(), "DataValidade", "Informe o prazo de vencimento do produto! (Package Error)")
                .IsNotNullOrEmpty(EstoqueTotal.ToString(), "EstoqueTotal", "Informe a quantidade de produtos existentes em estoque para a oferta! (Package Error)")
                .IsNotNullOrEmpty(Categoria.ToString(), "Categoria", "Informe a categoria que o produto melhor se encaixa! (Package Error)")
        );
        }

    }
}

