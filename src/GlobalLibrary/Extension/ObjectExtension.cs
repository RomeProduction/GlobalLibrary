using System;
using System.Collections.Generic;
using System.Linq;
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
				int.TryParse(obj + "", out val);
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
				float.TryParse(obj + "", out val);
				return val;
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
				double.TryParse(obj + "", out val);
				return val;
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
	}
}
