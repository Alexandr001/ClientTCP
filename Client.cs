using System;
using System.IO;

namespace ProjectTCP
{
	public class Client
	{
		private readonly BinaryReader _reader;
		private readonly BinaryWriter _writer;

		public Client(BinaryReader reader, BinaryWriter writer)
		{
			_reader = reader;
			_writer = writer;
		}
		public void PrintMessage(string message) => Console.WriteLine(message);
		public void WriteMessage(string message)	
		{
			_writer.Write(message);
			_writer.Flush();
		}
		public string ReadString() => _reader.ReadString();
		public int ReadInt() => _reader.ReadInt32();
		public byte[] ReadBytes(int length) => _reader.ReadBytes(length);
	}
}