using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
//
using SocketService.Utilities;
using ALCommon;
namespace SocketService
{
    class SocketClient : IDisposable
    {
        private TcpClient tcpClient;
        private IPEndPoint ipEndPoint;
        public AL2POS_Domain socketRqt { get; set; }
        public SocketClient(string ip, int port)
        {
            try
            {
                IPAddress ipObj = Dns.GetHostAddresses(ip)[0];
                this.ipEndPoint = new IPEndPoint(ipObj, port);
                this.tcpClient = new TcpClient();//this.ipEndPoint);//給ipEndPoint下去就真的去Connect了
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private bool ConnectToServer()
        {
            try
            {
                this.tcpClient.Connect(this.ipEndPoint);
                if (this.tcpClient.Connected)
                {
                    Console.WriteLine("Connection " + this.ipEndPoint.Address.ToString() + " Success!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Connection " + this.ipEndPoint.Address.ToString() + " Failed!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Failed: " + ex.Message);
                return false;
            }
        }
        public void SetAutoloadRst()
        {
            this.socketRqt = new AL2POS_Domain()
            {
                COM_TYPE = "0731",
                ICC_NO = "0417149984000007",//CreditCard//"7006040040000250",//"7101060173008097",
                MERC_FLG ="SET",
                POS_FLG = "",
                AL_AMT = 1000,
                AL2POS_RC = "",
                AL2POS_SN = "",
                READER_ID = "8604042B6A9F2980",
                REG_ID = "01",
                STORE_NO = "000251"
            };
        }
        public AL2POS_Domain SendAndReceive()
        {
            try
            {
                if (ConnectToServer())
                {
                    if (socketRqt != null && this.socketRqt is AL2POS_Domain)
                    {                        
                        ISerializer<AL2POS_Domain> parser = new JsonWorker<AL2POS_Domain>();
                        byte[] sendBytes = parser.Serialize2Bytes(this.socketRqt as AL2POS_Domain);
                        int sendLength = this.tcpClient.Client.Send(sendBytes);
                        //NetworkStream ns = new NetworkStream(this.tcpClient.Client);
                        //ns.Write(sendBytes, 0, sendBytes.Length);
                        if (sendLength > 0)
                        {
                            byte[] receiveBytes = new byte[1024];
                            List<byte> s = new List<byte>();
                            int receiveLength = this.tcpClient.Client.Receive(receiveBytes, SocketFlags.None);
                            Array.Resize(ref receiveBytes, receiveLength);
                            AL2POS_Domain autoloadRsp = parser.Deserialize(receiveBytes);
                            Console.WriteLine("完成接收!");
                            return autoloadRsp;
                        }
                        return null;
                    }
                    else
                    {
                        Console.WriteLine("沒輸入要傳送的autoloadRst物件");
                        return null;
                    }
                }
                else
                {
                    this.Dispose();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendAndReceive Failed: " + ex.Message);
                this.Dispose();
                return null;
            }
        }

        public void Dispose()
        {
            if (this.ipEndPoint != null)
                this.ipEndPoint = null;
            if (this.tcpClient != null)
                this.tcpClient.Close();
        }
    }
}
