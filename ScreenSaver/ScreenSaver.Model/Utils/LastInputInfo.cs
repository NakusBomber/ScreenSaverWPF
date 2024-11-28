using System.Runtime.InteropServices;

namespace ScreenSaver.Model.Utils;

[StructLayout(LayoutKind.Sequential)]
internal struct LASTINPUTINFO
{
	// Size struture in bytes
	public uint cbSize;

	// Time last input in millis (start on startup system)
	public uint dwTime;
}
