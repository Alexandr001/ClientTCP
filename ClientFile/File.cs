using System;

namespace ProjectTCP.ClientFile
{
	public abstract class File
	{
		protected abstract string PathFolder { get; }
		public abstract void SaveFile(string nameFile, byte[] file);
		public bool Exists(string name) => System.IO.File.Exists(PathFolder + name);

		public static File FileFactory(string mode)
		{
			if (OperatingMode.BinFile == mode) {
				return new BinaryFile();
			}
			if (OperatingMode.TxtFile == mode) {
				return new TxtFile();
			}
			throw new Exception("Неправильный режим работы!");
		}
	}
}