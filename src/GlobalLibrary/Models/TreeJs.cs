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
		public string Parent { get; set; }
        /// <summary>
        /// id элемента
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// текст отображения
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Наличие дочерних записей
        /// </summary>
        public bool Children { get; set; }
		/// <summary>
		/// Тип
		/// </summary>
		[DefaultValue("default")]
		public string Type;
        /// <summary>
        /// Состояние узла
        /// </summary>
        public TreeJsState State { get; set; }
    }
    /// <summary>
    /// Состояние узла
    /// </summary>
    public class TreeJsState {
        /// <summary>
        /// Открыт
        /// </summary>
        public bool Opened { get; set; }
        /// <summary>
        /// Задизаблен
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// Выбран
        /// </summary>
        public bool Selected { get; set; }
    }
}
