using System.Windows.Media.Imaging;

namespace ScreenSaver.ViewModel.Interfaces;

public interface IScreenSaverService
{
	public void SetImagePath(string imagePath);
	public void SetInterval(TimeSpan interval);

	public void OpenSplashScreen();
}
