namespace ProjectTCP.ClientFile
{
	public class BinaryFile : File
	{
		protected override string PathFolder { get; } = @"C:\Users\Adilya\RiderProjects\ProjectTCP\Client\BinaryFile\";
		public override void SaveFile(string nameFile, byte[] file)
		{
			System.IO.File.WriteAllBytes(PathFolder + nameFile, file);
		}
	}
}