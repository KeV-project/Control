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
		public FileData File { get; private set; }

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

		public string FileName { get => File.FileName; }

		public FileDataViewModel(FileData file)
		{
			File = file;
		}
	}
}
