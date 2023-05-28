using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResumeBuilder.Models.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T , bool>> filter, string? includeProperties =null);
        IEnumerable<T> GetAll(string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveAll(IEnumerable<T> entity);
    }
}
