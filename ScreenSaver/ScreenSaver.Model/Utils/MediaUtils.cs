using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace ScreenSaver.Model.Utils;

public static class MediaUtils
{
	public static WriteableBitmap SolidColorBitmap(int height, int width, Color color)
	{
		var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Rgb24, null);
		var pixels = new byte[height * width * 3];

		for (int i = 0; i < pixels.Length; i += 3)
		{
			pixels[i] = color.R;
			pixels[i + 1] = color.G;
			pixels[i + 2] = color.B;
		}

		bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * 3, 0);

		return bitmap;
	}
}
