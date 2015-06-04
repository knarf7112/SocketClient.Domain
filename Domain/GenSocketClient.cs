using System;
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
    public class GenSocketClient<T> : ISocketClient<T>
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(GenSocketClient<T>));
        private TcpClient tcpClient;
        private IPEndPoint ipEndPoint;

        public int SendTimeout { private get; set; }
        public int ReceiveTimeout { private get; set; }

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

        private delegate void IPEndPointError();
        private event IPEndPointError OnIPEndPointError;  

        #region Constructor
        public GenSocketClient(string ip, int port, int sendTimeout = 0, int receiveTimeout = 0)
        {
            try
            {
                IPAddress ipObj = Dns.GetHostAddresses(ip)[0];
                this.ipEndPoint = new IPEndPoint(ipObj, port);
                this.tcpClient = new TcpClient();
                this.tcpClient.ReceiveTimeout = this.ReceiveTimeout;
                this.tcpClient.SendTimeout = this.SendTimeout;
            }
            catch (Exception ex)
            {
                //log.Error("Socket Client Constructor Failed:" + ex.Message);
                throw ex;
            }
        }
        public GenSocketClient()
        {
            this.OnIPEndPointError += ThrowSettingError;
        }
        #endregion

        #region Event
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
        public bool ConnectToServer()
        {
            try
            {
                if (this.tcpClient == null)
                {
                    this.tcpClient = new TcpClient();
                }
                if (this.ipEndPoint == null)
                {
                    this.ipEndPoint = new IPEndPoint(IPAddress.Parse(this.IP), this.Port);
                }
                this.tcpClient.Connect(this.ipEndPoint);
                if (this.tcpClient.Connected)
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
                //return false;
                throw ex;
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
                        ISerializer<T> parser = new NewJsonWorker<T>();
                        byte[] sendBytes = parser.Serialize2Bytes(poco);
                        int sendLength = this.tcpClient.Client.Send(sendBytes);
                        //log.Info("Socket Client Send :" + poco.ToString());
                        //log.Debug(Encoding.UTF8.GetString(sendBytes));
                        //NetworkStream ns = new NetworkStream(this.tcpClient.Client);
                        //ns.Write(sendBytes, 0, sendBytes.Length);
                        if (sendLength == sendBytes.Length)
                        {
                            byte[] receiveBytes = new byte[1024];
                            
                            int receiveLength = this.tcpClient.Client.Receive(receiveBytes, SocketFlags.None);
                            if (receiveLength > 0)
                            {
                                Array.Resize(ref receiveBytes, receiveLength);
                                T autoloadRsp = parser.Deserialize(receiveBytes);
                                //log.Info("Socket Client Receive Obj:" + autoloadRsp.ToString());
                                //log.Debug(Encoding.UTF8.GetString(receiveBytes));
                                return autoloadRsp;
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                        //log.Debug("Socket Client Trans Error : Trans object size not some size!");
                        return default(T);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                //log.Error("Socket Client SendAndReceive Failed: " + ex.Message);
                return default(T);
            }
        }
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
        }
        #endregion


        public void Dispose()
        {
            this.CloseConnection();
        }
    }
}
