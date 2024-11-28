using ScreenSaver.Model.Interfaces;
using ScreenSaver.Model.Utils;

namespace ScreenSaver.Model.Implementations;

public class LastInputDetector : IActivityDetector
{
	private uint _prevInputMillis = 0;

	public bool NoActivityMoreThan(TimeSpan interval)
	{
		return LastInputHelper.GetIdleMillis() > interval.TotalMilliseconds;
	}

	public bool HasDetected()
	{
		var lastInputMillis = LastInputHelper.GetLastInput();
		
		if (lastInputMillis != _prevInputMillis)
		{
			_prevInputMillis = lastInputMillis;
			return true;
		}

		return false;
	}
}
