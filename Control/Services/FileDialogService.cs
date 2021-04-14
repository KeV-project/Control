using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;
using ControlViewModel.Services;

namespace ControlView.Services
{
	public class FileDialogService: IFileDialogService
	{
        private List<FileInfo> _filePaths;

        public List<FileInfo> FilePaths => _filePaths;

        public bool AddFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                _filePaths = new List<FileInfo>();
                for(int i = 0; i < openFileDialog.FileNames.Length; i++)
				{
                    _filePaths.Add(new FileInfo(openFileDialog.FileNames[i]));
				}
                return true;
            }
            return false;
        }
    }
}
