using System.Windows.Media.Imaging;

namespace ScreenSaver.Model.Interfaces;

public interface IImageProvider
{
	public BitmapSource GetImage();
}
