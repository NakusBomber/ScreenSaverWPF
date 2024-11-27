using ScreenSaver.ViewModel.Bases;
using ScreenSaver.ViewModel.ViewModels.Controls;

namespace ScreenSaver.ViewModel.ViewModels;

public class MainViewModel : ViewModelBase
{
	public DateTimeUpDownViewModel DateTimeUpDownViewModel { get; set; }

	public MainViewModel()
	{

		var defaultValue = new DateTime(new DateOnly(), new TimeOnly(0, 0, 30));
		DateTimeUpDownViewModel = new DateTimeUpDownViewModel(defaultValue);
	}
}
