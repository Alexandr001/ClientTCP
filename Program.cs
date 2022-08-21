using System;
using System.IO;
using System.Net.Sockets;
using ProjectTCP.ClientFile;
using File = ProjectTCP.ClientFile.File;

namespace ProjectTCP
{
	public class Program
	{
		private const int PORT = 8888;
		private const string SERVER = "127.0.0.1";

		private static TcpClient _tcpClient;
		private static NetworkStream _stream;
		private static BinaryWriter _writer;
		private static BinaryReader _reader;
		private static File _file;
		private static Client _client;

		public static void Main(string[] args)
		{
			try {
				_tcpClient = new TcpClient();
				_tcpClient.Connect(SERVER, PORT);
				
				_stream = _tcpClient.GetStream();

				_reader = new BinaryReader(_stream);
				_writer = new BinaryWriter(_stream);
				_client = new Client(_reader, _writer);

				Console.WriteLine("Введите режим работы программы: \n" 
				                  + "1 - Получить текстовый файл\n" 
				                  + "2 - Получить двоичный файл");

				string operatingMode = Console.ReadLine();
				if (operatingMode != "1" && operatingMode != "2") {
					throw new Exception("Неправильный режим работы!");
				}
				_client.WriteMessage(operatingMode);
				_client.PrintMessage("Режим работы отправлен!");

				string listFileName = _client.ReadString();
				_client.PrintMessage($"Доступные файлы:\n{listFileName}");

				Console.WriteLine("Введите имя файла:");
				string fileName = Console.ReadLine();
				if (_file.Exists(fileName) == false) {
					throw new Exception("Нет такого файла!");
				}
				_client.WriteMessage(fileName);
				_client.PrintMessage("Имя файла отправлено!");

				int fileLength = _client.ReadInt();
				_client.PrintMessage($"Размер файла в БАЙТАХ: {fileLength}");
				byte[] transferredFile = _client.ReadBytes(fileLength);

				if (operatingMode == "1") {
					_file = new TxtFile();
				} else {
					_file = new BinaryFile();
				}
				
				_file.SaveFile(fileName, transferredFile);
				_client.PrintMessage("Файл сохранен!");

			} catch (Exception e) {
				Console.WriteLine(e);
				_client.WriteMessage("0");
			} finally {
				_stream?.Close();
				_tcpClient?.Close();
				_reader.Close();
				_writer.Close();
			}
		}
	}
}