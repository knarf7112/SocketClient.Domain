//#define normal
#undef normal

using IM.Daemon.Utilities;
using Kms.PosClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Query
    {
        /// <summary>
        /// 00+6bytes
        /// </summary>
        public string store { get; set; }
        /// <summary>
        /// 1 byte
        /// </summary>
        public string pos { get; set; }
        /// <summary>
        /// 16 bytes
        /// </summary>
        public string cardId { get; set; }
        /// <summary>
        /// 20150112180000
        /// </summary>
        public string ALdate { get; set; }
        /// <summary>
        /// 8 bytes
        /// </summary>
        public string AMT { get; set; }
        /// <summary>
        /// return code
        /// </summary>
        public string RC { get; set; }
        /// <summary>
        ///  加值序號
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 14bytes
        /// </summary>
        public string TID { get; set; }
        /// <summary>
        /// 處理時間
        /// </summary>
        public string ptime { get; set; }

        static ManualResetEvent manualResetEvent;
        static AutoResetEvent autoResetEvent;
        static void DoWork()
        {
            
            Console.WriteLine("worker thread started, now waitting one event ... ");
            autoResetEvent.WaitOne();
            manualResetEvent.WaitOne();
            //WaitHandle.WaitAny()
            
            Console.WriteLine("worker thread reactived,now exiting...!");
        }
        public Query()
        {
            this.TID = "04230F629F2980";
        }
        public void Main2()
        {

            //autoResetEvent = new AutoResetEvent(false);
            //manualResetEvent = new ManualResetEvent(false);
            //Console.WriteLine("Main thread starting worker thread");
            //Thread t1 = new Thread(DoWork);//new 一個foreground的thread
            //t1.Start();
            //new Thread(() => { for (int i = 0; i < 10; i++) { Console.WriteLine("i = " + i); Thread.Sleep(1000); } }) { IsBackground = true }.Start();
            //Console.WriteLine("Main Thread Sleep 1 Second");
            //Thread.Sleep(10000);

            //Console.WriteLine("main thread signaling worker thread");
            ////autoResetEvent.Set();
            //manualResetEvent.Set();//Set跟WaitOne方法反過來就換主thread等待
#if normal
            
            SocketClient.Domain.SocketClient s = new SocketClient.Domain.SocketClient("10.27.68.155", 8104);//127.0.0.1", 8104);
            

            if (s.ConnectToServer())
            {
                //以下為POS送出的電文(已轉成hex),原來應該為Binary
                string str = "3031303130313035313130303030303030313836303030303030303138363034323330463632394632393830202020205A4F4F303031313233343536373831303031313030303030303033323030303030303332202020202020202020202020303130303030303030308604230F629F29802020202020202020202020202020";
                //----------------------------------------------
                //****Auth01*****第一次驗證**********
                //1.產生SessionHandler,用來處理Auth01與Auth02和使用SessionKEY加解密
                //2.先輸入固定RandA與RandB
                
                IHexConverter hexworker = new HexConverter();
                byte[] b = hexworker.Hex2Bytes(str);
                //byte[] recieve = s.SendAndReceive(b);
                //s.CloseConnection();
                //string result = hexworker.Bytes2Hex(recieve);
            }
#endif
            SessionHandler sessionhandler = new SessionHandler();
            string ranA = "1234567890ABCDEF1234567890ABCDEF";
            string ranB = "E6EA143CCB47EAB569C60BE26AAE12D5";

            string auth1Response = "4A92D4FF3C9F568B06D14B6FD87831F6";//K.M.S Data=0x4A,0x92,.....


            sessionhandler.TId = "8604230F629F2980";//86+POS的Reader ID(7碼Binary)
            sessionhandler.RndA = ranA;
            sessionhandler.FixRndB = true;//固定RandB
            sessionhandler.RndB = ranB;
#if normal               
                ////取得Center端傳來的的randA
                //byte[] decrypto = sessionhandler.Auth1Response(hexworker.Hex2Bytes(auth1Response));
                ////轉回hex的RandA
                //string ranA2 = hexworker.Bytes2Hex(decrypto);
 
            ////------------------------------------
                ////****Auth02*****第二次驗證**********
                //byte[] auth2RequestData = sessionhandler.Auth2Request();
                //
                string auth2str = hexworker.Bytes2Hex(auth2RequestData);//2C6362CFC1AB965ED3CB4E19186A917CB0416CA8F5E6A0D136E0D1D2F9E4CAAEDB882103E8EA26C1FCCE014CBDD4FEC2
                
                string auth2RequestStr = "01020105210000000186000000018604230F629F2980    ZOO001123456781001100000006400000064            ";
                string auth2RequestHex = hexworker.Str2Hex(auth2RequestStr);
                string auth2RequestDataHex = "3031" + hexworker.Bytes2Hex(auth2RequestData) + "2020202020202020202020202020";//header(2bytes) + request(48bytes) + padding(14bytes)

                byte[] auth2RequestBytes = hexworker.Hex2Bytes(auth2RequestHex + auth2RequestDataHex);
                SocketClient.Domain.SocketClient s2 = new SocketClient.Domain.SocketClient("10.27.68.155", 8104);//127.0.0.1", 8104);
                if (s2.ConnectToServer())
                {

                    byte[] auth2Result = s2.SendAndReceive(auth2RequestBytes);
                    s2.CloseConnection();
                    byte[] formCenter = new byte[hexworker.Hex2Bytes(auth2RequestDataHex).Length];
                    var sss = hexworker.Bytes2Hex(auth2Result);
                    Array.Copy(auth2Result, 96, formCenter, 0, formCenter.Length);
                    ArraySegment<byte> requestRandB = new ArraySegment<byte>(formCenter, 2, 16);//Data共64byte取中間Request部分48byte

                    byte[] randBbytesEnc = new byte[16];
                    Buffer.BlockCopy(requestRandB.Array, 2, randBbytesEnc, 0, 16);
                    //byte[] tt= hexworker.Hex2Bytes(hexworker.Bytes2Hex(auth2Result).Substring(.Length));
                    byte[] randBbytes = sessionhandler.Auth2Response(randBbytesEnc);
                    string randB = hexworker.Bytes2Hex(randBbytes);

                };
#endif
            //-----------------------------------------------------------
            //****Query*****發送查詢電文**********
            //SocketClient.Domain.SocketClient
            //string queryRequestHeaderStr = "01030105310000000186000000018604230F629F2980    ZOO001123456781001100000008000000080            ";
            string queryRequestHeaderStr = "010301053100000001860000000186" + this.TID + "    SET001" + this.store + "100" + this.pos + "100000008000000080            ";
            string queryRequestHeaderHex = sessionhandler.HexConverter.Str2Hex(queryRequestHeaderStr);
            byte[] queryRequestHeaderBytes = sessionhandler.HexConverter.Hex2Bytes(queryRequestHeaderHex);
            //string queryRequestDataEnc = "SAM           ID" + "FirmwareVerssion" + "12345678" + "0417149984000007" + "20151231" + "20151231";//"0417149984000007"Credit Card
            string queryRequestDataEnc = "SAM           ID" + "FirmwareVerssion" + "12345678" + this.cardId + "20151231" + "20151231";//"0417149984000007"Credit Card
            string queryRequestDataEncHex = sessionhandler.HexConverter.Str2Hex(queryRequestDataEnc);
            //byte[] queryRequestDataEncBytes = hexworker.Hex2Bytes(queryRequestDataEncHex);
            //byte[]  = sessionhandler.Encrypt(queryRequestDataEncBytes);
            string queryRequestDataHex = "3031" + queryRequestDataEncHex + "202020202020";
            byte[] queryRequestDataEncBytesBefor = sessionhandler.HexConverter.Hex2Bytes(queryRequestDataHex);//Request資料加密前
            byte[] queryRequestDataEncBytesAfter = sessionhandler.Encrypt(queryRequestDataEncBytesBefor);//Request資料加密後
            string enc = sessionhandler.HexConverter.Bytes2Hex(queryRequestDataEncBytesAfter);
            string encstr = sessionhandler.HexConverter.Hex2Str(enc);
            byte[] queryAll = new byte[queryRequestHeaderBytes.Length + queryRequestDataEncBytesAfter.Length];
            Buffer.BlockCopy(queryRequestHeaderBytes, 0, queryAll, 0, queryRequestHeaderBytes.Length);
            Buffer.BlockCopy(queryRequestDataEncBytesAfter, 0, queryAll, queryRequestHeaderBytes.Length, queryRequestDataEncBytesAfter.Length);
            SocketClient.Domain.SocketClient s3 = new SocketClient.Domain.SocketClient("10.27.68.155", 8104);//127.0.0.1", 8104);
            string resultHex = "";
            string resultStr = "";
            string resultHexAns = "";
            string resultAns = "";
            if (s3.ConnectToServer())
            {

                byte[] receiveBytes = s3.SendAndReceive(queryAll);//送出加密資料後的電文並取得傳回電文結果
                resultHex = sessionhandler.HexConverter.Bytes2Hex(receiveBytes);
                byte[] formCenter = new byte[80];
                this.RC = sessionhandler.HexConverter.Hex2Str(resultHex).Substring(10, 6);
                Array.Copy(receiveBytes, 96, formCenter, 0, formCenter.Length);
                byte[] ans = sessionhandler.Decrypt(formCenter);
                resultStr = sessionhandler.HexConverter.Hex2Str(resultHex);

                resultHexAns = sessionhandler.HexConverter.Bytes2Hex(ans);
                resultAns = sessionhandler.HexConverter.Hex2Str(resultHexAns);
                this.SN = resultAns.Substring(2, 8);
            }

            //Console.WriteLine(resultHex);
            //Console.ReadKey();
        }
        }
    }

