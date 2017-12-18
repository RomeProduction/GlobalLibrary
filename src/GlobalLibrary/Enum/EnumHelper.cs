using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

		public static string GetDescription(this Enum value) {
			try {
				FieldInfo fi = value.GetType().GetField(value.ToString());

				DescriptionAttribute[] attributes =
				(DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attributes != null && attributes.Length > 0)
					return attributes[0].Description;
				else
					return value.ToString();
			} catch {
				return "";
			}
		}
	}
}
