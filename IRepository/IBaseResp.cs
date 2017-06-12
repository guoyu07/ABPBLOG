using ABPLOGMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IBaseResp<T> where T:class
    {
        void Add(T T);
        void AddList(IEnumerable<T> list);
        void Update(T T);
        void Delete(T T);
        void Delete(int id);
        void Delete(int[] ids);
        T Get(int id);
        T Get(Expression<Func<T, bool>> fun);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetList(Expression<Func<T, T>> entity,Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> order = null);
        Tuple<int, IEnumerable<T>> GetPage(Page page, Expression<Func<T, T>> entity, Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> order = null);
    }
}
