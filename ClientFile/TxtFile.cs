namespace ProjectTCP.ClientFile
{
	public class TxtFile : File
	{
		protected override string PathFolder { get; } = @"C:\Users\Adilya\RiderProjects\ProjectTCP\Client\TxtFile\";
		public override void SaveFile(string nameFile, byte[] file)
		{
			System.IO.File.WriteAllBytes(PathFolder + nameFile, file);
		}
	}
}