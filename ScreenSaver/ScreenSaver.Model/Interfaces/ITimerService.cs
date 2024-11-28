namespace ScreenSaver.Model.Interfaces;

public interface ITimerService
{
	public void StartIntervalTimer(
		TimeSpan interval, 
		EventHandler eventHandler, 
		bool autoReset = true);
}
