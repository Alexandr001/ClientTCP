using System;

namespace ProjectTCP
{
	public static class OperatingMode
	{
		public static string TxtFile
		{
			get { return Convert.ToString((int) Mode.TXT_FILES); }
		}
		public static string BinFile
		{
			get { return Convert.ToString((int) Mode.BIN_FILES); }
		}
	}
}