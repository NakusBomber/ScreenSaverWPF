using ScreenSaver.Model.Interfaces;
using System.IO;
using System.Windows.Media;

namespace ScreenSaver.Model.Implementations;

public class ImageProviderFactory : IImageProviderFactory
{
	private int? _height;
	private int? _width;
	private Color? _color;

	private string? _imagePath;

	public IImageProvider Build()
	{
		if (!string.IsNullOrEmpty(_imagePath) && File.Exists(_imagePath))
		{
			return new FileImageProvider(_imagePath);
		}

		if (_height != null && _width != null && _color != null)
		{
			return new SolidColorImageProvider((int)_height, (int)_width, (Color)_color);
		}

		throw new NotImplementedException();
	}

	public IImageProviderFactory SetFilePath(string? imagePath)
	{
		_imagePath = imagePath;

		return this;
	}

	public IImageProviderFactory SetSolidColor(int height, int width, Color color)
	{
		_height = height;
		_width = width;
		_color = color;

		return this;
	}
}
