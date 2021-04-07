using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ControlViewModel.Commands;
using ControlViewModel.Services;
using ControlViewModel.ModelViewModels;
using ControlModel;

namespace ControlViewModel.WindowViewModels
{
    public class ControlWindowViewModel: ViewModelBase
    {
        private Project _project;

        public ObservableCollection<FileDataViewModel> 
            FileDataViewModels { get; private set; }

        private IFileDialogService _fileDialogService;

        private FileDataViewModel _selectedFileDataViewModel;

        public ControlWindowViewModel(IFileDialogService fileDialogService)
		{
            _project = new Project();
            FileDataViewModels = new ObservableCollection<
                FileDataViewModel>();
            _fileDialogService = fileDialogService;
		}

        public FileDataViewModel SelectedFileDataViewModel
		{
			get
			{
                return _selectedFileDataViewModel;
			}
			set
			{
                _selectedFileDataViewModel = value;
                OnPropertyChanged(nameof(SelectedFileDataViewModel));
			}
		}

        private RelayCommand _addFileCommand;

        public RelayCommand AddFileCommand
        {
            get
            {
                return _addFileCommand ??
                 (_addFileCommand = new RelayCommand(obj =>
                 {
                     if(_fileDialogService.AddFileDialog())
                     {
                         FileDataViewModel fileDataViewModel = 
                            new FileDataViewModel(new FileData());
                         fileDataViewModel.FilePath = _fileDialogService.FilePath;
                         _project.AddFile(fileDataViewModel.File);
                         FileDataViewModels.Add(fileDataViewModel);
					 }
                 }));
            }
        }

        private RelayCommand _removeFileCommand;

        public RelayCommand RemoveCommand
		{
			get
			{
                return _removeFileCommand ??
                 (_removeFileCommand = new RelayCommand(obj =>
                 {
                     
                 }));
            }
		}
    }
}
