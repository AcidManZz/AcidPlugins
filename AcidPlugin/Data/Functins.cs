using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcidLib;
using System.IO;
using System.Net.Sockets;
using System.IO.MemoryMappedFiles;
using System.Net.Http;
using System.Net;
using Console = AcidLib.Console;

namespace AcidPlugin.Data
{
    public class Functins
    {
        /// <summary>
        /// Создатель конфига
        /// </summary>
        public static void ConfigCreater()
        {
            StreamWriter SwConfig = new StreamWriter(@"C://AcidPlugin/config.txt");
            Console.Say("========");
            Console.Say("Создатель конфига");
            Console.Say("========");
            System.Console.Write("license code: ");
            string lc = System.Console.ReadLine();
            if (lc == "1234")
            {
                SwConfig.WriteLine(lc);
            }
            else
            {
                Console.Say("код лицензии неправильный");
                Console.Say("Вам доступен бесплатный пакет");
                SwConfig.WriteLine("unlicensed");
            }
        }
        /// <summary>
        /// Чтение конфига, вывод из него данных
        /// </summary>
        /// <returns>List<string> ReadedData</returns>
        public static List<string> ConfigReader()
        {
            List<string> data = new List<string>();

            StreamReader SR = new StreamReader(@"C://AcidPlugin/config.txt");

            while (true)
            {
                string readed = SR.ReadLine();
                data.Add(readed);
            }

            return data;
        }
        public static void SendToSocket(string ip, int port, string mess)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Connect(tcpEndPoint);
            var data = Encoding.UTF8.GetBytes(mess);
            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();
            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocket.Available > 0);
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
        }
    }
}
