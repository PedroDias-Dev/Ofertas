using Flunt.Validations;
using Ofertas.Comum.Entidades;
using Ofertas.Comum.Enum;
using System.Collections.Generic;

namespace Ofertas.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres!")
                .HasMaxLen(nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres!")
                .IsEmail(email, "Email", "Informe um e-mail válido!")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres!")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; set; }
        public string Telefone { get; private set; }
        public string CNPJ { get; private set; }
        public string Endereco { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
        public IReadOnlyCollection<Reserva> Reservas { get; }

        
    }
}
