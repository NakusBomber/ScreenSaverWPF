using ScreenSaver.Model.Interfaces;
using System.Windows.Media.Imaging;

namespace ScreenSaver.Model.Implementations;

public class FileImageProvider : IImageProvider
{
	private string _imagePath;

	public FileImageProvider(string imagePath)
	{
		_imagePath = imagePath;
	}

	public BitmapSource GetImage() => new BitmapImage(new Uri(_imagePath));
}
