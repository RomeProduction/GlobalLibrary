using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLibrary.Models {
	/// <summary>
	/// Класс для создания дерева с помощью jsTree
	/// </summary>
	public class TreeJs {
		/// <summary>
		/// родитель
		/// </summary>
		public string Parent;
		/// <summary>
		/// id элемента
		/// </summary>
		public string Id;
		/// <summary>
		/// текст отображения
		/// </summary>
		public string Text;
		/// <summary>
		/// Тип
		/// </summary>
		[DefaultValue("default")]
		public string Type;
	}
}
