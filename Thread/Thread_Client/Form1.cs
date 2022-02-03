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

namespace lec02_ConsolToWindow_Client
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient = null;
        NetworkStream ns;
        BinaryReader br;
        BinaryWriter bw;

        int intValue;
        float floatValue;
        string strValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient(textBox5.Text, 3000);
            if(tcpClient.Connected)
            {
                ns = tcpClient.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                MessageBox.Show("서버 접속 성공");
            }
            else
            {
                MessageBox.Show("서버 접속 실패");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bw.Write(int.Parse(textBox6.Text));
            bw.Write(float.Parse(textBox7.Text));
            bw.Write(textBox8.Text);

            intValue = br.ReadInt32();
            floatValue = br.ReadSingle();
            strValue = br.ReadString();

            String str = intValue + "/" + floatValue + "/" + strValue;
            MessageBox.Show(str);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bw.Write(-1);
            bw.Close();
            br.Close();
            ns.Close();
            tcpClient.Close();
        }
    }
}
