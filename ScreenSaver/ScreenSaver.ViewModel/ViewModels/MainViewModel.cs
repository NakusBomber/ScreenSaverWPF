using ScreenSaver.Model.Interfaces;
using ScreenSaver.Model.Models;
using ScreenSaver.Model.Utils;
using ScreenSaver.ViewModel.Bases;
using ScreenSaver.ViewModel.Interfaces;
using ScreenSaver.ViewModel.ViewModels.Controls;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace ScreenSaver.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
	private readonly IWindowService<MessageBoxViewModel> _messageBoxService;
	private readonly IScreenSaverService _screenSaverService;
	private readonly IApplicationRestartService _applicationRestartService;
	private readonly ISettingsSourse _settings;

	private string? _imagePath;

	public string? ImagePath
	{
		get => _imagePath;
		set
		{
			_imagePath = value;
			ImagePathChanged();
			OnPropertyChanged();
		}
	}

	private EWorkModes _mode;
	public EWorkModes Mode
	{
		get => _mode;
		set
		{
			_mode = value;
			OnPropertyChanged();
		}
	}

	public DateTimeUpDownViewModel DateTimeUpDownViewModel { get; set; }
	public ICommand ChangeModeCommand { get; }
	public ICommand OpenInfoWindowCommand { get; }

	public ICommand TestSplashScreenCommand { get; }

	public MainViewModel(
		IWindowService<MessageBoxViewModel> messageBoxService, 
		IScreenSaverService screenSaverService,
		IApplicationRestartService applicationRestartService,
		ISettingsSourse settings)
	{
		_messageBoxService = messageBoxService;
		_screenSaverService = screenSaverService;
		_applicationRestartService = applicationRestartService;
		_settings = settings;


		var defaultValue = new DateTime(new DateOnly(), new TimeOnly(0, 0, 30));
		var minimum = new DateTime(new DateOnly(), new TimeOnly(0, 0, 10));
		DateTimeUpDownViewModel = new DateTimeUpDownViewModel(
			defaultValue,
			minimum: minimum,
			actionOnValueChanged: IntervalChanged);

		LoadDataFromSettings(minimum);

		ChangeModeCommand = new DelegateCommand(ChangeMode, (o) => o != null && Mode != (EWorkModes)o);
		OpenInfoWindowCommand = new DelegateCommand(OpenInfoWindow);
		TestSplashScreenCommand = new DelegateCommand(Test);

		IntervalChanged();
	}

	private void ImagePathChanged()
	{
		_imagePath = _imagePath?.Trim(' ', '"');
		_settings.ImagePath = _imagePath ?? string.Empty;
		_screenSaverService.SetImagePath(_imagePath ?? string.Empty);
	}

	private void IntervalChanged()
	{
		var dateTime = DateTimeUpDownViewModel.Value;
		_settings.Interval = dateTime;
		_screenSaverService.SetInterval(new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second));
	}

	private void Test(object? obj)
	{
		_screenSaverService.OpenSplashScreen();
	}

	private void ChangeMode(object? obj)
	{
		if (obj == null)
		{
			return;
		}

		var newMode = (EWorkModes)obj;

		_settings.WorkMode = newMode;
		_applicationRestartService.Restart();
	}

	private void LoadDataFromSettings(DateTime minimum)
	{
		Mode = _settings.WorkMode;
		ImagePath = _settings.ImagePath;
		if (_settings.Interval < minimum)
		{
			DateTimeUpDownViewModel.Value = minimum;
		}
		else
		{
			DateTimeUpDownViewModel.Value = _settings.Interval;
		}
	}

	private void OpenInfoWindow(object? obj)
	{
		var vm = new MessageBoxViewModel("Info", "Used package: \nExtended WPF Toolkit\n(https://github.com/xceedsoftware/wpftoolkit)");
		_messageBoxService.Show(vm);
	}
}
