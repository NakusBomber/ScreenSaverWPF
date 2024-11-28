using ScreenSaver.ViewModel.Bases;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Diagnostics;
using ScreenSaver.Model.Utils;
using System.Drawing;

namespace ScreenSaver.ViewModel.ViewModels;

public class SplashScreenViewModel : ViewModelBase
{
	public int Top { get; init; }
	public int Left { get; init; }	

	public int Height { get; init; }

	public int Width { get; init; }

	private BitmapSource _bitmap;
	public BitmapSource Bitmap
	{
		get => _bitmap;
		set
		{
			_bitmap = value;
			OnPropertyChanged();
		}
	}

	public SplashScreenViewModel(Rectangle rectangle, BitmapSource bitmap)
	{
		Top = rectangle.Top;
		Left = rectangle.Left;
		Height = rectangle.Height;
		Width = rectangle.Width;

		_bitmap = bitmap;
	}
}
