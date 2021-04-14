using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using ControlModel;

namespace ControlViewModel.ModelViewModels
{
	public class ProjectViewModel: ModelViewModelBase
	{
		private Project _project;

		public ObservableCollection<FileDataViewModel>
			FileDataViewModels{ get; private set; }

		private FileDataViewModel _selectedFileDataViewModel;

		public FileDataViewModel SelectedFileDataViewModel
		{
			get
			{
				return _selectedFileDataViewModel;
			}
			set
			{
				_selectedFileDataViewModel = value;
				RaisePropertyChanged(nameof(SelectedFileDataViewModel));
			}
		}

		public ProjectViewModel()
		{
			FileDataViewModels = new ObservableCollection<
				FileDataViewModel>();
			_project = new Project();
		}

		public void AddFileDataViewModels(List<FileInfo> filePaths)
		{
			for(int i = 0; i < filePaths.Count; i++)
			{
				FileDataViewModel fileDataViewModel = 
					new FileDataViewModel(new FileData());
				FileDataViewModels.Add(fileDataViewModel);
				fileDataViewModel.FilePath = filePaths[i];
			}
		}
	}
}
