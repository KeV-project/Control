using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlModel;

namespace ControlViewModel.ModelViewModels
{
	public class FileDataViewModel: ModelViewModelBase
	{
		private FileData _file;

		public FileInfo FilePath
		{
			get
			{
				return _file.FilePath;
			}
			set
			{
				try
				{
					_file.FilePath = value;
					RemoveError(nameof(FilePath));
				}
				catch(ArgumentException ex)
				{
					AddError(nameof(FilePath), ex.Message);
				}

				OnPropertyChanged(nameof(FilePath));
			}
		}

		public FileDataViewModel(FileData file)
		{
			_file = file;
		}
	}
}
