using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLibrary
{
	/// <summary>
	/// Полезные методы для гуидов
	/// </summary>
    public static class GuidExtension
    {
		/// <summary>
		/// Пустой гуид
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsEmpty(this Guid obj) {
			return obj == Guid.Empty;
		}
		/// <summary>
		/// Не пустой гуид
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsNotEmpty(this Guid obj) {
			return obj != Guid.Empty;
		}
		/// <summary>
		/// Пустой гуид
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsEmpty(this Guid? obj) {
			if (obj != null && obj.HasValue) {
				return obj == Guid.Empty;
			}
			return false;
		}
		/// <summary>
		/// Не пустой гуид
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsNotEmpty(this Guid? obj) {
			if (obj != null && obj.HasValue) {
				return obj != Guid.Empty;
			}
			return false;
		}
	}
}
