using ScreenSaver.ViewModel.Bases;

namespace ScreenSaver.ViewModel.ViewModels.Controls;

public class DateTimeUpDownViewModel : ViewModelBase
{
	public DateTime? Minimum { get; init; }
	public DateTime? Maximum { get; init; }
	public DateTime DefaultValue { get; init; }

	private DateTime _value;
	public DateTime Value
	{
		get => _value;
		set
		{
			_value = value;
			OnPropertyChanged();
		}
	}

	public DateTimeUpDownViewModel(
		DateTime defaultValue, 
		DateTime? value = null,
		DateTime? minimum = null,
		DateTime? maximum = null)
	{
		Value = value ?? defaultValue;
		DefaultValue = defaultValue;
		Minimum = minimum;
		Maximum = maximum;
	}
}
