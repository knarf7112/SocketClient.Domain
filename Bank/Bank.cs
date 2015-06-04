using SocketClient.Domain;
using OL_Autoload_Lib;
using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
namespace Bank
{
    public class Bank
    {
        public readonly string destinationIP;
        public readonly int destinationPort;
        private ManualResetEvent manualEvent;
        private TcpClient tcpClient;
        /// <summary>
        /// 銀行名稱
        /// </summary>
        public string Name { get; set; }

        public SocketClient.Domain.SocketClient SocketClient;
        public delegate byte[] Receive();
        private Receive OnReceive;
        public Sign_Domain sign_Domain{get;set;}
        private NetworkStream networkStream;
        private byte[] buffer;
        public Bank(string destinationIP, int destinationPort,int sendTimeout = 0,int receiveTimeout = 0)
        {
            this.destinationIP = destinationIP;
            this.destinationPort = destinationPort;
            manualEvent = new ManualResetEvent(false);
            manualEvent.Reset();
            try
            {
                tcpClient = new TcpClient() 
                {
                    SendTimeout = sendTimeout,
                    ReceiveTimeout = receiveTimeout
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //SocketClient = new SocketClient.Domain.SocketClient(this.destinationIP, this.destinationPort);
        }

        protected bool Connect()
        {
            bool connect = false;
            try
            {
                if (!tcpClient.Connected)
                {
                    tcpClient.Connect(IPAddress.Parse(this.destinationIP), this.destinationPort);
                    connect = true;
                }
                else
                {
                    //測試寫入狀態等待50ms 
                    if (tcpClient.Client.Poll(50000, SelectMode.SelectWrite))
                    {
                        connect = true;
                    }
                    else
                    {
                        throw new Exception("[Connection Error]TcpClient can't write(Up50ms)");
                    }//
                }
                this.networkStream = this.tcpClient.GetStream();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connect;
        }
        public void Send(byte[] data)
        {
            try
            {
                if (this.Connect())
                {
                    this.networkStream.BeginWrite(data, 0, data.Length, new AsyncCallback(SendCallback), this.networkStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Connect Error]" + ex.ToString());
            }
        }

        public void Trans(byte[] data)
        {
            try
            {
                if (this.Connect())
                {
                    buffer = new byte[1024];
                    this.networkStream.BeginWrite(data, 0, data.Length, new AsyncCallback(SendCallback), this.networkStream);
                    this.networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReceiveCallback), this.networkStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Connect Error]" + ex.ToString());
            }
        }

        public void SendCallback(IAsyncResult ar)
        {
            NetworkStream ns = ar.AsyncState as NetworkStream;
            ns.EndWrite(ar);
            Console.WriteLine("非同步送出完成!");
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            NetworkStream ns = ar.AsyncState as NetworkStream;
            int receiveLength = ns.EndRead(ar);
            
            Console.WriteLine("非同步讀取完成!" );
        }
    }
}
