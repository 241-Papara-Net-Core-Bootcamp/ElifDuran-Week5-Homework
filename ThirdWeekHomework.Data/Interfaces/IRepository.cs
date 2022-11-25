using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        List<T> Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
