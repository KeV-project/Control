using System;
using System.IO;
using System.Collections.Generic;

namespace ControlModel
{
	/// <summary>
	/// Класс <see cref="ValueValidator"/> предназначен для 
	/// проверки корректности значений
	/// </summary>
	public static class ValueValidator
	{
		/// <summary>
		/// Хранит список допустимых расширений
		/// </summary>
		private static readonly List<string> _extensions = 
			new List<string>()
		{
			".exe",
			".dll"
		};

		/// <summary>
		/// Выполняет проверку расширения файла
		/// </summary>
		/// <param name="filePath">Проверяемый файл</param>
		/// <returns>Возвращает true, если файд имеет допустимое
		/// расширение, иначе возвращает false</returns>
		private static bool IsCorrectFileExtension(FileInfo filePath)
		{
			foreach(string extension in _extensions)
			{
				if(filePath.Extension == extension)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Метод предназначен для генерации исключения, в случае,
		/// если файл имеет недопустимое расширение
		/// </summary>
		/// <param name="filePath">Проверяемый файл</param>
		public static void AssertCorrectFileExtension(FileInfo filePath)
		{ 
			if (!IsCorrectFileExtension(filePath))
			{
				//TODO: Тут бы формировал строку из списка расширений вместо того, чтобы дёргать по индексам
				//TODO: Вверху же уже есть список, зачем задавать его заново тут?)
				const string correctExtensions = "\".exe\", \".dll\"";
				throw new ArgumentException("Файл с именем \"" 
					+ filePath.Name + "\" имеет недопустимое расширение. " 
					+ "Допустимые расширения: " + correctExtensions);
			}
		}
	}
}
