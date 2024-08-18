using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.DAL;
using BookManagement.Models;

namespace BookManagement.BLL
{
    public class BookService
    {
        private readonly IRepository<Book> _livroRepository;

        public BookService(IRepository<Book> livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void AddBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.ISBN) || book.PublishYear == 0)
            {
                throw new Exception("Todos os campos são obrigatórios");
            }

            _livroRepository.Add(book);
        }

        public void RemoveBook(int id)
        {
            _livroRepository.Remove(id);
        }

        public List<Book> GetAllBooks()
        {
            return _livroRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _livroRepository.GetById(id);
        }

        public void UpdateBook(int id, Book book)
        {
            var bookToUpdate = _livroRepository.GetById(id);
            if (bookToUpdate == null)
            {
                throw new Exception("Livro não encontrado");
            }

            bookToUpdate.Add(book.Title, book.Author, book.ISBN, book.PublishYear);
        }
    }
}