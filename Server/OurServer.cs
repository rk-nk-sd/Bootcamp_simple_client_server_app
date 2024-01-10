using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class OurServer
    {
        TcpListener server;

        public OurServer() {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients();
        }

        void LoopClients() {
            while(true) {
                TcpClient client = server.AcceptTcpClient();

                Thread thread = new Thread(() => HandleClient(client));
                thread.Start();
            }
        }

        void HandleClient(TcpClient client) {
            StreamReader streamReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter streamWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            while(true) {
                string message = streamReader.ReadLine();
                System.Console.WriteLine($"Клиент написал - {message}");

                streamWriter.WriteLine($"Сервер получил соотбение: {message}");
                streamWriter.Flush();
            }
        }
    }
}