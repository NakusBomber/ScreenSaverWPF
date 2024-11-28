namespace ScreenSaver.Model.Interfaces;

public interface IActivityDetector
{
	public bool NoActivityMoreThan(TimeSpan interval);
	public bool HasDetected();
}
