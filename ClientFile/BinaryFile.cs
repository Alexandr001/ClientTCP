﻿namespace ProjectTCP.ClientFile
{
	public class BinaryFile : File
	{
		public string PathFolder { get; } = @"C:\Users\Adilya\RiderProjects\ProjectTCP\Client\BinaryFile\";
		public void SaveFile(string nameFile, byte[] file)
		{
			System.IO.File.WriteAllBytes(PathFolder + nameFile, file);
		}
	}
}