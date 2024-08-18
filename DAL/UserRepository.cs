using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Models;

namespace BookManagement.DAL
{
    public class UserRepository : IRepository<User>
    {
        private readonly List<User> _users = new();
        public void Add(User entity)
        {
            _users.Add(entity);
        }

        public List<User> GetAll()
        {
            return _users.ToList();
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}