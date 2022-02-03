using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
namespace lec01_ConsolToWindow
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        //private TcpClient tcpClient = null;
        //private NetworkStream ns;
        //private BinaryWriter bw = null;
        //private BinaryReader br = null;

        //int intValue;
        //float floatValue;
        //string strValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            tcpListener = new TcpListener(3000);
            tcpListener.Start();
            ///아이피 주소 알고 싶을 때
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i=0; i<host.AddressList.Length;i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox3.Text = host.AddressList[i].ToString();
                    break;
                }
            }
            ///
        }
        
        //private void AllClose()
        //{
        //    if (bw != null)
        //    { bw.Close(); bw = null; }
        //    if (br != null)
        //    { br.Close(); br = null; }
        //    if(ns!=null)
        //    { ns.Close(); ns = null; }
        //    if(tcpClient != null)
        //    {
        //        tcpClient.Close(); tcpClient = null;
        //    }
        //}
        private void btn_connect_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(AcceptClient));
            th.IsBackground = true;
            th.Start();
        }
        private void AcceptClient()
        {
            while(true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    listBox1.Items.Add(str);
                }
                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));
                th.IsBackground=true;
                th.Start();
            }
        }
        class EchoServer
        {
            TcpClient RefClient;
            private BinaryReader br = null;
            private BinaryWriter bw = null;
            int intValue;
            float floatValue;
            string strValue;
            public EchoServer(TcpClient Client)
            {
                RefClient = Client;
            }
            public void Process()
            {
                NetworkStream ns = RefClient.GetStream();
                try
                {
                    br = new BinaryReader(ns);
                    bw = new BinaryWriter(ns);
                    while (true)
                    {
                        intValue = br.ReadInt32();
                        floatValue = br.ReadSingle();
                        strValue = br.ReadString();
                        bw.Write(intValue);
                        bw.Write(floatValue);
                        bw.Write(strValue);
                    }
                }
                catch (SocketException se)
                {
                    br.Close();
                    bw.Close();
                    ns.Close();
                    ns = null;
                    RefClient.Close();
                    MessageBox.Show(se.Message);
                    Thread.CurrentThread.Abort();
                }
                catch (IOException ex)
                {
                    //연결이 끊어져서 읽을 수가 없을 때 처리
                    br.Close();
                    bw.Close();
                    ns.Close();
                    ns = null;
                    RefClient.Close();
                    Thread.CurrentThread.Abort();
                }
            }
        }
        //private void btn_connect2_Click(object sender, EventArgs e)
        //{
        //    while(true)
        //    {
        //        if(tcpClient.Connected)
        //        {
        //            if (DataReceive() == -1)
        //                break;
        //            DataSend();
        //        }
        //        else
        //        {
        //            AllClose();
        //            break;
        //        }
        //    }
        //    AllClose();
        //}
        //private int DataReceive()
        //{
        //    intValue = br.ReadInt32();
        //    if (intValue == -1)
        //        return -1;
        //    floatValue = br.ReadSingle();
        //    strValue = br.ReadString();
        //    string str = intValue + "/" + floatValue + "/" + strValue;
        //    MessageBox.Show(str);
        //    return 0;
        //}
        //private void DataSend()
        //{
        //    bw.Write(intValue);
        //    bw.Write(floatValue);
        //    bw.Write(strValue);

        //    MessageBox.Show("보냈습니다");
        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //AllClose();
            //tcpListener.Stop();
            if(tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }
    }
}
