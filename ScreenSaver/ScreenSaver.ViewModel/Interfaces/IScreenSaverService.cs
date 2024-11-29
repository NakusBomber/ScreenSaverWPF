namespace ScreenSaver.ViewModel.Interfaces;

public interface IScreenSaverService
{
	public void SetInterval(TimeSpan interval);

	public void OpenSplashScreen();
}
