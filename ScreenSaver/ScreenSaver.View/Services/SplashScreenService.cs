using ScreenSaver.View.Windows;
using ScreenSaver.ViewModel.Interfaces;
using ScreenSaver.ViewModel.ViewModels;
using System.Windows;

namespace ScreenSaver.View.Services;

public class SplashScreenService : IWindowService<SplashScreenViewModel>
{
	public void Show(SplashScreenViewModel viewModel)
	{
		var window = new SplashScreenWindow();
		window.DataContext = viewModel;
		window.Top = viewModel.Top;
		window.Left = viewModel.Left;
		window.Width = viewModel.Width;
		window.Height = viewModel.Height;
		
		window.Show();
		
		window.WindowStyle = WindowStyle.None;
		window.Topmost = true;
	}

	public async Task ShowAsync(SplashScreenViewModel viewModel)
	{
		await Application.Current.Dispatcher.InvokeAsync(() => Show(viewModel));
	}
}
