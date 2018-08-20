using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;

namespace GlobalLibrary {
	/// <summary>
	/// Расширение для коллекций
	/// </summary>
	public static class IEnumerableExtension {
		/// <summary>
		/// Сравнение двух массивов по заданному свойству
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="col">Коллекция 1</param>
		/// <param name="col2">Коллекция 2</param>
		/// <param name="property">свойство 1</param>
		/// <param name="property2">свойство 2</param>
		/// <remarks>В качестве свойства имеет смысл передавать только элементарные типы</remarks>
		/// <returns></returns>
		public static bool IsEqualEntityCollection<TEntity>(this IEnumerable<TEntity> col, IEnumerable<TEntity> col2,
			params Expression<Func<TEntity, object>>[] property)
			where TEntity : class {
			try {
				if(col == null && col2 == null) {
					return true;
				} else if(col == null && col2 != null ||
					 col2 == null && col != null) {
					return false;
				}

				if(col.Count() != col2.Count()) {
					return false;
				}

				if(!col.EqualEntityCollection(col2, property)) {
					return false;
				}
				if(!col2.EqualEntityCollection(col, property)) {
					return false;
				}

				return true;
			} catch(Exception ex) {
				return false;
			}
		}
		/// <summary>
		/// Сравнение двух массивов по заданному свойству
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="col">Коллекция 1</param>
		/// <param name="col2">Коллекция 2</param>
		/// <param name="property">свойство 1</param>
		/// <param name="property2">свойство 2</param>
		/// <remarks>В качестве свойства имеет смысл передавать только элементарные типы</remarks>
		/// <returns></returns>
		public static bool IsNotEqualEntityCollection<TEntity>(this IEnumerable<TEntity> col, IEnumerable<TEntity> col2,
			Expression<Func<TEntity, object>> property,
			Expression<Func<TEntity, object>> property2 = null)
			where TEntity : class {
			try {
				return !IsEqualEntityCollection(col, col2, property, property2);
			} catch(Exception ex) {
				return false;
			}
		}
		/// <summary>
		/// Сравнить коллекцию
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="col"></param>
		/// <param name="col2"></param>
		/// <param name="property"></param>
		/// <param name="property2"></param>
		/// <returns></returns>
		private static bool EqualEntityCollection<TEntity>(this IEnumerable<TEntity> col, IEnumerable<TEntity> col2,
			Expression<Func<TEntity, object>> property,
			Expression<Func<TEntity, object>> property2 = null) {

			var name = ExpressionHelper.GetExpressionPropertyName<TEntity>(property);

			string name2 = null;
			if(property2.IsNotNull()) {
				name2 = ExpressionHelper.GetExpressionPropertyName<TEntity>(property2);
			}

			foreach(var ent in col2) {
				var value = (ent.GetType().GetProperty(name).GetValue(ent) + "").ToUpper();
				string value2 = null;
				if(name2.IsNotEmpty()) {
					value2 = (ent.GetType().GetProperty(name2).GetValue(ent) + "").ToUpper();
				}

				bool isAny = true;

				foreach(var compEnt in col) {
					var compVal = (compEnt.GetType().GetProperty(name).GetValue(compEnt) + "").ToUpper();
					string compVal2 = null;
					if(name2.IsNotEmpty()) {
						compVal2 = (compEnt.GetType().GetProperty(name2).GetValue(compEnt) + "").ToUpper();
					}

					if(name2.IsEmpty()) {
						if(value == compVal) {
							isAny = true;
							break;
						} else {
							isAny = false;
						}
					} else {
						if(value == compVal && value2 == compVal2) {
							isAny = true;
							break;
						} else {
							isAny = false;
						}
					}
				}

				if(!isAny) {
					return isAny;
				}
			}
			return true;
		}

		/// <summary>
		/// Сравнить коллекцию
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="col"></param>
		/// <param name="col2"></param>
		/// <param name="property"></param>
		/// <param name="property2"></param>
		/// <returns></returns>
		private static bool EqualEntityCollection<TEntity>(this IEnumerable<TEntity> col, IEnumerable<TEntity> col2,
			params Expression<Func<TEntity, object>>[] properties) {

			IList<string> names = new List<string>();
			foreach(var prop in properties) {
				var name = ExpressionHelper.GetExpressionPropertyName<TEntity>(prop);
				names.Add(name);
			}

			foreach(var ent in col2) {

				IList<string> values = new List<string>();
				foreach(var name in names) {
					var value = (ent.GetType().GetProperty(name).GetValue(ent) + "").ToUpper();
					values.Add(value);
				}

				bool isAny = true;

				foreach(var compEnt in col) {
					IList<string> compValues = new List<string>();
					foreach(var name in names) {
						var value = (compEnt.GetType().GetProperty(name).GetValue(compEnt) + "").ToUpper();
						compValues.Add(value);
					}

					bool isEqual = true;
					for(int i = 0; i < values.Count; i++) {
						if(values[i] != compValues[i]) {
							isEqual = false;
							break;
						}
					}

					if(isEqual) {
						isAny = true;
						break;
					} else {
						isAny = false;
					}
				}

				if(!isAny) {
					return isAny;
				}
			}
			return true;
		}
	}
}
