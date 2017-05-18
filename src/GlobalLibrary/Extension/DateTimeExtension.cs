using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLibrary
{
	/// <summary>
	/// Полезные методы для дат
	/// </summary>
    public static class DateTimeExtension
    {
		/// <summary>
		/// Преобразовывает в дату
		/// </summary>
		/// <param name="dat"></param>
		/// <returns></returns>
		public static string ToRusDate(this DateTime dat) {
			return dat.ToString("dd/MM/yyyy HH:mm");
		}
    }
}
