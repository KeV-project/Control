using System;
using System.IO;

namespace ControlModel
{
	/// <summary>
	/// Класс <see cref="ValueValidator"/> предназначен для 
	/// проверки корректности значений
	/// </summary>
	public static class ValueValidator
	{
		/// <summary>
		/// Выполняет проверку разрешения файла
		/// </summary>
		/// <param name="filePath">Путь к файлу</param>
		/// <returns>Возвращает true, если файл имеет разрешение
		/// .exe, иначе позвращает false</returns>
		private static bool IsFileExe(FileInfo filePath)
		{
			const string extension = ".exe";
			return filePath.Extension == extension;
		}

		/// <summary>
		/// Выполняет проверку разрешения файла
		/// </summary>
		/// <param name="filePath">Путь к файлу</param>
		/// <returns>Возвращает true, если файл имеет разрешение
		/// .dll, иначе позвращает false</returns>
		private static bool IsFileDll(FileInfo filePath)
		{
			const string extension = ".dll";
			return filePath.Extension == extension;
		}

		/// <summary>
		/// Метод предназначен для генерации исключения, в случае,
		/// если файл имеет недопустимое расширение
		/// </summary>
		/// <param name="filePath">Проверяемый файл</param>
		public static void AssertCorrectFile(FileInfo filePath)
		{
			const string correctExtension = "Допустимые расширения: " 
				+ "\".exe\", \".dll\".";
			if (!(IsFileExe(filePath) || IsFileDll(filePath)))
			{
				throw new ArgumentException("Файл с именем \"" 
					+ filePath.Name + "\" имеет недопустимое расширение. " 
					+ correctExtension);
			}
		}
	}
}
