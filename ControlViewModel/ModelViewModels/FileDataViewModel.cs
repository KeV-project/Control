using System;
using System.IO;
using ViewModelLib;
using ControlModel;

namespace ControlViewModel.ModelViewModels
{
	/// <summary>
	/// Класс <see cref="FileDataViewModel"/> предназначен для
	/// корректного взаимодействия с объектом класса 
	/// <see cref="FileData"/>
	/// </summary>
	public class FileDataViewModel: NotifyDataErrorViewModelBase
	{
		/// <summary>
		/// Возвращает и устанавливает объект класса <see cref="FileData"/>
		/// </summary>
		public FileData File { get; private set; }

		/// <summary>
		/// Возвращает у устанавливает полный путь к файлу
		/// </summary>
		public FileInfo FilePath
		{
			get
			{
				return File.FilePath;
			}
			set
			{
				try
				{
					File.FilePath = value;
					RemoveError(nameof(FileName));
				}
				catch(ArgumentException ex)
				{
					AddError(nameof(FileName), ex.Message);
				}

				RaisePropertyChanged(nameof(FileName));
			}
		}
		
		/// <summary>
		/// Возвращает имя файла
		/// </summary>
		public string FileName { get => File.FileName; }

		/// <summary>
		/// Инициализирует свойства объекта класса
		/// </summary>
		/// <param name="file">Объект класса <see cref="FileData"/></param>
		public FileDataViewModel(FileData file)
		{
			File = file;
		}
	}
}
