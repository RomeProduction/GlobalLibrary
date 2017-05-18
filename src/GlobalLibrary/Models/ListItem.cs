using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLibrary.Models {
	/// <summary>
	/// Модель для представления справочных значений в списках
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListItem<T> {
		/// <summary>
		/// ID или ключ элемента
		/// </summary>
		public T Id {
			get; set;
		}
		/// <summary>
		/// Текстовое название элемента
		/// </summary>
		public string Text {
			get; set;
		}

		/// <summary>
		/// Выбран ли элемент
		/// </summary>
		[DefaultValue(false)]
		public bool Select {
			get; set;
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id"></param>
		/// <param name="text"></param>
		public ListItem(T id, string text) {
			Id = id;
			Text = text;
		}
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id"></param>
		/// <param name="text"></param>
		public ListItem(T id, string text, bool select) {
			Id = id;
			Text = text;
			Select = select;
		}

		/// <summary>
		/// Переопределенный метод приведения к строке
		/// </summary>
		public override string ToString() {
			return Text;
		}
	}
}
