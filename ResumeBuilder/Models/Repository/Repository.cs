using ResumeBuilder.Models.DataLayer;
using ResumeBuilder.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ResumeBuilder.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ResumeBuilderContext _db;

        internal DbSet<T> dbSet;
        public Repository(ResumeBuilderContext db)
        {
            _db = db;
          // _db.FundraisingProjs.Include(u => u.ProjCategory).Include(u => u.UserAccount);
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
                IQueryable<T> query = dbSet;

            if (includeProperties != null)

            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))

                {
                    query = query.Include(includeProp);
                }

            }
            return query.ToList();

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveAll(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
