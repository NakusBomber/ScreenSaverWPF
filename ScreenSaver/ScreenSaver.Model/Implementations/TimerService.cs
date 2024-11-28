using ScreenSaver.Model.Interfaces;
using System;
using System.Windows.Threading;

namespace ScreenSaver.Model.Implementations;

public class TimerService : ITimerService
{
	private DispatcherTimer _timer = new DispatcherTimer();

	public void StartIntervalTimer(TimeSpan interval, EventHandler eventHandler, bool autoReset = true)
	{
		StopTimer();

		_timer = new DispatcherTimer();
		_timer.Interval = interval;
		if (!autoReset)
		{
			_timer.Tick += (o, e) => StopTimer();
		}
		_timer.Tick += eventHandler;
		_timer.Start();
	}

	private void StopTimer()
	{
		_timer.Stop();
	}
}
