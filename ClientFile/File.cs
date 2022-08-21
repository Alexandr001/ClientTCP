namespace ProjectTCP.ClientFile
{
	public abstract class File
	{
		protected abstract string PathFolder { get; }
		public abstract void SaveFile(string nameFile, byte[] file);
		public bool Exists(string name) => System.IO.File.Exists(PathFolder + name);
	}
}