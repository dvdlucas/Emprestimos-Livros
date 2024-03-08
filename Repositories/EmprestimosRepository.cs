﻿using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;

namespace Emprestimos_Livros.Repositories
{
    public class EmprestimosRepository
    {
        private readonly ApplicationDbContext _context;

        public EmprestimosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<EmprestimosModelcs> BuscarTodos()
        {
            return _context.Emprestimos.ToList();
        }

        public EmprestimosModelcs Adicionar(EmprestimosModelcs emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
            return emprestimo;
        }

        public bool Remover(EmprestimosModelcs emprestimosModelcs) 
        {
            _context.Emprestimos.Remove(emprestimosModelcs);
            _context.SaveChanges();
            return true;
        }

        public EmprestimosModelcs Editar(EmprestimosModelcs emprestimos)
        {
            _context.Update(emprestimos);
            _context.SaveChanges();
            return emprestimos;
        }


    }
}