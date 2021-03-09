using Ofertas.Comum.Entidades;
using Ofertas.Comum.Enum;
using Flunt.Br.Extensions;
using Flunt.Validations;
using System.Collections.Generic;

namespace Ofertas.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string email, string senha, string telefone, string cNPJ, string endereco, EnTipoUsuario tipoUsuario, IReadOnlyCollection<Reserva> reservas)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            CNPJ = cNPJ;
            Endereco = endereco;
            TipoUsuario = tipoUsuario;
            Reservas = reservas;
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
