using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtention
{
    using System.Linq.Expressions;
    public class MysqlExtention
    {
        public string MyInsert<T>(T t)
        {
            string sqlinsert = "Insert into {0}({1}) Values({2})";
            var type = typeof(T);
            var properties = type.GetProperties();
            var tablename = type.Name;
            List<string> member = new List<string>();
            List<string> member_value = new List<string>();
            foreach (PropertyInfo item in properties)
            {
                member.Add(item.Name);
                var objvalue = item.GetValue(t);
                string str_value = string.Empty;
                if (objvalue is String)
                {
                    str_value = string.Format("'{0}'", objvalue.ToString());
                }
                else if (objvalue is DateTime)
                {
                    str_value = string.Format("'{0}'", ((DateTime)objvalue).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    str_value = objvalue.ToString();
                }
                member_value.Add(str_value);
            }
            sqlinsert = string.Format(sqlinsert, tablename, string.Join(",", member), string.Join(",", member_value));
            return sqlinsert;
        }
        public string Myupdate<T>(Expression<Func<T,T>> setvalue, Expression<Func<T, bool>> where = null)
        {
            string sqlupdate = "Update {0} set {1} where {2}";
            var type = typeof(T);
            var tablename = type.Name;

            return null;
        }
        #region 表达式树获取对象

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string Getcanstr(ConstantExpression exp)
        {
            string str = string.Empty;
            object obj = exp.Value;
            if (obj is string)
            {
                str = string.Format("'{0}'", obj.ToString());
            }
            else if (obj is DateTime)
            {
                DateTime time = (DateTime)obj;
                str = string.Format("'{0}'", time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                str = obj.ToString();
            }
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string Getexpstr(MemberInitExpression exp)
        {
            string str = string.Empty;
            List<string> member = new List<string>();
            //注;item必须为MemberAssignment类型否者没有expression属性
            foreach (MemberAssignment item in exp.Bindings)
            {
                String update = item.Member.Name + "=" + Getcanstr((ConstantExpression)item.Expression);
                member.Add(update);
            }
            str = string.Join(",", member);
            return str;

        }

        #endregion


        #region 表达式树获取条件

        #endregion
    }
}
