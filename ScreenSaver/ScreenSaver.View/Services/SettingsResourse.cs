using ScreenSaver.Model.Interfaces;
using ScreenSaver.Model.Models;

namespace ScreenSaver.View.Services;

public class SettingsResourse : ISettingsSourse
{
	public string ImagePath
	{
		get => Settings.Default.ImagePath;
		set
		{
			Settings.Default.ImagePath = value;
			Save();
		}
	}
	public DateTime Interval
	{
		get => Settings.Default.Interval;
		set
		{
			Settings.Default.Interval = value;
			Save();
		}
	}
	public EWorkModes WorkMode
	{
		get => (EWorkModes)Settings.Default.WordMode;
		set
		{
			Settings.Default.WordMode = (int)value;
			Save();
		}
	}

	private void Save() => Settings.Default.Save();
}
