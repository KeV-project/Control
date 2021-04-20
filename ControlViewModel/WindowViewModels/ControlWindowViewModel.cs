using System.IO;
using GalaSoft.MvvmLight.Command;
using ControlViewModel.Services;
using System.Collections.ObjectModel;
using ViewModelLib;
using ControlViewModel.ModelViewModels;
using ControlModel;

namespace ControlViewModel.WindowViewModels
{
    /// <summary>
    /// Класс <see cref="ControlWindowViewModel"/> предназачен
    /// для организации взаимодействия модели и представления
    /// главного окна приложения
    /// </summary>
    public class ControlWindowViewModel: NotifyDataErrorViewModelBase
    {
        /// <summary>
        /// Хранит минимальную высоту кнопки
        /// </summary>
        private const double MIN_BUTTON_HEIGHT = 50;

        /// <summary>
        /// Хранит максимальную высоту элемента ListBox
        /// </summary>
        private double _maxListBoxHeight = 0;

        /// <summary>
        /// Возвращает и устанавливает максимальную высоту ListBox
        /// </summary>
        public double MaxListBoxHeigth
        {
            get
            {
                return _maxListBoxHeight;
            }
            set
            {
                Set(ref _maxListBoxHeight, value);
            }
        }

        /// <summary>
        /// Хранит сервис для взаимодействия с окном для выбора файлов
        /// </summary>
        private IFileDialogService _fileDialogService;

        /// <summary>
		/// Возвращает и устанавливает список ViewModels объектов
		/// класса <see cref="FileData"/>
		/// </summary>
		public ObservableCollection<FileDataViewModel>
            FileDataViewModels
            { get; private set; }

        /// <summary>
        /// Хранит текущую ViewModel класса <see cref="FileData"/>
        /// </summary>
        private FileDataViewModel _selectedFileDataViewModel;

        /// <summary>
        /// Возвращает и устанавливает текущую ViewModel
        /// класса <see cref="FileData"/>
        /// </summary>
        public FileDataViewModel SelectedFileDataViewModel
        {
            get
            {
                return _selectedFileDataViewModel;
            }
            set
            {
                Set(ref _selectedFileDataViewModel, value);
            }
        }

        /// <summary>
        /// Инициализирует свойства объекта класса
        /// </summary>
        /// <param name="fileDialogService">Сервис для взаимодействия с
        /// окном для выбора файлов</param>
        public ControlWindowViewModel(IFileDialogService fileDialogService)
		{
            FileDataViewModels = new ObservableCollection<
                FileDataViewModel>();
            _fileDialogService = fileDialogService;
		}

        /// <summary>
        /// Хранит команду изменения максимальной высоты ListBox
        /// </summary>
		private RelayCommand<double> _changeMaxListBoxHeight;

        /// <summary>
        /// Возвращает команду изменения максимальной высоты ListBox
        /// </summary>
		public RelayCommand<double> ChangeMaxListBoxHeight
		{
			get
			{
				return _changeMaxListBoxHeight ??
				 (_changeMaxListBoxHeight = new RelayCommand<double>(
					 gridHeight =>
				 {
                     MaxListBoxHeigth = gridHeight - MIN_BUTTON_HEIGHT;
                 }));
			}
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
                         foreach (FileInfo filePath in 
                            _fileDialogService.FilePaths)
                         {
                             FileDataViewModel fileDataViewModel =
                                 new FileDataViewModel(new FileData());
                             FileDataViewModels.Add(fileDataViewModel);
                             fileDataViewModel.FilePath = filePath;
                         }
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
                     FileDataViewModels.Remove(fileDataViewModel);
                 }));
            }
		}
    }
}
