using System.Runtime.InteropServices;

namespace ScreenSaver.Model.Utils;

public static class MonitorController
{
	private const int _handleAllWindows = 0xFFFF;
	private const int _scMonitorPower = 0xF170;
	private const int _wmSysCommand = 0x0112;

	private enum MonitorState
	{
		On = -1,
		Off = 2,
		StandBy = 1
	}

	public static void Off() => SendCommand(MonitorState.Off);
	public static void On() => SendCommand(MonitorState.On);
	public static void StandBy() => SendCommand(MonitorState.StandBy);
	
	private static void SendCommand(MonitorState state)
	{
		PostMessage(_handleAllWindows, _wmSysCommand, _scMonitorPower, (IntPtr)state);
	}

	[DllImport("user32.dll")]
	private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
}
