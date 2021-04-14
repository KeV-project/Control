using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ControlViewModel.Services;
using ControlViewModel.ModelViewModels;
using ControlModel;

namespace ControlViewModel.WindowViewModels
{
    public class ControlWindowViewModel
    {
        public ProjectViewModel ProjectViewModel { get; private set; }

        private IFileDialogService _fileDialogService;

        public ControlWindowViewModel(IFileDialogService fileDialogService)
		{
            ProjectViewModel = new ProjectViewModel();
            _fileDialogService = fileDialogService;
		}

        private RelayCommand _addFilesCommand;

        public RelayCommand AddFilesCommand
        {
            get
            {
                return _addFilesCommand ??
                 (_addFilesCommand = new RelayCommand(() =>
                 {
                     if(_fileDialogService.AddFileDialog())
                     {
                         ProjectViewModel.AddFileDataViewModels(
                             _fileDialogService.FilePaths);
					 }
                 }));
            }
        }

        private RelayCommand<FileDataViewModel> _removeFileCommand;

        public RelayCommand<FileDataViewModel> RemoveFileCommand
		{
			get
			{
                return _removeFileCommand ??
                 (_removeFileCommand = new RelayCommand<FileDataViewModel>(
                     fileDataViewModel =>
                 {
                     ProjectViewModel.RemoveFileDataViewModel(fileDataViewModel);
                 }));
            }
		}
    }
}
