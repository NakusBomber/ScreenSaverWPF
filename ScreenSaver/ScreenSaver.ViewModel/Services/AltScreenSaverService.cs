using ScreenSaver.Model.Implementations;
using ScreenSaver.Model.Interfaces;
using ScreenSaver.Model.Utils;
using ScreenSaver.ViewModel.Interfaces;

namespace ScreenSaver.ViewModel.Services;

public class AltScreenSaverService : IScreenSaverService
{
	private readonly IActivityDetector _activityDetector;
	private readonly ITimerService _timerService;

	private TimeSpan _openTimerInterval = new TimeSpan(0, 0, 1);
	private TimeSpan? _lastInterval;

	public AltScreenSaverService(
		IActivityDetector activityDetector,
		ITimerService timerService)
	{
		_activityDetector = activityDetector;
		_timerService = timerService;
	}

	public void OpenSplashScreen()
	{
		MonitorController.Off();

		if (_lastInterval != null)
		{
			SetInterval((TimeSpan)_lastInterval);
		}
	}

	public void SetImagePath(string imagePath)
	{
	}

	public void SetInterval(TimeSpan interval)
	{
		_lastInterval = interval;

		_timerService.StartIntervalTimer(_openTimerInterval, OpenEventHandler);
	}

	private void OpenEventHandler(object? obj, EventArgs e)
	{
		if (_lastInterval != null &&
			_activityDetector.NoActivityMoreThan((TimeSpan)_lastInterval))
		{
			OpenSplashScreen();
		}
	}
}
