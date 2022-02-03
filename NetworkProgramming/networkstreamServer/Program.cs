﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace networkstreamServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("192.168.200.105"), 7);
            tcpListener.Start();
            Console.WriteLine("대기상태");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            byte[] ReceiveMessage = new byte[100];
            ns.Read(ReceiveMessage, 0, 100);
            string strMessage = Encoding.ASCII.GetString(ReceiveMessage);
            Console.WriteLine(strMessage);

            string EchoMessage = "Hi~~";
            byte[] SendMessage = Encoding.ASCII.GetBytes(EchoMessage);
            ns.Write(SendMessage, 0, SendMessage.Length);
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
            Console.ReadKey();
        }
    }
}
