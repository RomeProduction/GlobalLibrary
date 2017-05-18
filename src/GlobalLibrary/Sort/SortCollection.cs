using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLibrary.Sort {
	/// <summary>
	/// Сортировки
	/// </summary>
	public static class SortCollection {
		/// <summary>
		/// Быстрая сортировка
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="mas"></param>
		/// <param name="startIndex"></param>
		/// <param name="lastIndex"></param>
		/// <returns></returns>
		public static IEnumerable<T> QSort<T>(this IEnumerable<T> mas, int startIndex = 0, int lastIndex = 0) where T : struct {
			T temp;
			var array = mas.ToArray();
			if (lastIndex == 0) {
				lastIndex = array.Length - 1;
			}
			T x = array[startIndex + (lastIndex - startIndex) / 2];
			//запись эквивалентна (l+r)/2, 
			//но не вызввает переполнения на больших данных
			int i = startIndex;
			int j = lastIndex;
			//код в while обычно выносят в процедуру particle
			while (i <= j) {
				while (Comparer<T>.Default.Compare(array[i], x) < 0)
					i++;
				while (Comparer<T>.Default.Compare(array[j], x) > 0)
					j--;
				if (i <= j) {
					temp = array[i];
					array[i] = array[j];
					array[j] = temp;
					i++;
					j--;
				}
			}
			if (i < lastIndex) {
				array = QSort(array.AsEnumerable(), i, lastIndex).ToArray();
			}

			if (startIndex < j) {
				array = QSort(array.AsEnumerable(), startIndex, j).ToArray();
			}

			mas = array;
			return array;
		}

		/// <summary>
		/// Быстрая сортировка
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="mas"></param>
		/// <param name="startIndex"></param>
		/// <param name="lastIndex"></param>
		/// <returns></returns>
		public async static Task<IEnumerable<T>> QSortAsync<T>(this IEnumerable<T> mas, int startIndex = 0, int lastIndex = 0) where T : struct {
			T temp;
			var array = mas.ToArray();
			if (lastIndex == 0) {
				lastIndex = array.Length - 1;
			}
			T x = array[startIndex + (lastIndex - startIndex) / 2];
			//запись эквивалентна (l+r)/2, 
			//но не вызввает переполнения на больших данных
			int i = startIndex;
			int j = lastIndex;
			//код в while обычно выносят в процедуру particle
			while (i <= j) {
				while (Comparer<T>.Default.Compare(array[i], x) < 0)
					i++;
				while (Comparer<T>.Default.Compare(array[j], x) > 0)
					j--;
				if (i <= j) {
					temp = array[i];
					array[i] = array[j];
					array[j] = temp;
					i++;
					j--;
				}
			}
			if (i < lastIndex) {
				array = await Task.Run(() => {
					return QSort(array.AsEnumerable(), i, lastIndex).ToArray();
				});
			}

			if (startIndex < j) {
				array = await Task.Run(() => {
					return QSort(array.AsEnumerable(), startIndex, j).ToArray();
				});
			}

			mas = array;
			return array;
		}

		/// <summary>
		/// Пузырьковая сортировка
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="mas"></param>
		/// <param name="startIndex"></param>
		/// <param name="lastIndex"></param>
		/// <returns></returns>
		public static IEnumerable<T> BubbleSort<T>(this IEnumerable<T> mas) where T : struct {

			var array = mas.ToArray();

			for (int i = 0; i < array.Length; i++) {
				for (int j = 0; j < array.Length; j++) {
					if (Comparer<T>.Default.Compare(array[j], array[j + 1]) > 0) {
						var temp = array[j + 1];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}

			mas = array;
			return array;
		}

		/// <summary>
		/// Сортировка слиянием
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="mas"></param>
		/// <returns></returns>
		public static IEnumerable<T> MergeSort<T>(this IEnumerable<T> mas) where T : struct {
			var array = mas.ToArray();
			if (array.Length == 1)
				return mas;
			int mid_point = array.Length / 2;
			return Merge(MergeSort(array.Take(mid_point).ToArray()).ToArray(), MergeSort(array.Skip(mid_point).ToArray()).ToArray());
		}

		/// <summary>
		/// Сортировка слиянием
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="mas"></param>
		/// <returns></returns>
		public async static Task<IEnumerable<T>> MergeSortAsync<T>(this IEnumerable<T> mas) where T : struct {
			var array = mas.ToArray();
			if (array.Length == 1)
				return mas;
			int mid_point = array.Length / 2;


			return await Task.Run(() => {
				return Merge(MergeSortAsync(array.Take(mid_point)).Result.ToArray(), MergeSortAsync(array.Skip(mid_point)).Result.ToArray());
			});
		}
		/// <summary>
		/// вспомогательный метод сортировки слиянием
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="mass1"></param>
		/// <param name="mass2"></param>
		/// <returns></returns>
		private static IEnumerable<T> Merge<T>(T[] mass1, T[] mass2) where T : struct {
			int a = 0, b = 0;
			T[] merged = new T[mass1.Length + mass2.Length];
			for (int i = 0; i < mass1.Length + mass2.Length; i++) {
				if (b.CompareTo(mass2.Length) < 0 && a.CompareTo(mass1.Length) < 0) {
					if (Comparer<T>.Default.Compare(mass1[a], mass2[b]) > 0) {
						merged[i] = mass2[b++];
					} else {
						merged[i] = mass1[a++];
					}
				} else {
					if (b < mass2.Length) {
						merged[i] = mass2[b++];
					} else {
						merged[i] = mass1[a++];
					}
				}
			}
			return merged;
		}
	}
}
