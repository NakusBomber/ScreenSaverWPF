using ScreenSaver.ViewModel.Bases;
using ScreenSaver.ViewModel.Interfaces;
using ScreenSaver.ViewModel.ViewModels.Controls;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace ScreenSaver.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
	private IWindowService<MessageBoxViewModel> _messageBoxService;
	private IWindowService<SplashScreenViewModel> _splashScreenService;

	public DateTimeUpDownViewModel DateTimeUpDownViewModel { get; set; }
	public ICommand OpenSettingsWindowCommand { get; }
	public ICommand OpenInfoWindowCommand { get; }

	public ICommand TestSplashScreenCommand { get; }

	public MainViewModel(
		IWindowService<MessageBoxViewModel> messageBoxService,
		IWindowService<SplashScreenViewModel> splashScreenService)
	{
		_messageBoxService = messageBoxService;
		_splashScreenService = splashScreenService;

		var defaultValue = new DateTime(new DateOnly(), new TimeOnly(0, 0, 30));
		DateTimeUpDownViewModel = new DateTimeUpDownViewModel(defaultValue);

		OpenSettingsWindowCommand = new DelegateCommand(OpenSettingsWindow);
		OpenInfoWindowCommand = new DelegateCommand(OpenInfoWindow);
		TestSplashScreenCommand = new DelegateCommand(Test);
	}

	private void Test(object? obj)
	{
		var screens = Screen.AllScreens;

		foreach (var screen in screens)
		{
			var vm = new SplashScreenViewModel(screen);

			_splashScreenService.Show(vm);
		}
	}
	private void OpenSettingsWindow(object? obj)
	{
		var vm = new MessageBoxViewModel("Settings", "No settings yet ＞︿＜");
		_messageBoxService.Show(vm);
	}
	private void OpenInfoWindow(object? obj)
	{
		var vm = new MessageBoxViewModel("Info", "Used package: \nExtended WPF Toolkit\n(https://github.com/xceedsoftware/wpftoolkit)");
		_messageBoxService.Show(vm);
	}
}
