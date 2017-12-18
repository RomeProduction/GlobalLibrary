using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GlobalLibrary {
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
			if (obj != null) {
				obj = obj.Trim();
			}
			return string.IsNullOrEmpty(obj);
		}

		/// <summary>
		/// Не пустая ли строка
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <returns></returns>
		public static bool IsNotEmpty(this string obj) {
			if (obj != null) {
				obj = obj.Trim();
			}
			return !string.IsNullOrEmpty(obj);
		}
		/// <summary>
		/// Убирает пробелы по краям и задублированные
		/// </summary>
		/// <returns></returns>
		public static string GetClearText(this string obj) {
			if (obj.IsEmpty()) {
				return null;
			}
			obj = obj.Trim();
			return Regex.Replace(obj, " {2,}", " ");
		}
	}
}
