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
            UserId = userId;
            BookId = bookId;
            LoanDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public User UserId { get; private set; }
        public Book BookId { get; private set; }
        public DateTime LoanDate { get; private set; }
    }

}