using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.DAL
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}