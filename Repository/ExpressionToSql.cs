using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Repository
{
    public class ExpressionToSql
    {
        public string GetSql<T>(Expression<Func<T, T>> exp)
        {
            return DealExpression(exp.Body);
        }
        public string GetSql<T>(Expression<Func<T, bool>> exp)
        {
            return DealExpression(exp.Body);
        }




        private  object Eval(MemberExpression member)
        {
            var cast = Expression.Convert(member, typeof(object));
            object c = Expression.Lambda<Func<object>>(cast).Compile().Invoke();
            Console.WriteLine(c.GetType().FullName);
            return c;
        }
        private string DealExpression(Expression exp, bool need = false)
        {
            string name = exp.GetType().Name;
            switch (name)
            {
                case "BinaryExpression":
                case "LogicalBinaryExpression":
                case "MethodBinaryExpression":
                case "SimpleBinaryExpression":
                    {
                        BinaryExpression b_exp = exp as BinaryExpression;
                        if (exp.NodeType == ExpressionType.Add
                            || exp.NodeType == ExpressionType.Subtract
                            //|| exp.NodeType == ExpressionType.Multiply
                            //|| exp.NodeType == ExpressionType.Divide
                            //|| exp.NodeType == ExpressionType.Modulo
                            )
                        {
                            return "(" + DealBinary(b_exp) + ")";
                        }

                        if (!need) return DealBinary(b_exp);
                        BinaryExpression b_left = b_exp.Left as BinaryExpression;
                        BinaryExpression b_right = b_exp.Right as BinaryExpression;
                        if (b_left != null && b_right != null)
                        {
                            return "(" + DealBinary(b_exp) + ")";
                        }
                        return DealBinary(b_exp);
                    }
                case "MemberExpression":
                case "PropertyExpression":
                case "FieldExpression":
                    return DealMember(exp as MemberExpression);
                case "ConstantExpression": return DealConstant(exp as ConstantExpression);
                case "MemberInitExpression":
                    return DealMemberInit(exp as MemberInitExpression);
                case "UnaryExpression": return DealUnary(exp as UnaryExpression);

                default:
                    Console.WriteLine("error:" + name);
                    return "";
            }

        }
        private string DealFieldAccess(FieldAccessException f_exp)
        {
            var c = f_exp;
            return "";
        }

        private string DealUnary(UnaryExpression u_exp)
        {
            var m = u_exp;
            return DealExpression(u_exp.Operand);

        }
        private string DealMemberInit(MemberInitExpression mi_exp)
        {
            var i = 0;
            string exp_str = string.Empty;
            foreach (var item in mi_exp.Bindings)
            {
                MemberAssignment c = item as MemberAssignment;
                if (i == 0)
                {
                    exp_str += c.Member.Name.ToUpper() + "=" + DealExpression(c.Expression);
                }
                else
                {
                    exp_str += "," + c.Member.Name.ToUpper() + "=" + DealExpression(c.Expression);
                }
                i++;
            }
            return exp_str;

        }
        private string DealBinary(BinaryExpression exp)
        {
            return DealExpression(exp.Left) + NullValueDeal(exp.NodeType, DealExpression(exp.Right, true));// GetOperStr(exp.NodeType) + DealExpression(exp.Right, true);
        }
        private string GetOperStr(ExpressionType e_type)
        {
            switch (e_type)
            {
                case ExpressionType.OrElse: return " OR ";
                case ExpressionType.Or: return "|";
                case ExpressionType.AndAlso: return " AND ";
                case ExpressionType.And: return "&";
                case ExpressionType.GreaterThan: return ">";
                case ExpressionType.GreaterThanOrEqual: return ">=";
                case ExpressionType.LessThan: return "<";
                case ExpressionType.LessThanOrEqual: return "<=";
                case ExpressionType.NotEqual: return "<>";
                case ExpressionType.Add: return "+";
                case ExpressionType.Subtract: return "-";
                case ExpressionType.Multiply: return "*";
                case ExpressionType.Divide: return "/";
                case ExpressionType.Modulo: return "%";
                case ExpressionType.Equal: return "=";
            }
            return "";
        }

        private string DealField(MemberExpression exp)
        {
            return Eval(exp).ToString();
        }
        private string DealMember(MemberExpression exp)
        {
            if (exp.Expression != null)
            {
                if (exp.Expression.GetType().Name == "TypedParameterExpression")
                {
                    return exp.Member.Name;
                }
                return  Eval(exp).ToString();
                
            }
          
          
            Type type = exp.Member.ReflectedType;
            PropertyInfo propertyInfo = type.GetProperty(exp.Member.Name, BindingFlags.Static | BindingFlags.Public);
            object o;
            if (propertyInfo != null)
            {
                o = propertyInfo.GetValue(null);
            }
            else
            {
                FieldInfo field = type.GetField(exp.Member.Name, BindingFlags.Static | BindingFlags.Public);
                o = field.GetValue(null);
            }


           
            //var p = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);


            //Console.WriteLine(exp.GetType().Name);
            return GetValueFormat(o);

        }
        private string DealConstant(ConstantExpression exp)
        {
            var ccc = exp.Value.GetType();

            if (exp.Value == null)
            {
                return "NULL";
            }
            return GetValueFormat(exp.Value);
        }
        private string NullValueDeal(ExpressionType NodeType, string value)
        {
            if (value.ToUpper() != "NULL")
            {
                return GetOperStr(NodeType) + value;
            }

            switch (NodeType)
            {
                case ExpressionType.NotEqual:
                    {
                        return " IS NOT NULL ";
                    }
                case ExpressionType.Equal:
                    {
                        return " IS NULL ";
                    }
                default: return GetOperStr(NodeType) + value;
            }
        }
        private string GetValueFormat(object obj)
        {
            if (obj.GetType() == typeof(string))// || obj.GetType() == typeof(DateTime))
            {
                return string.Format("'{0}'", obj.ToString());
            }
            if (obj.GetType() == typeof(DateTime))
            {
                DateTime dt =  (DateTime)obj;
                return  string.Format("'{0}'",  dt.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }
            return obj.ToString();
        }


    }
}
