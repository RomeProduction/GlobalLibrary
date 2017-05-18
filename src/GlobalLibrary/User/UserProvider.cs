using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLibrary.User {
	/// <summary>
	/// Провайдер для пользователя
	/// </summary>
	/// <typeparam name="TKey">Тип ключа пользователя</typeparam>
	public abstract class UserProvider<TKey> where TKey : struct {
		/// <summary>
		/// Получить ID пользователя
		/// </summary>
		/// <returns></returns>
		public abstract TKey GetUserID {
			get;
		}

		/// <summary>
		/// Получить имя пользователя
		/// </summary>
		/// <returns></returns>
		public abstract string GetUserName {
			get;
		}
		/// <summary>
		/// Получить Email
		/// </summary>
		public abstract string GetEmail {
			get;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		public UserProvider() {

		}
	}
}
