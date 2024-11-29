using ScreenSaver.Model.Interfaces;
using ScreenSaver.Model.Utils;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ScreenSaver.Model.Implementations;

public class SolidColorImageProvider : IImageProvider
{
	private int _height;
	private int _width;
	private Color _color;

	public SolidColorImageProvider(int height, int width, Color color)
	{
		_height = height;
		_width = width;
		_color = color;
	}
	
	public BitmapSource GetImage() => MediaUtils.SolidColorBitmap(_height, _width, _color);
}
