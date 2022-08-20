namespace ProjectTCP.ClientFile
{
	public class TxtFile : File
	{
		public string PathFolder { get; } = @"C:\Users\Adilya\RiderProjects\ProjectTCP\Client\TxtFile\";
		public void SaveFile(string nameFile, byte[] file)
		{
			System.IO.File.WriteAllBytes(PathFolder + nameFile, file);
		}
	}
}