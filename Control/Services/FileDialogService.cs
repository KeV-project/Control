using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;
using ControlViewModel.Services;

namespace ControlView.Services
{
    /// <summary>
    /// Класс <see cref="FileDialogService"/> предназначен для
    /// организации взаимодействия с окном для выбора файлов
    /// </summary>
	public class FileDialogService: IFileDialogService
	{
        /// <summary>
        /// Хранит список обхектов класса <see cref="FileInfo"/>
        /// </summary>
        private List<FileInfo> _filePaths;

        /// <summary>
        /// Возвращает список обхектов класса <see cref="FileInfo"/>
        /// </summary>
        public List<FileInfo> FilePaths => _filePaths;

        /// <summary>
        /// Открывает окно для выбора файлов
        /// </summary>
        /// <returns></returns>
        public bool AddFileDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() != true) return false;

            _filePaths = new List<FileInfo>();
            foreach (var fileName in openFileDialog.FileNames)
            {
                _filePaths.Add(new FileInfo(fileName));
            }
            return true;
        }
    }
}
