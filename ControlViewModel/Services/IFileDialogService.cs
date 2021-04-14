using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControlViewModel.Services
{
	/// <summary>
	/// Интерфейс <see cref="IFileDialogService"/> предназначен 
	/// для создания сервиса, предоставляющего возвомность
	/// взаимодействия с окном для выбора файла
	/// </summary>
	public interface IFileDialogService
	{
		/// <summary>
		/// Возвращает список объектов класса <see cref="FileInfo"/>
		/// </summary>
		List<FileInfo> FilePaths { get; }

		/// <summary>
		/// Запускает окно для выбора файлов
		/// </summary>
		/// <returns>Возвращает true, в случае успешного 
		/// завершения работы окна, иначе возвращает false</returns>
		bool AddFileDialog();
	}
}
