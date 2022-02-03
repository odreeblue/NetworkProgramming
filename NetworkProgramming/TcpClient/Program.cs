using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace TcpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TcpClient tcpClient = new TcpClient(); 
            System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient("192.168.200.105", 7);
            if (tcpClient.Connected)
                Console.WriteLine("서버 연결 성공");
            else
            {
                Console.WriteLine("서버연결 실패");
            }
            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
