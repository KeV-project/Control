using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlModel
{
	public class FileData
	{
		private FileInfo _filePath;

		public FileInfo FilePath
		{
			get
			{
				return _filePath;
			}
			set
			{
				_filePath = value;
				ValueValidator.AssertCorrectFile(_filePath);
			}
		}

		public string FileName { get => _filePath.Name; }

		public FileData(FileInfo filePath)
		{
			FilePath = filePath;
		}
	}
}
