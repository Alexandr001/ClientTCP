namespace ProjectTCP.ClientFile
{
	public interface File
	{
		string PathFolder { get; }
		void SaveFile(string nameFile, byte[] file);
	}
}