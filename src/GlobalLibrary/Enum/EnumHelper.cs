using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace GlobalLibrary {
	/// <summary>
	/// Хелпер для работы с перечислениями
	/// </summary>
	public static class EnumHelper {
		/// <summary>
		/// Представить enum в виде списка ключ-значение
		/// </summary>
		/// <typeparam name="TEnum"></typeparam>
		/// <returns></returns>
		public static Dictionary<int, string> GetListParam<TEnum>()
			where TEnum : struct, IConvertible {
			Dictionary<int, string> res = new Dictionary<int, string>();
			foreach (Enum en in Enum.GetValues(typeof(TEnum))) {
				int key = -1;
				key = (int) Enum.Parse(typeof(TEnum), en + "", true);
				if (key == -1) {
					continue;
				}
				res.Add(key, en.GetDescription());
			}

			return res;
		}
		/// <summary>
		/// Получить значение хранящееся в Description
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetDescription(this Enum value) {
			try {
				string result = "";
				string[] values = null;
				if ((value + "").Contains(",")) {
					values = (value + "").Split(',').Select(x => x.Trim()).ToArray();
				} else {
					values = new string[] { value.ToString() };
				}

				foreach (var val in values) {
					FieldInfo fi = value.GetType().GetField(val);

					DescriptionAttribute[] attributes =
					(DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
					if (result != "") {
						result += "; ";
					}

					if (attributes != null && attributes.Length > 0) {
						result += attributes[0].Description;
					} else {
						result += val.ToString();
					}
				}

				return result;
			} catch {
				return "";
			}
		}

		/// <summary>
		/// Получает все перечисленные значения, если перечисление содержит их несколько
		/// </summary>
		/// <param name="value">перечисление</param>
		/// <returns></returns>
		public static int[] GetArrayValues(this Enum value) {
			try {
				List<int> result = new List<int>();
				string[] values = null;
				if ((value + "").Contains(",")) {
					values = (value + "").Split(',').Select(x => x.Trim()).ToArray();
				} else {
					values = new string[] { value.ToString() };
				}

				foreach (var val in values) {
					FieldInfo fi = value.GetType().GetField(val);
					result.Add((int)fi.GetValue(fi));
				}

				return result.ToArray();
			} catch {
				return new int[0];
			}
		}
	}
}
