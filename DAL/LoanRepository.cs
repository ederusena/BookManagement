using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Models;

namespace BookManagement.DAL
{
    public class LoanRepository : IRepository<Loan>
    {
        private readonly List<Loan> _loans = new();
        public void Add(Loan entity)
        {
            _loans.Add(entity);
        }

        public List<Loan> GetAll()
        {
            return _loans.ToList();
        }

        public Loan GetById(int id)
        {
            return _loans.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException("Loan not found.");
        }

        public void Remove(int id)
        {
            var loan = GetById(id);
            if (loan != null)
            {
                _loans.Remove(loan);

            }
        }
    }
}