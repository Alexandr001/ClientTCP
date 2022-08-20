using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

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

		public void WriteMessage(int value)	
		{
			_writer.Write(value);
			_writer.Flush();
		}
		
		public void WriteMessage(string message)	
		{
			_writer.Write(message);
			_writer.Flush();
		}

		public string ReadMessageString()
		{
			string message = _reader.ReadString();
			return message;
		}

		public int ReadMessageInt()
		{
			int message = _reader.ReadInt32();
			return message;
		}
	}
}