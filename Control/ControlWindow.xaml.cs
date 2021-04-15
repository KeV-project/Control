using System.Windows;
using ControlViewModel.WindowViewModels;
using ControlView.Services;

namespace ControlView
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class ControlWindow : Window
	{
		public ControlWindow()
		{
			InitializeComponent();

			DataContext = new ControlWindowViewModel(
				new FileDialogService());
		}
	}
}
