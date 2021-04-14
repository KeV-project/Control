using GalaSoft.MvvmLight.Command;
using ControlViewModel.Services;
using ControlViewModel.ModelViewModels;
using ControlModel;

namespace ControlViewModel.WindowViewModels
{
    /// <summary>
    /// Класс <see cref="ControlWindowViewModel"/> предназачен
    /// для организации взаимодействия модели и представления
    /// главного окна приложения
    /// </summary>
    public class ControlWindowViewModel
    {
        /// <summary>
        /// Возвращает и устанавливает ViewModel для объекта
        /// класса <see cref="Project"/>
        /// </summary>
        public ProjectViewModel ProjectViewModel { get; private set; }

        /// <summary>
        /// Хранит сервис для взаимодействия с окном для выбора файлов
        /// </summary>
        private IFileDialogService _fileDialogService;

        /// <summary>
        /// Инициализирует свойства объекта класса
        /// </summary>
        /// <param name="fileDialogService">Сервис для взаимодействия с
        /// окном для выбора файлов</param>
        public ControlWindowViewModel(IFileDialogService fileDialogService)
		{
            ProjectViewModel = new ProjectViewModel();
            _fileDialogService = fileDialogService;
		}

        /// <summary>
        /// Хранит команду добавления файла
        /// </summary>
        private RelayCommand _addFilesCommand;

        /// <summary>
        /// Возвращает команду добавления файла
        /// </summary>
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

        /// <summary>
        /// Хранит команду удаления файла
        /// </summary>
        private RelayCommand<FileDataViewModel> _removeFileCommand;

        /// <summary>
        /// Возвращает команду удаления файла
        /// </summary>
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
