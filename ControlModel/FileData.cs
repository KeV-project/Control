using System.IO;

namespace ControlModel
{
	/// <summary>
	/// Класс <see cref="FileData"/> хринт информацию о файле
	/// </summary>
	public class FileData
	{
		/// <summary>
		/// Хранит полный путь к файлу
		/// </summary>
		private FileInfo _filePath;

		/// <summary>
		/// Возвращает и устанавливает полный путь к файлу
		/// </summary>
		public FileInfo FilePath
		{
			get
			{
				return _filePath;
			}
			set
			{
				_filePath = value;
				if(value != null)
				{
					ValueValidator.AssertCorrectFileExtension(_filePath);
				}
			}
		}

		/// <summary>
		/// Возвращает имя файла
		/// </summary>
		public string FileName => _filePath.Name;

		/// <summary>
		/// Инициализирует свойства объекта значениями по умолчанию
		/// </summary>
		public FileData(): this(null) { }

		/// <summary>
		/// Инициализирует свойства объекта
		/// </summary>
		/// <param name="filePath"></param>
		public FileData(FileInfo filePath)
		{
			FilePath = filePath;
		}
	}
}
