using ScreenSaver.Model.Implementations;
using ScreenSaver.View.Services;
using ScreenSaver.ViewModel.Services;
using ScreenSaver.ViewModel.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ScreenSaver.View
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private MainViewModel RegisterMainViewModel()
		{
			var messageBoxService = new MessageBoxService();
			var splashScreenService = new SplashScreenService();
			var lastInputDetector = new LastInputDetector();
			var timerService = new TimerService();
			var screenSaverService = new ScreenSaverService(
				lastInputDetector, 
				timerService,
				splashScreenService);

			return new MainViewModel(messageBoxService, screenSaverService);
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			MainWindow = new MainWindow();
			MainWindow.DataContext = RegisterMainViewModel();

			MainWindow.Show();
		}

	}

}
