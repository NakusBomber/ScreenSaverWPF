using ScreenSaver.Model.Utils;
using ScreenSaver.ViewModel.Interfaces;
using ScreenSaver.ViewModel.ViewModels;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows;
using System.Drawing;
using System.Windows.Threading;
using ScreenSaver.Model.Interfaces;

namespace ScreenSaver.ViewModel.Services;

public class ScreenSaverService : IScreenSaverService
{
	private readonly IWindowService<SplashScreenViewModel, Window> _splashScreenService;
	private readonly ITimerService _timerService;
	private readonly IActivityDetector _activityDetector;

	private TimeSpan _openTimerInterval = new TimeSpan(0, 0, 1);
	private TimeSpan _closeTimerInterval = new TimeSpan(0, 0, 0, 0, 50);
	private TimeSpan? _lastInterval;
	private List<Window> _openedWindows = new List<Window>();
	
	private bool _isActive = false;

	public ScreenSaverService(
		IActivityDetector activityDetector,
		ITimerService timerService,
		IWindowService<SplashScreenViewModel, Window> splashScreenService)
	{
		_activityDetector = activityDetector;
		_timerService = timerService;
		_splashScreenService = splashScreenService;
	}

	private void OpenWindows()
	{
		var screens = Screen.AllScreens;

		foreach (var screen in screens)
		{
			var ratio = Math.Max(Screen.PrimaryScreen!.WorkingArea.Width / SystemParameters.PrimaryScreenWidth,
							Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.PrimaryScreenHeight);

			var left = (int)(screen.Bounds.Left / ratio);
			var top = (int)(screen.Bounds.Top / ratio);
			var width = (int)(screen.Bounds.Width / ratio);
			var height = (int)(screen.Bounds.Height / ratio);

			var rectangle = new Rectangle(left, top, width, height);
			var bitmap = MediaUtils.SolidColorBitmap(height, width, Colors.Black);

			var vm = new SplashScreenViewModel(rectangle, bitmap);
			var window = _splashScreenService.Show(vm);
			_openedWindows.Add(window);
		}

	}

	private void CloseWindows()
	{
		for (int i = 0; i < _openedWindows.Count; i++)
		{
			_openedWindows.ElementAt(i)?.Close();
		}

		_openedWindows = new List<Window>();
	}
	private void CloseEventHandler(object? obj, EventArgs e)
	{
		if (_isActive && _activityDetector.HasDetected())
		{
			_isActive = false;
			CloseWindows();
			_timerService.StartIntervalTimer(_openTimerInterval, OpenEventHandler);
		}
	}

	private void OpenEventHandler(object? obj, EventArgs e)
	{
		if (!_isActive && 
			_lastInterval != null &&
			_activityDetector.NoActivityMoreThan((TimeSpan)_lastInterval))
		{
			OpenSplashScreen();
		}
	}

	public void SetInterval(TimeSpan interval)
	{
		_lastInterval = interval;

		_timerService.StartIntervalTimer(_openTimerInterval, OpenEventHandler);
	}

	public void OpenSplashScreen()
	{
		void timerDelay(object? obj, EventArgs e)
		{
			_activityDetector.HasDetected();
			_timerService.StartIntervalTimer(_closeTimerInterval, CloseEventHandler);
		}

		if (!_isActive)
		{
			_isActive = true;
			OpenWindows();
			var delayInterval = new TimeSpan(0, 0, 1);
			_timerService.StartIntervalTimer(delayInterval, timerDelay, false);
		}
	}
}
