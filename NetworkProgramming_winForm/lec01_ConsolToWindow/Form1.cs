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
namespace lec01_ConsolToWindow
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        private TcpClient tcpClient = null;
        private NetworkStream ns;
        private BinaryWriter bw = null;
        private BinaryReader br = null;

        int intValue;
        float floatValue;
        string strValue;

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
        private void AllClose()
        {
            if (bw != null)
            { bw.Close(); bw = null; }
            if (br != null)
            { br.Close(); br = null; }
            if(ns!=null)
            { ns.Close(); ns = null; }
            if(tcpClient != null)
            {
                tcpClient.Close(); tcpClient = null;
            }
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            tcpClient = tcpListener.AcceptTcpClient();
            if (tcpClient.Connected)
            {
                //클라이언트의 ip주소를 가져오는 코드
                textBox4.Text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            }
            ns = tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);
        }

        private void btn_connect2_Click(object sender, EventArgs e)
        {
            while(true)
            {
                if(tcpClient.Connected)
                {
                    if (DataReceive() == -1)
                        break;
                    DataSend();
                }
                else
                {
                    AllClose();
                    break;
                }
            }
            AllClose();
        }
        private int DataReceive()
        {
            intValue = br.ReadInt32();
            if (intValue == -1)
                return -1;
            floatValue = br.ReadSingle();
            strValue = br.ReadString();
            string str = intValue + "/" + floatValue + "/" + strValue;
            MessageBox.Show(str);
            return 0;
        }
        private void DataSend()
        {
            bw.Write(intValue);
            bw.Write(floatValue);
            bw.Write(strValue);

            MessageBox.Show("보냈습니다");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllClose();
            tcpListener.Stop();
        }
    }
}
