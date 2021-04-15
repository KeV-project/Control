using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ViewModelLib;
using ControlModel;

namespace ControlViewModel.ModelViewModels
{
	/// <summary>
	/// Класс <see cref="ProjectViewModel"/> предназначен для
	/// организации взаимодействия с объектом класса <see cref="Project"/>
	/// </summary>
	public class ProjectViewModel: NotifyDataErrorViewModelBase
	{
		/// <summary>
		/// Возвращает и устанавливает список ViewModels объектов
		/// класса <see cref="FileData"/>
		/// </summary>
		public ObservableCollection<FileDataViewModel>
			FileDataViewModels{ get; private set; }

		/// <summary>
		/// Хранит текущую ViewModel класса <see cref="FileData"/>
		/// </summary>
		private FileDataViewModel _selectedFileDataViewModel;

		/// <summary>
		/// Возвращает и устанавливает текущую ViewModel
		/// класса <see cref="FileData"/>
		/// </summary>
		public FileDataViewModel SelectedFileDataViewModel
		{
			get
			{
				return _selectedFileDataViewModel;
			}
			set
			{
				//TODO: Set(ref _selectedFileDataViewModel, value);
				_selectedFileDataViewModel = value;
				RaisePropertyChanged(nameof(SelectedFileDataViewModel));
			}
		}

		/// <summary>
		/// Инициализирует свойства объекта класса
		/// </summary>
		public ProjectViewModel()
		{
			FileDataViewModels = new ObservableCollection<
				FileDataViewModel>();
		}

		/// <summary>
		/// Добавляет новые ViewModels класса <see cref="FileData"/>
		/// в список ViewModel проекта
		/// </summary>
		/// <param name="filePaths">Добавляемая ViewModel</param>
		public void AddFileDataViewModels(List<FileInfo> filePaths)
		{
			//TODO: foreach?
			for(int i = 0; i < filePaths.Count; i++)
			{
				FileDataViewModel fileDataViewModel = 
					new FileDataViewModel(new FileData());
				FileDataViewModels.Add(fileDataViewModel);
				fileDataViewModel.FilePath = filePaths[i];
			}
		}

		/// <summary>
		/// Удаляет ViewModel класса <see cref="FileData"/>
		/// из списка ViewModel проекта
		/// </summary>
		/// <param name="fileDataViewModel">Удаляемая ViewModel</param>
		public void RemoveFileDataViewModel(
			FileDataViewModel fileDataViewModel)
		{
			FileDataViewModels.Remove(fileDataViewModel);
		}
	}
}
