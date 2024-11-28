using ScreenSaver.ViewModel.Bases;
using System.Windows.Input;

namespace ScreenSaver.ViewModel.ViewModels.Controls;

public class DateTimeUpDownViewModel : ViewModelBase
{
	private Action? _actionOnValueChanged;

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

	public ICommand ValueChangedCommand { get; }

	public DateTimeUpDownViewModel(
		DateTime defaultValue, 
		DateTime? value = null,
		DateTime? minimum = null,
		DateTime? maximum = null,
		Action? actionOnValueChanged = null)
	{
		Value = value ?? defaultValue;
		DefaultValue = defaultValue;
		Minimum = minimum;
		Maximum = maximum;
		_actionOnValueChanged = actionOnValueChanged;

		ValueChangedCommand = new DelegateCommand(o => actionOnValueChanged?.Invoke());
	}
}
