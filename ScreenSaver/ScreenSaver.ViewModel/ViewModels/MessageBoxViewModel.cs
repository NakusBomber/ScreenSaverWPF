using ScreenSaver.ViewModel.Bases;
using System.Windows;
using System.Windows.Input;

namespace ScreenSaver.ViewModel.ViewModels;

public class MessageBoxViewModel : ViewModelBase
{
	private string _title;
	public string Title
	{
		get => _title;
		set
		{
			_title = value;
			OnPropertyChanged();
		}
	}

	private string _message;

	public string Message
	{
		get => _message;
		set
		{
			_message = value;
			OnPropertyChanged();
		}
	}

	public ICommand CloseCommand { get; }

	public MessageBoxViewModel(string title, string message)
	{
		_title = title;
		_message = message;

		CloseCommand = new DelegateCommand(o =>
		{
			var activeWindow = Application.Current.Windows.OfType<Window>().First(w => w.IsActive);
			activeWindow?.Close();
		});
	}
}
