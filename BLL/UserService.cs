using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.DAL;
using BookManagement.Models;

namespace BookManagement.BLL
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Todos os campos são obrigatórios");
            }

            _userRepository.Add(user);
        }
        
        public void RemoveUser(int id)
        {
            _userRepository.Remove(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(int id, User user)
        {
            var userToUpdate = _userRepository.GetById(id);
            if (userToUpdate == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            if (user.Name != null && user.Email != null)
            {
                userToUpdate.Add(user.Name, user.Email);
            }
        }
    }
}