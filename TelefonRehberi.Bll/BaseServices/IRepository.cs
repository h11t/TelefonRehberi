using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Bll.BaseServices
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Delete(int Id);
        T Update(T entity);

        
        ICollection<T> GetList(Expression<Func<T, bool>> filter = null);
        int Save();
       
        T Find(int Id);
        T FirstOrDefault(Expression<Func<T, bool>> _lambda);
        bool Any(Expression<Func<T, bool>> _lambda);
        int Count(Expression<Func<T, bool>> _lambda);
    }
}
