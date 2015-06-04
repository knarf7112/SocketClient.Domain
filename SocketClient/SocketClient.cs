using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
//
using OL_Autoload_Lib;
using SocketService.Utilities;
using LOLCommon;
using ALCommon;
namespace SocketService
{
    /// <summary>
    /// Socket Client 交訊傳入物件
    /// </summary>
    /// <typeparam name="T">要傳輸的物件類型</typeparam>
    public class SocketClient<T> : IDisposable
    {
        private TcpClient tcpClient;
        private IPEndPoint ipEndPoint;
        public T socketRqt { get; set; }

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
        
        public bool ConnectToServer()
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
        //public void SetAutoloadRst<T>() where T : AL2POS_Domain, new()
        //{
        //    this.socketRqt = new T()
        //    {
        //        COM_TYPE = "0731",
        //        ICC_NO = "0417149984000007",//CreditCard//"7006040040000250",//"7101060173008097",
        //        MERC_FLG = "SET",
        //        POS_FLG = "",
        //        AL_AMT = 1000,
        //        AL2POS_RC = "",
        //        AL2POS_SN = "",
        //        READER_ID = "8604042B6A9F2980",
        //        REG_ID = "01",
        //        STORE_NO = "000251"
        //    };
        //}

        /// <summary>
        /// 輸入參考物件
        /// </summary>
        /// <param name="request"></param>
        public void SetAutoloadRst(T request)
        {
            this.socketRqt = request;
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
        /// <summary>
        /// 傳送與接收交訊的物件(T)
        /// </summary>
        /// <typeparam name="T">要交訊的物件型別</typeparam>
        /// <param name="poco">輸入的物件</param>
        /// <param name="isConnected"></param>
        /// <returns>回傳T型別的物件</returns>
        public T SendAndReceive<T>() where T :class 
        {
            try
            {
                if (this.tcpClient != null && this.tcpClient.Connected)
                {
                    if (socketRqt != null && this.socketRqt is T)
                    {
                        ISerializer<T> parser = new JsonWorker<T>();
                        byte[] sendBytes = parser.Serialize2Bytes(this.socketRqt as T);
                        int sendLength = this.tcpClient.Client.Send(sendBytes);
                        //NetworkStream ns = new NetworkStream(this.tcpClient.Client);
                        //ns.Write(sendBytes, 0, sendBytes.Length);
                        if (sendLength > 0)
                        {
                            byte[] receiveBytes = new byte[1024];
                            List<byte> s = new List<byte>();
                            int receiveLength = this.tcpClient.Client.Receive(receiveBytes, SocketFlags.None);
                            Array.Resize(ref receiveBytes, receiveLength);
                            T autoloadRsp = parser.Deserialize(receiveBytes);
                            Console.WriteLine("完成接收!");
                            return autoloadRsp;
                        }
                        return default(T);
                    }
                    else
                    {
                        Console.WriteLine("沒輸入要傳送的autoloadRst物件");
                        return default(T);
                    }
                }
                else
                {
                    this.Dispose();
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendAndReceive Failed: " + ex.Message);
                this.Dispose();
                return default(T);
            }
        }
        /// <summary>
        /// 輸入傳輸物件等待回傳物件的結果
        /// </summary>
        /// <param name="poco">要傳輸的物件</param>
        /// <returns>傳回Server處理完的物件</returns>
        public T SendAndReceive(T poco)
        {
            try
            {
                if (this.tcpClient != null && this.tcpClient.Connected)
                {
                        ISerializer<T> parser = new JsonWorker<T>();
                        byte[] sendBytes = parser.Serialize2Bytes(poco);
                        int sendLength = this.tcpClient.Client.Send(sendBytes);
                        //NetworkStream ns = new NetworkStream(this.tcpClient.Client);
                        //ns.Write(sendBytes, 0, sendBytes.Length);
                        if (sendLength == sendBytes.Length)
                        {
                            byte[] receiveBytes = new byte[1024];
                            List<byte> s = new List<byte>();
                            int receiveLength = this.tcpClient.Client.Receive(receiveBytes, SocketFlags.None);
                            if (receiveLength > 0)
                            {
                                Array.Resize(ref receiveBytes, receiveLength);
                                T autoloadRsp = parser.Deserialize(receiveBytes);
                                Console.WriteLine("完成接收!");
                                return autoloadRsp;
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                        Console.WriteLine("傳輸物件大小不一致!");
                        return default(T);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendAndReceive Failed: " + ex.Message);
                return default(T);
            }
            finally
            {
                this.Dispose();
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
