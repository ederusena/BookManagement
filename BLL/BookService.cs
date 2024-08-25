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
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.ISBN) || book.PublishYear == 0)
            {
                throw new Exception("Todos os campos são obrigatórios");
            }

            _bookRepository.Add(book);
        }

        public void RemoveBook(int id)
        {
            _bookRepository.Remove(id);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void UpdateBook(int id, Book book)
        {
            var bookToUpdate = _bookRepository.GetById(id);
            if (bookToUpdate == null)
            {
                throw new Exception("Livro não encontrado");
            }

            bookToUpdate.Add(book.Title, book.Author, book.ISBN, book.PublishYear);
        }
    }
}