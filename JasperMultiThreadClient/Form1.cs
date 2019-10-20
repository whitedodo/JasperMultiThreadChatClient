using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JasperMultiThreadClient
{
    public partial class Form1 : Form
    {
        Thread thTimerThread;
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream;

        string address;
        int port;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            address = "127.0.0.1";
            port = 8888;
            lblServerStatus.Text = DateTime.Now + " 환영합니다.(Welcome)";

            thTimerThread = new Thread(serverTimerStart);
            thTimerThread.Start();
        }

        public void serverTimerStart()
        {

            while (true)
            {
                refreshTimer.Interval = 3000;
                refreshTimer.Enabled = true;
                refreshTimer.Start();
            }

        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect(address, port);
                lblServerStatus.Text = "서버 작동중...(Server On...)";
                recvMessage();

            }
            catch (Exception ex)
            {
                lblServerStatus.Text = "서버 멈췄음(Server Stopped)";
                txtMessages.Text = txtMessages.Text + Environment.NewLine +
                                   ex.ToString();
            }
        }

        public void recvMessage()
        {
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] inStream = new byte[65536];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);

            string returnData = System.Text.Encoding.UTF8.GetString(inStream);
            txtMessages.Text = txtMessages.Text + Environment.NewLine + ">>" + returnData;

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        public void sendMessage()
        {
            string localIP = GetLocalIP();
            string usrNickname = txtNickname.Text;
            string usrMessage = txtSend.Text;

            // 닉네임
            if (usrNickname == "")
            {
                usrNickname = "익명(Anonymous)";
            }

            // 메시지(message)
            if ( usrMessage == "")
            {
                usrMessage = localIP + ";" + usrNickname + ";\0";
            }
            else
            {
                usrMessage = localIP + ";" + usrNickname + ";" + usrMessage;
            }

            // 연결 여부(Connection)
            if (clientSocket.Connected == true)
            {
                serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.UTF8.GetBytes(usrMessage);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
            else
            {
                try
                {
                    clientSocket.Connect(address, port);
                    lblServerStatus.Text = "서버 작동중...(Server On...)";
                    serverStream = clientSocket.GetStream();
                    byte[] outStream = System.Text.Encoding.UTF8.GetBytes(usrMessage);
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    recvMessage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("대상 컴퓨터에서 연결을 거부했으므로 연결하지 못했습니다.\n" + 
                                    "(Failed to connect because the destination computer refused to connect.)",
                                    "메시지(Message)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblServerStatus.Text = "오류(Error)";
                    txtMessages.Text = txtMessages + Environment.NewLine +
                                       ex.ToString();
                }
            }
        }

        public string GetLocalIP()
        {
            string localIP = "Not available, please check your network seetings!";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thTimerThread.Abort();
        }
    }
}
