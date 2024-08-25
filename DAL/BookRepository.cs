using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Models;

namespace BookManagement.DAL
{
    public class BookRepository : IRepository<Book>
    {
        private readonly List<Book> _livros = new();
        public void Add(Book entity)
        {
            _livros.Add(entity);
        }

        public List<Book> GetAll()
        {
            return _livros.ToList();
        }

        public Book GetById(int id)
        {
            return _livros.FirstOrDefault(x => x.Id == id)!;
        }

        public void Remove(int id)
        {
            var livro = GetById(id);
            if (livro != null)
            {
                _livros.Remove(livro);
            }
        }
    }
}