﻿using Emprestimos_Livros.Models;
using Emprestimos_Livros.Repositories;

namespace Emprestimos_Livros.Services
{
    public class UsuariosServices
    {
        private readonly UsuariosRepository _usuariosRepository;

        public UsuariosServices(UsuariosRepository usuariosRepository)
        { 
            _usuariosRepository = usuariosRepository;
        }

        public UsuarioModel GetByIdService(int? id)
        {
            if (id != null)
            {
                var usuario = _usuariosRepository.GetById(id);

                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    throw new Exception("Usuário não encontrado");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(id), "ID do usuário não pode ser nulo");
            }
        }


        public List<UsuarioModel> GetAllUsuarioService()
        {
            return _usuariosRepository.GetAll();
        }

        public UsuarioModel CadastrarUsuarioService(UsuarioModel usuario)
        {
            if (usuario != null && !string.IsNullOrEmpty(usuario.Name) && !string.IsNullOrEmpty(usuario.Email) && !string.IsNullOrEmpty(usuario.Phone))
            {
                return _usuariosRepository.Cadastrar(usuario);
            }
            else
            {
                throw new InvalidOperationException("Não foi possível adicionar o usuário. Certifique-se de fornecer todos os dados necessários.");
            }
        }

        public bool ExcluirUsuarioService(UsuarioModel usuario)
        {
            return _usuariosRepository.Excluir(usuario);
        }

        public UsuarioModel EditarUsuarioService(UsuarioModel usuario)
        {
            return _usuariosRepository.Editar(usuario);
        }


    }
}