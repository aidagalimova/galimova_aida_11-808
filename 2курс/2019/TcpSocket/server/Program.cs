using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace SocketTcpServer
{
    class Program
    {
        static int port = 8005;
        static void Main(string[] args)
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);
                // начинаем прослушивание
                listenSocket.Listen(10);
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                Socket handler = listenSocket.Accept();
                var dic = new Dictionary<Socket, int[]>();
                dic.Add(handler, new int[] { 0, 0, 0 });
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных
                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);
                    string message;
                    if (builder.ToString() == "Current time")
                    {
                        message = DateTime.Now.ToShortTimeString().ToString();
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                        dic[handler][0]++;
                    }
                    else if (builder.ToString() == "Random")
                    {
                        message = new Random().Next(1, 100).ToString();
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                        dic[handler][1]++;
                    }
                    else if(builder.ToString() == "Count")
                    {
                        dic[handler][2]++;
                        message = ("\nА:" + dic[handler][0] + "\nБ:" + dic[handler][1] + "\nB:" + dic[handler][2]);
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                    }
                    else if(builder.ToString() == "Exit")
                    {
                        listenSocket.Listen(10);
                        Console.WriteLine("Клиент отключился. Ожидаем новых клиентов...");
                        handler = listenSocket.Accept();
                        dic.Add(handler, new int[] { 0, 0, 0 });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}