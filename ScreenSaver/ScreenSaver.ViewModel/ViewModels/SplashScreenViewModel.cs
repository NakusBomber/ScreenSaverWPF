using ScreenSaver.ViewModel.Bases;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Diagnostics;

namespace ScreenSaver.ViewModel.ViewModels;

public class SplashScreenViewModel : ViewModelBase
{
	
	public int Top { get; init; }
	public int Left { get; init; }	

	public int Height { get; init; }

	public int Width { get; init; }

	private WriteableBitmap _bitmap;
	public WriteableBitmap Bitmap
	{
		get => _bitmap;
		set
		{
			_bitmap = value;
			OnPropertyChanged();
		}
	}

	public SplashScreenViewModel(Screen screen)
	{
		Debug.Print(screen.DeviceName);
		Debug.Print(screen.WorkingArea.Width.ToString());
		Debug.Print(screen.WorkingArea.Height.ToString());
		Debug.Print(screen.Bounds.Width.ToString());
		Debug.Print(screen.Bounds.Height.ToString());

		var ratio = Math.Max(Screen.PrimaryScreen!.WorkingArea.Width / SystemParameters.PrimaryScreenWidth,
							Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.PrimaryScreenHeight);

		Left = (int)(screen.Bounds.Left / ratio);
		Top = (int)(screen.Bounds.Top / ratio);
		Width = (int)(screen.Bounds.Width / ratio);
		Height = (int)(screen.Bounds.Height / ratio);

		_bitmap = CreateBitmap(Height, Width);
	}


	private WriteableBitmap CreateBitmap(int height, int width)
	{
		var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Rgb24, null);
		var pixels = new byte[height * width * 3];

		for (int i = 0; i < pixels.Length; i += 3)
		{
			pixels[i] = 255; 
			pixels[i + 1] = 0; 
			pixels[i + 2] = 0;
		}

		bitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, width * 3, 0);

		return bitmap;
	}
}
