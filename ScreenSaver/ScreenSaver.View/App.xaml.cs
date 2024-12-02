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

		private void RegisterServices()
		{
			_kernel.Bind<ISettingsSourse>().To<SettingsResourse>();
			_kernel.Bind<IWindowService<MessageBoxViewModel>>()
				.To<MessageBoxService>();
			_kernel.Bind<IWindowService<SplashScreenViewModel, Window>>()
				.To<SplashScreenService>();
			_kernel.Bind<IActivityDetector>().To<LastInputDetector>();
			_kernel.Bind<ITimerService>().To<TimerService>();
			_kernel.Bind<IImageProviderFactory>().To<ImageProviderFactory>();
			_kernel.Bind<IApplicationRestartService>().To<ApplicationRestartService>();

			var settings = _kernel.Get<ISettingsSourse>();
			if (settings.WorkMode == Model.Models.EWorkModes.ViewImage)
			{
				_kernel.Bind<IScreenSaverService>().To<ScreenSaverService>();
			}
			else
			{
				_kernel.Bind<IScreenSaverService>().To<AltScreenSaverService>();
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
