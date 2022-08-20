using System;
using System.IO;
using System.Net.Sockets;

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
		public static void Main(string[] args)
		{
			try {
				_tcpClient = new TcpClient();
				_tcpClient.Connect(SERVER, PORT);
				
				_stream = _tcpClient.GetStream();

				_reader = new BinaryReader(_stream);
				_writer = new BinaryWriter(_stream);
				Client client = new Client(_reader, _writer);

				Console.WriteLine("Введите режим работы программы: \n" + "1 - Получить текстовый файл\n" + "2 - Получить двоичный файл");

				int operatingMode = Convert.ToInt32(Console.ReadLine());
				client.WriteMessage(operatingMode);

				string listFileName = client.ReadMessageString();

				string fileName = Console.ReadLine();
				client.WriteMessage(fileName);


			} catch (Exception e) {
				Console.WriteLine(e);
				throw;
			} finally {
				_stream?.Close();
				_tcpClient?.Close();
				_reader.Close();
				_writer.Close();
			}
			
			
			
			
			
			// Выбрать режим работы: получить текстовый или двоичный файл
			// Получить список доступных файлов
			// Вводится имя файла
			// Этот файл принимается и сохраняется
			// Программа завершается
		}
	}
}