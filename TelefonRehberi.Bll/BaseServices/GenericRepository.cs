using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Dal.Entity;
using TelefonRehberi.Entity.Model;

namespace TelefonRehberi.Bll.BaseServices
{
    public class GenericRepository<T> : IRepository<T>  where T:BaseEntity
    {
        public RehberContext _context;
        public GenericRepository(RehberContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            entity.GetType().GetProperty("EklenmeTarihi").SetValue(entity, DateTime.Now);
            _context.Set<T>().Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> _lambda)
        {
            return _context.Set<T>().Any(_lambda);
        }

        public int Count(Expression<Func<T, bool>> _lambda)
        {
            return _context.Set<T>().Count(_lambda);
        }


        public void Delete(int Id)
        {
            var entity = Find(Id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public T Find(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> _lambda)
        {
            return _context.Set<T>().FirstOrDefault(_lambda);
        }

        

        public ICollection<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return _context.Set<T>().ToList();
        }

        

        public int Save()
        {
           return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            entity.GetType().GetProperty("GuncellenmeTarihi").SetValue(entity, DateTime.Now);
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
