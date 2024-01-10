using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class OurClient
    {
        private TcpClient client;
        private StreamWriter streamWriter;
        private StreamReader streamReader;

        public OurClient(string ipAddress, int portNum) {
            client = new TcpClient(ipAddress, portNum);
            streamWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            streamReader = new StreamReader(client.GetStream(), Encoding.UTF8);
            HandleCommunication();
        }

        void HandleCommunication() {
            while(true) {
                Console.Write("> ");
                string message = Console.ReadLine();
                streamWriter.WriteLine(message);
                streamWriter.Flush();

                System.Console.WriteLine(streamReader.ReadLine());
            }
        }
    }
}