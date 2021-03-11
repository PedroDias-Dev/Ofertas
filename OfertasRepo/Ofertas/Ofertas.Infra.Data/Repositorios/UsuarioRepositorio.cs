﻿using Ofertas.Dominio.Entidades;
using Ofertas.Dominio.Repositorios;
using Ofertas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTur.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly OfertasContext _context;

        public UsuarioRepositorio(OfertasContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<Usuario> Listar()
        {
            return _context.Usuarios
                    .AsNoTracking()
                    .Include(u => u.Reservas)
                    .OrderBy(u => u.DataCriacao)
                    .ToList();
        }
    }
}
