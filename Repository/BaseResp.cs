using DapperExtention;
using IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Dapper;
    using Dapper.Contrib.Extensions;
    using System.Linq.Expressions;
    public class BaseResp<T> : IBaseResp<T> where T : class
    {
        protected IDbConnection Conn { get; set; }
        public BaseResp()
        {
            Conn = DapperConnnectionFactory.CreateDbConnection();
        }
        public void Add(T T)
        {
            Conn.Insert<T>(T);
        }

        public void AddList(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Add(item);
            }
        }

        public void Delete(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                Conn.Delete<T>(Get(ids[i]));
            }
        }

        public void Delete(int id)
        {
            Conn.Delete<T>(Get(id));
        }

        public void Delete(T T)
        {
            Conn.Delete<T>(T);
        }

        public T Get(Expression<Func<T, bool>> fun)
        {
            return Conn.Get<T>(fun);
        }

        public T Get(int id)
        {
            return Conn.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Conn.GetAll<T>();
        }

        public IEnumerable<T> GetList(Expression<Func<T,T>> entity,Expression<Func<T, bool>> where = null, Expression<Func<T, T>> order = null)
        {
            var expression = new ExpressionToSql();
            string selectentity=expression.GetSql<T>(entity);
            string wheresql=expression.GetSql<T>(where);
            string ordersql=expression.GetSql<T>(order);
            string sql = selectentity+""+where+" order by "+order;
            return Conn.Query<T>(sql).ToList();
        }

        public Tuple<int, IEnumerable<T>> GetPage(global::ABPLOGMODEL.Page page, Expression<Func<T, T>> entity, Expression<Func<T, bool>> where = null, Expression<Func<T, bool>> order = null)
        {
            var expression = new ExpressionToSql();
            string selectentity = expression.GetSql<T>(entity);
            string wheresql = expression.GetSql<T>(where);
            string ordersql = expression.GetSql<T>(order);
            string sql = selectentity + "" + where + " order by " + order+" asc limit "+(page.PageIndex-1)*page.Pagesize+","+page.Pagesize;
            return new Tuple<int, IEnumerable<T>>( 100,Conn.Query<T>(sql).ToList());
        }

        public void Update(T T)
        {
            Conn.Update<T>(T);
        }
    }
}
