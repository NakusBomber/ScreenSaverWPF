using ScreenSaver.Model.Utils;
using ScreenSaver.ViewModel.Bases;
using ScreenSaver.ViewModel.Interfaces;
using ScreenSaver.ViewModel.ViewModels.Controls;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace ScreenSaver.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
	private IWindowService<MessageBoxViewModel> _messageBoxService;
	private IScreenSaverService _screenSaverService;
	
	public DateTimeUpDownViewModel DateTimeUpDownViewModel { get; set; }
	public ICommand OpenSettingsWindowCommand { get; }
	public ICommand OpenInfoWindowCommand { get; }

	public ICommand TestSplashScreenCommand { get; }

	public MainViewModel(
		IWindowService<MessageBoxViewModel> messageBoxService, 
		IScreenSaverService screenSaverService)
	{
		_messageBoxService = messageBoxService;
		_screenSaverService = screenSaverService;

		var defaultValue = new DateTime(new DateOnly(), new TimeOnly(0, 0, 30));
		var minimum = new DateTime(new DateOnly(), new TimeOnly(0, 0, 10));
		DateTimeUpDownViewModel = new DateTimeUpDownViewModel(
			defaultValue,
			minimum: minimum,
			actionOnValueChanged: IntervalChanged);
		
		OpenSettingsWindowCommand = new DelegateCommand(OpenSettingsWindow);
		OpenInfoWindowCommand = new DelegateCommand(OpenInfoWindow);
		TestSplashScreenCommand = new DelegateCommand(Test);

		IntervalChanged();
	}

	private void IntervalChanged()
	{
		var dateTime = DateTimeUpDownViewModel.Value;
		_screenSaverService.SetInterval(new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second));
	}

	private void Test(object? obj)
	{
		_screenSaverService.OpenSplashScreen();
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
