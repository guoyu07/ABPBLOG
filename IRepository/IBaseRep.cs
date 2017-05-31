using ABPLOGDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IBaseRep
    {
        Task<Resultcurd> Insert<T>(T t,bool isauto=true);
        /// <summary>
        /// 全部更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="whereExp"></param>
        /// <returns></returns>
        Task<Resultcurd> UpdateAll<T>(T t,Expression<Func<T,bool>> whereExp=null);
        /// <summary>
        /// 部分更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="updateExp">更新字段new{m.Name,....} Or new{m.Name="",....}</param>
        /// <param name="whereExp">判断条件，如果为空默认根据Id判断</param>
        /// <returns></returns>
        Task<Resultcurd> Updatepart<T>(T t,Expression<Func<T,object>> updateExp,Expression<Func<T,bool>> whereExp);

        Task<Resultcurd> Delete<T>(T t);
    }
}
