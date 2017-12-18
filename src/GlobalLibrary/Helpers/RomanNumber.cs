using System.Collections.Generic;

namespace GlobalLibrary.Helpers {
	/// <summary>
	/// Конвертер римских цифр
	/// </summary>
	public static class RomanNumber {
		/// <summary>
		/// Основные римские цифры
		/// </summary>
		private static Dictionary<char, int> CharValues = new Dictionary<char, int>() {
			{'I', 1},
			{'V', 5},
			{'X', 10},
			{'L', 50},
			{'C', 100},
			{'D', 500},
			{'M', 1000}
		};

		/// <summary>
		/// Конвертирование римских цифр в целые числа
		/// </summary>
		/// <param name="roman"></param>
		/// <returns></returns>
		public static int RomanToArabic(string roman) {
			if (roman.Length == 0) {
				return 0;
			}
			roman = roman.ToUpper();

			// See if the number begins with (.
			if (roman[0] == '(') {
				// Find the closing parenthesis.
				int pos = roman.LastIndexOf(')');

				// Get the value inside the parentheses.
				string part1 = roman.Substring(1, pos - 1);
				string part2 = roman.Substring(pos + 1);
				return 1000 * RomanToArabic(part1) + RomanToArabic(part2);
			}

			// The number doesn't begin with (.
			// Convert the letters' values.
			int total = 0;
			int last_value = 0;
			for (int i = roman.Length - 1; i >= 0; i--) {
				int new_value = CharValues[roman[i]];

				// See if we should add or subtract.
				if (new_value < last_value)
					total -= new_value;
				else {
					total += new_value;
					last_value = new_value;
				}
			}

			return total;
		}
	}
}
