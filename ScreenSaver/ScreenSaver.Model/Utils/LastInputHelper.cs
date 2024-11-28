using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ScreenSaver.Model.Utils;

public static class LastInputHelper
{
	[DllImport("user32.dll")]
	private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

	public static uint GetLastInput()
	{
		LASTINPUTINFO lastInputInfo = new();
		lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
		var success = GetLastInputInfo(ref lastInputInfo);

		if (!success)
		{
			throw new Win32Exception(Marshal.GetLastWin32Error());
		}

		return lastInputInfo.dwTime;
	}

	public static uint GetIdleMillis()
	{
		return (uint)Environment.TickCount - GetLastInput();
	}
}