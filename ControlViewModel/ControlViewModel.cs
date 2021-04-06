using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlViewModel.Commands;

namespace ControlViewModel
{
    public class ControlViewModel: ViewModelBase
    {
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
