using ScreenSaver.ViewModel.Bases;

namespace ScreenSaver.ViewModel.Interfaces;

public interface IWindowService<TViewModel> where TViewModel : ViewModelBase
{
	public void Show(TViewModel viewModel);
	public Task ShowAsync(TViewModel viewModel);
}
