using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ProjectTCP
{
	public class Client
	{
		private readonly NetworkStream _stream;
		public Client(NetworkStream stream)
		{
			_stream = stream;
		}

		public void WriteMessage(int value)	
		{
			BinaryWriter writer = new BinaryWriter(_stream);
			writer.Write(value);
			writer.Flush();
			writer.Close();
		}
		
		public void WriteMessage(string message)	
		{
			BinaryWriter writer = new BinaryWriter(_stream);
			writer.Write(message);
			writer.Flush();
			writer.Close();
		}

		public string ReadMessageString()
		{
			BinaryReader reader = new BinaryReader(_stream);
			string message = reader.ReadString();
			reader.Close();
			return message;
		}

		public int ReadMessageInt()
		{
			BinaryReader reader = new BinaryReader(_stream);
			int message = reader.ReadInt32();
			reader.Close();
			return message;
		}
	}
}