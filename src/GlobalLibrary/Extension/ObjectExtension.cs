using GlobalLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GlobalLibrary
{
	/// <summary>
	/// Расширения для объекта
	/// </summary>
	public static class ObjectExtension {

		#region Преобразование

		/// <summary>
		/// Преобразует в Guid объект являющийся объектом
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="isNew">Создать новый</param>
		/// <returns></returns>
		public static Guid ToGuid(this object obj, bool isNew = false) {
			try {
				if (isNew) {
					return Guid.NewGuid();
				} else {
					Guid id = Guid.Empty;
					Guid.TryParse(obj + "", out id);
					return id;
				}
			} catch {
				return Guid.Empty;
			}
		}

		/// <summary>
		/// Преобразование к типу Int
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="defaultValue">Дефолтное значение</param>
		/// <returns></returns>
		public static int ToInt(this object obj, int defaultValue = 0) {
			try {
				var val = defaultValue;
				if(obj is Enum) {
					return (int)obj;
				}
				if(int.TryParse(obj + "", out val)) {
					return val;
				}
				return defaultValue;
			} catch {
				return defaultValue;
			}
		}
		/// <summary>
		/// Преобразование к типу Int
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="defaultValue">Дефолтное значение</param>
		/// <returns></returns>
		public static int FromRomanToInt(this object obj, int defaultValue = 0) {
			try {
				var val = defaultValue;
				val = RomanNumber.RomanToArabic(obj + "");
				return val;
			} catch {
				return defaultValue;
			}
		}

		/// <summary>
		/// Преобразование к типу float
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="defaultValue">Дефолтное значение</param>
		/// <returns></returns>
		public static float ToFloat(this object obj, float defaultValue = 0) {
			try {
				var val = defaultValue;
				if(float.TryParse((obj + "").Replace('.', ','), out val)) {
					return val;
				}
				return defaultValue;
			} catch {
				return defaultValue;
			}
		}

		/// <summary>
		/// Преобразование к типу double
		/// </summary>
		/// <param name="obj">Объект</param>
		/// <param name="defaultValue">Дефолтное значение</param>
		/// <returns></returns>
		public static double ToDouble(this object obj, double defaultValue = 0) {
			try {
				var val = defaultValue;
				if (double.TryParse(obj + "", out val)) {
					return val;
				}
				return defaultValue;
			} catch {
				return defaultValue;
			}
		}
		#endregion

		/// <summary>
		/// Null объект
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsNull(this object obj) {
			return obj == null;
		}
		/// <summary>
		/// Не Null объект
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsNotNull(this object obj) {
			return obj != null;
		}
		/// <summary>
		/// Преобразовывает число для отображения в input type number
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToViewNumber<T>(this T obj) where T:struct {
			return (obj + "").Replace(',', '.');
		}

		/// <summary>
		/// Убирает пробелы по краям и задублированные
		/// </summary>
		/// <returns></returns>
		public static string GetClearText(this object obj) {
			var str = obj + "";
			if (str.IsEmpty()) {
				return null;
			}
			str = str.Trim();
			return Regex.Replace(str, " {2,}", " ");
		}
	}
}
