namespace ScreenSaver.ViewModel.Interfaces;

public interface IScreenSaverService
{
	public bool IsActive { get; }
	public void SetInterval(TimeSpan interval);

	public void OpenSplashScreen();
}
