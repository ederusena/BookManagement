using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.DAL;
using BookManagement.Models;

namespace BookManagement.BLL
{
    public class LoanService
    {
        private readonly IRepository<Loan> _loanRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Book> _bookRepository;

        public LoanService(IRepository<Loan> loanRepository, IRepository<User> userRepository, IRepository<Book> bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public void AddLoan(int userId, int bookId)
        {
            var user = _userRepository.GetById(userId);
            var book = _bookRepository.GetById(bookId);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            if (book == null)
            {
                throw new ArgumentException("Livro não encontrado.");
            }

            var loan = new Loan(user, book);
            _loanRepository.Add(loan);
        }

        public void RemoveLoan(int id)
        {
            _loanRepository.Remove(id);
        }

        public List<Loan> GetAllLoans()
        {
            return _loanRepository.GetAll();
        }

        public Loan GetLoanById(int id)
        {
            return _loanRepository.GetById(id);
        }

        public void UpdateLoan(int id, Loan loan)
        {
            var loanToUpdate = _loanRepository.GetById(id);
            if (loanToUpdate == null)
            {
                throw new Exception("Empréstimo não encontrado");
            }

            loanToUpdate.Add(loan.UserId, loan.BookId);
        }

    }
}