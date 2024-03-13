using Emprestimos_Livros.Data;
using Emprestimos_Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Emprestimos_Livros.Repositories
{
    public class UsuariosRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuariosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UsuarioModel> GetAll()
        {
            return _context.Usuarios.Include(u => u.Livros).ToList();

        }

        public UsuarioModel Cadastrar(UsuarioModel user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UsuarioModel Editar(UsuarioModel user)
        {
            _context.Usuarios.Update(user);
            _context.SaveChanges();
            return user;
        }
        public UsuarioModel GetById(int? id)
        {
            return _context.Usuarios
                .Include(u => u.Livros) 
                .FirstOrDefault(x => x.Id == id);
        }


        public bool Excluir(UsuarioModel usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }


    }
}
