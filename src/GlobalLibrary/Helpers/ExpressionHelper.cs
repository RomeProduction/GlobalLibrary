using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GlobalLibrary
{
	/// <summary>
	/// Помощь в рботе с выражениями
	/// </summary>
    public static class ExpressionHelper
    {
		/// <summary>
		/// Получить имя свойства из выражения
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="property"></param>
		/// <returns></returns>
		public static string GetExpressionPropertyName<TEntity>(Expression<Func<TEntity, object>> property) {
			string name = null;
			if (property.Body as MemberExpression == null) {
				var expr = property.Body as UnaryExpression;
				var body = expr.Operand as MemberExpression;
				name = body.Member.Name;
			} else {
				var body = property.Body as MemberExpression;
				name = body.Member.Name;
			}

			return name;
		}
    }
}
