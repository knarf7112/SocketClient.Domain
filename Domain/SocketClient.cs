﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SocketClient.Domain.Utilities;
using Common.Logging;
//
namespace SocketClient.Domain
{
    /// <summary>
    /// Socket Client 交訊傳入物件
    /// </summary>
    /// <typeparam name="T">要傳輸的物件類型</typeparam>
    public class SocketClient : ISocketClient
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(SocketClient));
        private TcpClient tcpClient;
        private IPEndPoint remoteIpEndPoint;
        private IPEndPoint localIpEndPoint;
        public const int ReceiveBufferSize = 4096;

        private string _ip;
        private int _port;

        public string IP 
        {
            get 
            {
                if (OnIPEndPointError != null && String.IsNullOrEmpty(this._ip))
                {
                    OnIPEndPointError.Invoke();
                }
                return this._ip;
            }
            set { this._ip = value; } 
        }
        public int Port 
        { 
            get 
            {
                if (OnIPEndPointError != null && this._port == 0)
                { 
                    OnIPEndPointError.Invoke(); 
                } 
                return this._port; 
            }
            set { this._port = value; } 
        }

        #region Constructor
        /// <summary>
        /// 指定連線遠端的IP和Port預設送出和收到逾時為0
        /// </summary>
        /// <param name="ip">遠端IP</param>
        /// <param name="port">遠端Port</param>
        /// <param name="sendTimeout">送出逾時(ms)</param>
        /// <param name="receiveTimeout">收到逾時(ms)</param>
        public SocketClient(string ip, int port, int sendTimeout = 0, int receiveTimeout = 0)
        {
            try
            {
                //IPAddress ipObj = Dns.GetHostAddresses(ip)[0];
                this.remoteIpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                this.tcpClient = new TcpClient();
                this.tcpClient.ReceiveTimeout = receiveTimeout;
                this.tcpClient.SendTimeout = sendTimeout;
            }
            catch (Exception ex)
            {
                //log.Error("Socket Client Constructor Failed:" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 連線遠端並指定本地端IP和Port
        /// </summary>
        /// <param name="remoteIP">遠端IP</param>
        /// <param name="remotePort">遠端Port</param>
        /// <param name="localIP">本地端IP</param>
        /// <param name="localPort">本地端Port</param>
        /// <param name="sendTimeout">Send Timeout(default:0ms)</param>
        /// <param name="receiveTimeout">Receive Timeout(default:0ms)</param>
        public SocketClient(string remoteIP, int remotePort, string localIP, int localPort, int sendTimeout = 0, int receiveTimeout = 0)
            : this(remoteIP, remotePort, sendTimeout, receiveTimeout)
        {
            this.localIpEndPoint = new IPEndPoint(IPAddress.Parse(localIP), localPort);
        }
        /// <summary>
        /// 自行設定遠端IP和Port(沒設定會拋出異常)
        /// </summary>
        public SocketClient()
        {
            this.OnIPEndPointError += ThrowSettingError;
        }
        #endregion

        #region Delegate and Event
        /// <summary>
        /// 抓取Exception
        /// </summary>
        /// <param name="ex"></param>
        public delegate void CatchException(Exception ex);
        /// <summary>
        /// 抓內部Socket的Exception
        /// </summary>
        public CatchException OnCatchException { get; set; }
        private delegate void IPEndPointError();
        private event IPEndPointError OnIPEndPointError;  
        /// <summary>
        /// 使用無參數的建構子但未輸入IP或Port丟出的例外
        /// </summary>
        /// <param name="ip">Null或""</param>
        /// <param name="port">0</param>
        private void ThrowSettingError()
        {
            //log.Error("SocketClient Constructor Error: IP and Port not setting!");
            throw new Exception("SocketClient Constructor Error: IP and Port not setting!");
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Socket連線遠端
        /// </summary>
        /// <returns>成功/失敗</returns>
        public bool ConnectToServer()
        {
            try
            {
                if (this.tcpClient == null)
                {
                    this.tcpClient = new TcpClient();
                }
                if (this.remoteIpEndPoint == null)
                {
                    this.remoteIpEndPoint = new IPEndPoint(IPAddress.Parse(this.IP), this.Port);
                }
                //this.tcpClient.BeginConnect(this.ipEndPoint.Address,this.ipEndPoint.Port,)
                if (localIpEndPoint != null)
                    this.tcpClient.Client.Bind(localIpEndPoint);
                this.tcpClient.Connect(this.remoteIpEndPoint);

                if (this.tcpClient.Connected || this.SocketConnect(this.tcpClient.Client))
                {
                    //log.Info("Socket Client Connection " + this.ipEndPoint.Address.ToString() + " Success!");
                    return true;
                }
                else
                {
                    //log.Info("Socket Client Connection " + this.ipEndPoint.Address.ToString() + " Failed!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //log.Error("Socket Client Connection Error: " + ex.Message);
                if (OnCatchException != null)
                {
                    OnCatchException.Invoke(ex);
                }
                return false;
                //throw ex;
            }
        }

        /// <summary>
        /// 輸入傳輸物件等待回傳物件的結果
        /// </summary>
        /// <param name="poco">要傳輸的物件</param>
        /// <returns>傳回Server處理完的物件</returns>
        public byte[] SendAndReceive(byte[] poco)
        {
            try
            {
                if ((this.tcpClient != null && this.tcpClient.Connected) || this.SocketConnect(this.tcpClient.Client))
                {
                    //使用此方法不會自動丟出Socket上的錯誤例外,例外會在out參數產出
                    int sendLength = this.tcpClient.Client.Send(poco, 0, poco.Length, SocketFlags.None);
                    //(真實送出資料長度) == (要送出data長度)
                    if (sendLength == poco.Length)
                    {
                        byte[] receiveBytes = new byte[ReceiveBufferSize];
                        //使用此方法不會自動丟出Socket上的錯誤例外,例外會在out參數產出
                        int receiveLength = this.tcpClient.Client.Receive(receiveBytes, 0, receiveBytes.Length, SocketFlags.None);
                        if (receiveLength > 0)
                        {
                            Array.Resize(ref receiveBytes, receiveLength);
                            return receiveBytes;
                        }
                        else
                        {
                            return null;
                        }
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log.Error("Socket Client SendAndReceive Failed: " + ex.Message);
                //Console.WriteLine("Socket Client SendAndReceive Failed: " + ex.Message);
                if (OnCatchException != null)
                {
                    OnCatchException.Invoke(ex);
                }
                this.Dispose();
                return null;
            }
        }

        /// <summary>
        /// 輸入傳輸物件等待回傳物件的結果
        /// </summary>
        /// <param name="poco">要傳輸的物件</param>
        /// <returns>傳回Server處理完的物件</returns>
        public byte[] SendAndReceive(byte[] poco,out SocketError socketErr)
        {
            try
            {
                if ((this.tcpClient != null && this.tcpClient.Connected) || this.SocketConnect(this.tcpClient.Client))
                {
                    //使用此方法不會自動丟出Socket上的錯誤例外,例外會在out參數產出
                    int sendLength = this.tcpClient.Client.Send(poco, 0, poco.Length, SocketFlags.None, out socketErr);
                    //(真實送出資料長度) == (要送出data長度)
                    if (sendLength == poco.Length && socketErr == SocketError.Success)
                    {
                        byte[] receiveBytes = new byte[4096];
                        //使用此方法不會自動丟出Socket上的錯誤例外,例外會在out參數產出
                        int receiveLength = this.tcpClient.Client.Receive(receiveBytes, 0, receiveBytes.Length, SocketFlags.None, out socketErr);
                        if (receiveLength > 0 && socketErr == SocketError.Success)
                        {
                            Array.Resize(ref receiveBytes, receiveLength);
                            return receiveBytes;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    
                    return null;
                }
                else
                {
                    socketErr = SocketError.NotConnected;
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (OnCatchException != null)
                {
                    OnCatchException.Invoke(ex);
                }
                //log.Error("Socket Client SendAndReceive Failed: " + ex.Message);
                //Console.WriteLine("Socket Client SendAndReceive Failed: " + ex.Message);
                this.Dispose();
                socketErr = SocketError.SocketError;
                return null;
            }
        }

        /// <summary>
        /// 檢查Socket連線狀態(可讀狀態且有資料可讀取)
        /// </summary>
        /// <param name="sck">被檢測的Socket</param>
        /// <returns>連線True/False斷線</returns>
        public bool SocketConnect(Socket sck)
        {
            try
            {
                bool part1 = sck.Poll(80000, SelectMode.SelectRead);//可讀狀態(80ms)//設-1就變成永遠等待資料
                bool part2 = sck.Available == 0;//網路卡那邊有資料可抓,但是資料為0
                if (part1 && part2)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Connect Error:" + ex.ToString());
                if (this.OnCatchException != null)
                {
                    this.OnCatchException.Invoke(ex);
                }
                return false;
            }
        }

        /// <summary>
        /// 關閉Socket Client連結
        /// </summary>
        public void CloseConnection()
        {
            //log.Debug("Start Dispose...");
            if (this.tcpClient != null)
            {
                try
                {
                    this.tcpClient.Client.Shutdown(SocketShutdown.Both);
                    this.tcpClient.Close();
                    this.tcpClient = null;
                }
                catch (SocketException ex)
                {
                    //log.Error("Socket Client Dispose Error: " + ex.Message);
                    throw ex;
                }
            }
            this.OnCatchException = null;
            this.OnIPEndPointError = null;
        }
        #endregion


        public void Dispose()
        {
            this.CloseConnection();
        }
    }
}
