using Ofertas.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using Ofertas.Comum.Enum;
using System;

namespace Ofertas.Dominio.Commands.Pacote
{
    public class CriarOfertaCommand : Notifiable, ICommand
    {
        public CriarOfertaCommand(string nomeProduto, string descricao, string imagem, bool ativo, Guid idUsuario, string preco, string precoAntigo, DateTime dataValidade, bool disponivelDoacao, int estoqueTotal, EnCategoria categoria)
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

        public string NomeProduto { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public Guid IdUsuario { get; private set; }//empresa : comerciante ou varejista
        //public virtual Usuario Usuario { get; private set; }
        public string Preco { get; private set; }// em R$ e p/unidade
        public string PrecoAntigo { get; private set; }// em R$ e p/unidade
        public DateTime DataValidade { get; private set; }
        public bool DisponivelDoacao { get; private set; }
        public int EstoqueTotal { get; private set; }
        public EnCategoria Categoria { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                //.IsNotNullOrEmpty(Titulo, "Titulo", "Informe o Título do pacote! (Package Error)")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe o Descrição do pacote! (Package Error)")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o Imagem do pacote! (Package Error)")
            );
        }
    }
}
