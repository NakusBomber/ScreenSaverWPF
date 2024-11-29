using System.Windows.Media;

namespace ScreenSaver.Model.Interfaces;

public interface IImageProviderFactory
{
	public IImageProviderFactory SetSolidColor(int height, int width, Color color);
	public IImageProviderFactory SetFilePath(string? imagePath);
	public IImageProvider Build();
}
