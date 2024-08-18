using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class User
    {
        public User(string name, string email)
        {
            Id = generateId();
            Name = name;
            Email = email;
        }

        public User() { }


        private static int autoId = 0;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public void Add(string name, string email)
        {

            Name = name;
            Email = email;
        }

        private static int generateId()
        {
            return autoId++;
        }
    }
}