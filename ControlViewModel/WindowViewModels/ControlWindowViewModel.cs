using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlViewModel.Commands;
using ControlViewModel.Services;

namespace ControlViewModel.WindowViewModels
{
    public class ControlWindowViewModel: ViewModelBase
    {
        private IFileDialogService _fileDialogService;

        public ControlWindowViewModel(IFileDialogService fileDialogService)
		{
            _fileDialogService = fileDialogService;
		}

        private RelayCommand _addFileCommand;

        public RelayCommand AddFileCommand
        {
            get
            {
                return _addFileCommand ??
                 (_addFileCommand = new RelayCommand(obj =>
                 {
                     
                 }));
            }
        }
    }
}
