
using ScreenSaver.Model.Models;

namespace ScreenSaver.Model.Interfaces;

public interface ISettingsSourse
{
	public string ImagePath { get; set; }
	public DateTime Interval { get; set; }
	public EWorkModes WorkMode { get; set; }
}
