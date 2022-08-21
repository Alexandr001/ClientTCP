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
			return _reader.ReadString();;
		}

		public int ReadMessageInt()
		{
			return _reader.ReadInt32();
		}

		public byte[] ReadFileByte(int length)
		{
			return _reader.ReadBytes(length);
		}
	}
}