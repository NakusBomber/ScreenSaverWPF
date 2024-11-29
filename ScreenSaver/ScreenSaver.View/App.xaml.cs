using Ninject;
using ScreenSaver.Model.Implementations;
using ScreenSaver.Model.Interfaces;
using ScreenSaver.View.Services;
using ScreenSaver.ViewModel.Interfaces;
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
		private IKernel _kernel = new StandardKernel();
		private bool _alt = false;

		private void RegisterServices()
		{
			_kernel.Bind<IWindowService<MessageBoxViewModel>>()
				.To<MessageBoxService>();
			_kernel.Bind<IWindowService<SplashScreenViewModel, Window>>()
				.To<SplashScreenService>();
			_kernel.Bind<IActivityDetector>().To<LastInputDetector>();
			_kernel.Bind<ITimerService>().To<TimerService>();

			if (_alt)
			{
				_kernel.Bind<IScreenSaverService>().To<AltScreenSaverService>();
			}
			else
			{
				_kernel.Bind<IScreenSaverService>().To<ScreenSaverService>();
			}
		
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			RegisterServices();
			_kernel.Bind<MainViewModel>().ToSelf();

			MainWindow = new MainWindow();
			MainWindow.DataContext = _kernel.Get<MainViewModel>();

			MainWindow.Show();
		}

	}

}
