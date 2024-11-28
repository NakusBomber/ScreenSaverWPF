using ScreenSaver.ViewModel.Interfaces;
using ScreenSaver.ViewModel.ViewModels;
using System.Windows;

namespace ScreenSaver.View.Services;

public class MessageBoxService : IWindowService<MessageBoxViewModel>
{
	public void Show(MessageBoxViewModel viewModel)
	{
		var window = new Dialogs.MessageBox();
		window.DataContext = viewModel;

		window.ShowDialog();
	}

	public async Task ShowAsync(MessageBoxViewModel viewModel)
	{
		await Application.Current.Dispatcher.InvokeAsync(() => Show(viewModel));
	}
}
