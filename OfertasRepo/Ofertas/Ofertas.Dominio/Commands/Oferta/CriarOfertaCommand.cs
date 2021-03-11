using Ofertas.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Enum;
using System;

namespace Ofertas.Dominio.Commands.Oferta
{
    public class CriarOfertaCommand : Notifiable, ICommand
    {
        public CriarOfertaCommand(string nomeProduto, string descricao, string imagem, bool ativo, Guid idUsuario, float preco, float precoAntigo, DateTime dataValidade, bool disponivelDoacao, int estoqueTotal, EnTipoCategoria categoria)
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

        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public Guid IdUsuario { get; private set; } //empresa : comerciante ou varejista
        public float Preco { get; private set; }// em R$ e p/unidade
        public float PrecoAntigo { get; private set; }// em R$ e p/unidade
        public DateTime DataValidade { get; private set; }
        public bool DisponivelDoacao { get; private set; }
        public int EstoqueTotal { get; private set; }
        public EnTipoCategoria Categoria { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeProduto, "Produto", "Informe o nome do produto! (Package Error)")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe o descrição do produto! (Package Error)")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o imagem do produto! (Package Error)")
                //.IsNotNullOrEmpty(Ativo.ToString(), "Ativo", "Informe se o produto está disponível para a visualização dos consumidores! (Package Error)")
                .IsNotNullOrEmpty(Preco.ToString(), "Preco", "Informe o valor atual do produto! (Package Error)")
                .IsNotNullOrEmpty(PrecoAntigo.ToString(), "PrecoAntigo", "Informe o valor antigo do produto! (Package Error)")
                //.IsNotNullOrEmpty(DataValidade.ToString(), "DataValidade", "Informe o prazo de vencimento do produto! (Package Error)")
                .IsNotNullOrEmpty(DisponivelDoacao.ToString(), "DisponivelDoacao", "Informe se o produto está disponivel para doação! (Package Error)")
                .IsNotNullOrEmpty(EstoqueTotal.ToString(), "EstoqueTotal", "Informe a quantidade de produtos existentes em estoque para a oferta! (Package Error)")
                .IsNotNullOrEmpty(Categoria.ToString(), "Categoria", "Informe a categoria que o produto melhor se encaixa! (Package Error)")
                );
        }
    }
}
