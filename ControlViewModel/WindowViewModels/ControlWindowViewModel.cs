﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ControlViewModel.Commands;
using ControlViewModel.Services;
using ControlModel;

namespace ControlViewModel.WindowViewModels
{
    public class ControlWindowViewModel: ViewModelBase
    {
        private Project _project;

        public ObservableCollection<FileData> Files { get; private set; }

        private IFileDialogService _fileDialogService;

        private string _selectedFile;

        public ControlWindowViewModel(IFileDialogService fileDialogService)
		{
            _project = new Project();
            Files = new ObservableCollection<FileData>();
            _fileDialogService = fileDialogService;
		}

        public string SelectedFile
		{
			get
			{
                return _selectedFile;
			}
			set
			{
                _selectedFile = value;
                OnPropertyChanged(nameof(SelectedFile));
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
                         _project.AddFile(new FileData(_fileDialogService.FilePath));
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
