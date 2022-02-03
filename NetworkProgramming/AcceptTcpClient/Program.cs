using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace AcceptTcpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.200.105"), 7);
            tcpListener.Start();
            Console.WriteLine("대기상태 시작");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            Console.WriteLine("대기상태 종료");
            tcpListener.Stop();

        }
    }
}
