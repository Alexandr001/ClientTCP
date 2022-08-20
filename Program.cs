using System;
using System.Net.Sockets;

namespace ProjectTCP
{
	public class Program
	{
		private const int PORT = 8888;
		private const string SERVER = "127.0.0.1";
		
		public static void Main(string[] args)
		{
			TcpClient tcpClient = null;
			NetworkStream stream = null;
			
			try {
				tcpClient = new TcpClient();
				tcpClient.Connect(SERVER, PORT);
				stream = tcpClient.GetStream();
				Client client = new Client(stream);

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
				stream?.Close();
				tcpClient?.Close();
			}
			
			
			
			
			
			// Выбрать режим работы: получить текстовый или двоичный файл
			// Получить список доступных файлов
			// Вводится имя файла
			// Этот файл принимается и сохраняется
			// Программа завершается
		}
	}
}