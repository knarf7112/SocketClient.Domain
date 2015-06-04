using IM.Daemon.Utilities;
using Kms.PosClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class AutoLoad
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

        private SessionHandler Sessionhandler { get; set; }

        public SocketClient.Domain.SocketClient SocketClient { get; set; }

        public string IP { set; private get; }
        public int Port { set; private get; }

        public AutoLoad(string ip,int port)
        {
            this.pos = "1";
            this.store = "00110013";
            this.ALdate = "20150112185959";
            this.AMT = "00000500";
            this.cardId = "0417149982000008";
            this.TID = "04230F629F2980";
            //--------------------------
            this.Sessionhandler = new SessionHandler();
            string ranA = "1234567890ABCDEF1234567890ABCDEF";
            string ranB = "E6EA143CCB47EAB569C60BE26AAE12D5";
            string auth1Response = "4A92D4FF3C9F568B06D14B6FD87831F6";//K.M.S Data=0x4A,0x92,.....傳回來的randA加密(hex) 
            this.Sessionhandler.TId = "8604230F629F2980";//86+POS的Reader ID(7碼Binary)
            this.Sessionhandler.RndA = ranA;
            this.Sessionhandler.FixRndB = true;//固定RandB
            this.Sessionhandler.RndB = ranB;
            //---------------------
            this.IP = ip;
            this.Port = port;
        }
        private bool Auth01()
        {
            this.SocketClient = new SocketClient.Domain.SocketClient(this.IP,this.Port);
            byte[] recieve = null;
            //----------------------------------------------
            //****Auth01*****第一次驗證**********
            //1.產生SessionHandler,用來處理Auth01與Auth02和使用SessionKEY加解密
            //2.先輸入固定RandA與RandB
            //string auth01Str = "01020103110000000186000000018604230F629F2980    ZOO001123456781001100000003200000032            ";
            string auth01Str = "01020103110000000186000000018604230F629F2980    ZOO001123456781001100000003200000032            ";
            string auth01DataHex = "303130303030303030308604230F629F29802020202020202020202020202020";
            string auth01Hex = this.Sessionhandler.HexConverter.Str2Hex(auth01Str) + auth01DataHex;
            byte[] auth01Bytes = this.Sessionhandler.HexConverter.Hex2Bytes(auth01Hex);
            if (this.SocketClient.ConnectToServer())
            {
                recieve = this.SocketClient.SendAndReceive(auth01Bytes);
                this.SocketClient.CloseConnection();
            }
            //128(total) = 96(header) + 2(dataHeader) + 16(RanA) + 14(padding)
            ArraySegment<byte> randA = new ArraySegment<byte>(recieve, 96 + 2, 16);
            byte[] b = new byte[16];
            Buffer.BlockCopy(randA.Array, 96 + 2, b, 0, b.Length);
            string randAEncHex = this.Sessionhandler.HexConverter.Bytes2Hex(b);
            string result = this.Sessionhandler.HexConverter.Bytes2Hex(recieve);
            string hextostr = this.Sessionhandler.HexConverter.Hex2Str(result);

            //取得Center端傳來的的randA
            byte[] decrypto = this.Sessionhandler.Auth1Response(this.Sessionhandler.HexConverter.Hex2Bytes(randAEncHex));
            //轉回hex的RandA
            string ranA2 = this.Sessionhandler.HexConverter.Bytes2Hex(decrypto);
            if (ranA2 == this.Sessionhandler.RndA)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Auth02()
        {
            //****Auth02*****第二次驗證**********
            byte[] auth2RequestData = this.Sessionhandler.Auth2Request();//(96bytes)RanA+RandB'(rotate 2)
            //

            string auth2str = this.Sessionhandler.HexConverter.Bytes2Hex(auth2RequestData);//2C6362CFC1AB965ED3CB4E19186A917CB0416CA8F5E6A0D136E0D1D2F9E4CAAEDB882103E8EA26C1FCCE014CBDD4FEC2

            string auth2RequestStr = "01020103210000000186000000018604230F629F2980    ZOO001123456781001100000006400000064            ";
            string auth2RequestHex = this.Sessionhandler.HexConverter.Str2Hex(auth2RequestStr);
            string auth2RequestDataHex = "3031" + this.Sessionhandler.HexConverter.Bytes2Hex(auth2RequestData) + "2020202020202020202020202020";//header(2bytes) + request(48bytes) + padding(14bytes)

            byte[] auth2RequestBytes = this.Sessionhandler.HexConverter.Hex2Bytes(auth2RequestHex + auth2RequestDataHex);
            this.SocketClient = new SocketClient.Domain.SocketClient(this.IP,this.Port);
            byte[] auth2Result = null;
            if (this.SocketClient.ConnectToServer())
            {
                auth2Result = this.SocketClient.SendAndReceive(auth2RequestBytes);
                this.SocketClient.CloseConnection();
            }
                byte[] formCenter = new byte[this.Sessionhandler.HexConverter.Hex2Bytes(auth2RequestDataHex).Length];
                var sss = this.Sessionhandler.HexConverter.Bytes2Hex(auth2Result);
                Array.Copy(auth2Result, 96, formCenter, 0, formCenter.Length);
                ArraySegment<byte> requestRandB = new ArraySegment<byte>(formCenter, 2, 16);//Data共64byte取中間Request部分48byte
                byte[] b2 = new byte[16];
                Buffer.BlockCopy(requestRandB.Array, 2, b2, 0, b2.Length);
                
                byte[] randBbytes = this.Sessionhandler.Auth2Response(b2);
                string randB2 = this.Sessionhandler.HexConverter.Bytes2Hex(randBbytes);//RanB'(rotate left 2)
            //if(randB2.IndexOf())
            
            return true;
        }
        /// <summary>
        /// +:向左位移, -:向右位移
        /// </summary>
        /// <param name="numberStr">要旋轉的字串</param>
        /// <param name="shiftVal">位移量</param>
        /// <returns>位移後的字串</returns>
        public static string Rotate(string numberStr,int shiftVal) 
        {
            string result = String.Empty;
            int i = numberStr.Length;
            char[] ch = numberStr.ToCharArray();
            if (Math.Abs(shiftVal) / i > 0)
            {
                shiftVal = shiftVal % i;
            }
            for (int j = (shiftVal < 0 ? (i + shiftVal) : shiftVal); result.Length < i; j++)
            {
                    result += ch[j % i];
            }
            
            return result;        
        }
        public void autoload(bool runAuth0102 = true)
        {
            if(runAuth0102)
            {
                if (Auth01())
                {
                    if (!Auth02())
                    {
                        throw new Exception("Authorization 02 Failed!");
                    }
                }
                else
                {
                    throw new Exception("Authorization 01 Failed!");
                }
            }
            
            ////--------------------------------------------------
            //SessionHandler sessionhandler = new SessionHandler();
            //string ranA = "1234567890ABCDEF1234567890ABCDEF";
            //string ranB = "E6EA143CCB47EAB569C60BE26AAE12D5";
            //string auth1Response = "4A92D4FF3C9F568B06D14B6FD87831F6";//K.M.S Data=0x4A,0x92,.....傳回來的randA加密(hex) 
            //sessionhandler.TId = "8604230F629F2980";//86+POS的Reader ID(7碼Binary)
            //sessionhandler.RndA = ranA;
            //sessionhandler.FixRndB = true;//固定RandB
            //sessionhandler.RndB = ranB;
            ////--------------------------------------------------
            

            //IHexConverter hexworker = new HexConverter();
            //SocketClient.Domain.SocketClient s = new SocketClient.Domain.SocketClient("127.0.0.1", 8105);
            //byte[] recieve = null;
            //if (s.ConnectToServer())
            //{
            //    //----------------------------------------------
            //    //****Auth01*****第一次驗證**********
            //    //1.產生SessionHandler,用來處理Auth01與Auth02和使用SessionKEY加解密
            //    //2.先輸入固定RandA與RandB
            //    //string auth01Str = "01020103110000000186000000018604230F629F2980    ZOO001123456781001100000003200000032            ";
            //    string auth01Str = "01020103110000000186000000018604230F629F2980    ZOO001123456781001100000003200000032            ";
            //    string auth01DataHex = "303130303030303030308604230F629F29802020202020202020202020202020";
            //    string auth01Hex = hexworker.Str2Hex(auth01Str) + auth01DataHex;
            //    byte[] auth01Bytes = hexworker.Hex2Bytes(auth01Hex);
            //    recieve = s.SendAndReceive(auth01Bytes);
            //    s.CloseConnection();
            //}

            //ArraySegment<byte> randA = new ArraySegment<byte>(recieve, 96 + 2, 16);
            //byte[] b = new byte[16];
            //Buffer.BlockCopy(randA.Array, 96 + 2, b, 0, b.Length);
            //string randAEncHex = hexworker.Bytes2Hex(b);
            //string result = hexworker.Bytes2Hex(recieve);
            //string hextostr = hexworker.Hex2Str(result);

            ////取得Center端傳來的的randA
            //byte[] decrypto = sessionhandler.Auth1Response(hexworker.Hex2Bytes(auth1Response));
            ////轉回hex的RandA
            //string ranA2 = hexworker.Bytes2Hex(decrypto);
            ////------------------------------------
            ////****Auth02*****第二次驗證**********
            //byte[] auth2RequestData = sessionhandler.Auth2Request();//(96bytes)
            ////
            //string auth2str = hexworker.Bytes2Hex(auth2RequestData);//2C6362CFC1AB965ED3CB4E19186A917CB0416CA8F5E6A0D136E0D1D2F9E4CAAEDB882103E8EA26C1FCCE014CBDD4FEC2

            //string auth2RequestStr = "01020103210000000186000000018604230F629F2980    ZOO001123456781001100000006400000064            ";
            //string auth2RequestHex = hexworker.Str2Hex(auth2RequestStr);
            //string auth2RequestDataHex = "3031" + hexworker.Bytes2Hex(auth2RequestData) + "2020202020202020202020202020";//header(2bytes) + request(48bytes) + padding(14bytes)

            //byte[] auth2RequestBytes = hexworker.Hex2Bytes(auth2RequestHex + auth2RequestDataHex);
            //SocketClient.Domain.SocketClient s2 = new SocketClient.Domain.SocketClient("127.0.0.1", 8105);
            //if (s2.ConnectToServer())
            //{

            //    byte[] auth2Result = s2.SendAndReceive(auth2RequestBytes);
            //    s2.CloseConnection();
            //    byte[] formCenter = new byte[hexworker.Hex2Bytes(auth2RequestDataHex).Length];
            //    var sss = hexworker.Bytes2Hex(auth2Result);
            //    Array.Copy(auth2Result, 96, formCenter, 0, formCenter.Length);
            //    ArraySegment<byte> requestRandB = new ArraySegment<byte>(formCenter, 2, 16);//Data共64byte取中間Request部分48byte
            //    byte[] b2 = new byte[16];
            //    Buffer.BlockCopy(requestRandB.Array, 2, b2, 0, b2.Length);
            //    //byte[] tt= hexworker.Hex2Bytes(hexworker.Bytes2Hex(auth2Result).Substring(.Length));
            //    byte[] randBbytes = sessionhandler.Auth2Response(b2);
            //    string randB = hexworker.Bytes2Hex(randBbytes);

            //};

            //-----------------------------------------------------------
            DateTime dtRequest = DateTime.Now;
            //****AutoLoad*****發送自動加值電文**********
            string autoLoadRequest = "010302033200000001860000000186" + TID + "    SET001" + store + "100" + pos + "100000014400000160            ";  
            //string autoLoadRequest = "01030203320000000186000000018604230F629F2980    SET001000000011001100000014400000160            ";            
            string ALRequestHex = this.Sessionhandler.HexConverter.Str2Hex(autoLoadRequest);
            byte[] autoloadRequestHeaderBytes = this.Sessionhandler.HexConverter.Hex2Bytes(ALRequestHex);
            string autoloadRequestDataStr = "01                FirmwareVerssion"+ALdate+"      0000000"+AMT+"0000                12345678"+cardId+"201512312015123100000001A      ";
            //string autoloadRequestDataStr = "01                FirmwareVerssion20150109185959      0000000000005000000                123456780417149984000007201512312015123100000001A      ";
            byte[] autoloadRequestDataEnc = this.Sessionhandler.Encrypt(this.Sessionhandler.HexConverter.Hex2Bytes(this.Sessionhandler.HexConverter.Str2Hex(autoloadRequestDataStr)));

            byte[] autoloadRequestAll = new byte[autoloadRequestHeaderBytes.Length + autoloadRequestDataEnc.Length];
            Buffer.BlockCopy(autoloadRequestHeaderBytes, 0, autoloadRequestAll, 0, autoloadRequestHeaderBytes.Length);
            Buffer.BlockCopy(autoloadRequestDataEnc, 0, autoloadRequestAll, autoloadRequestHeaderBytes.Length, autoloadRequestDataEnc.Length);

            this.SocketClient = new SocketClient.Domain.SocketClient(this.IP,this.Port);
            
            if (this.SocketClient.ConnectToServer())
            {
                byte[] resultBytes = this.SocketClient.SendAndReceive(autoloadRequestAll);
                this.SocketClient.CloseConnection();

                byte[] autoloadResposneDataDecryBefor = new byte[160];
                string autoloadResposnehex = this.Sessionhandler.HexConverter.Bytes2Hex(resultBytes);
                string autoloadresposneStr = this.Sessionhandler.HexConverter.Hex2Str(autoloadResposnehex);
                this.RC = autoloadresposneStr.Substring(10,6);
                Array.Copy(resultBytes, 96, autoloadResposneDataDecryBefor, 0, autoloadResposneDataDecryBefor.Length);
                byte[] autoloadResposneDataAfter = this.Sessionhandler.Decrypt(autoloadResposneDataDecryBefor);
                string autoloadResponseDataHex = this.Sessionhandler.HexConverter.Bytes2Hex(autoloadResposneDataAfter);
                string autoloadResponseDataStr = this.Sessionhandler.HexConverter.Hex2Str(autoloadResponseDataHex);
                this.SN = autoloadResponseDataStr.Substring(2, 8);
            }
            //---------------------------------------------------------------------------------------
            
        }
        
    }
}
