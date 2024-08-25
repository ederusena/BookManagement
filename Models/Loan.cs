using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class Loan
    {
        public Loan(User userId, Book bookId)
        {
            Id = generateId();
            UserId = userId;
            BookId = bookId;
            LoanDate = DateTime.Now;
        }

        private static int autoId = 0;
        public int Id { get; private set; }
        public User UserId { get; private set; }
        public Book BookId { get; private set; }
        public DateTime LoanDate { get; private set; }

        private static int generateId()
        {
            return autoId++;
        }

        internal void Add(User userId, Book bookId)
        {
            UserId = userId;
            BookId = bookId;
            LoanDate = DateTime.Now;
        }
    }

}