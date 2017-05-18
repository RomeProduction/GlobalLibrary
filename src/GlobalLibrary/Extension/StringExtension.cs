using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLibrary
{
	/// <summary>
	/// Расширение для строк
	/// </summary>
	public static class StringExtension {
		/// <summary>
		/// Преобразует в Guid объект являющийся строкой
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="isNew">Создать новый</param>
		/// <returns></returns>
		public static Guid ToGuid(this string obj, bool isNew = false) {
			try {
				if (isNew) {
					return Guid.NewGuid();
				} else {
					Guid id = Guid.Empty;
					Guid.TryParse(obj, out id);
					return id;
				}
			} catch {
				return Guid.Empty;
			}
		}

		/// <summary>
		/// Пустая ли строка
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <returns></returns>
		public static bool IsEmpty(this string obj) {
			obj = obj.Trim();
			return string.IsNullOrEmpty(obj);
		}

		/// <summary>
		/// Не пустая ли строка
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <returns></returns>
		public static bool IsNotEmpty(this string obj) {
			obj = obj.Trim();
			return !string.IsNullOrEmpty(obj);
		}
	}
}
