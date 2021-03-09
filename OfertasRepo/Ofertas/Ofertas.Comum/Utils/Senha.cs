﻿using System;

namespace Ofertas.Comum.Util
{
    public static class Senha
    {
        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Validar(string senha, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hashPassword);
        }
        public static string Gerar()
        {
            string caracteres = "abcdefghjkmnpqrstuvwxyz023456789@!#$%&*";
            string senha = "";
            Random random = new Random();
            for (int f = 0; f < 8; f++)
            {
                senha = senha + caracteres.Substring(random.Next(0, caracteres.Length - 1), 1);
            }

            return senha;
        }
    }
}
