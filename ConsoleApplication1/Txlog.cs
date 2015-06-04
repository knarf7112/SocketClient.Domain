using IM.Daemon.Utilities;
using Kms.PosClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Txlog
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
        /// comm_Type033
        /// </summary>
        public string COMM_TYPE { get; set; }
        /// <summary>
        /// 承認編號
        /// </summary>
        public string Ans { get; set; }
        /// <summary>
        /// pos交易序號
        /// </summary>
        public string PosNo { get; set; }
        public Txlog()
        {
            this.Ans = "00000001";
            this.TID = "04230F629F2980";//0";
        
        }
     public void Main1()
        {
            IHexConverter hexworker = new HexConverter();
            SocketClient.Domain.SocketClient s = new SocketClient.Domain.SocketClient("10.27.68.155", 8105);//127.0.0.1", 8105);
            SessionHandler sessionhandler = new SessionHandler();
            string ranA = "1234567890ABCDEF1234567890ABCDEF";
            string ranB = "E6EA143CCB47EAB569C60BE26AAE12D5";

            string auth1Response = "4A92D4FF3C9F568B06D14B6FD87831F6";//K.M.S Data=0x4A,0x92,.....//加密的RandA

            sessionhandler.TId = "8604230F629F2980";//86+POS的Reader ID(7碼Binary)即Terminal ID
            sessionhandler.RndA = ranA;
            sessionhandler.FixRndB = true;//固定RandB
            sessionhandler.RndB = ranB;
            byte[] recieve = null;
            //if (s.ConnectToServer())
            //{
            //    //----------------------------------------------
            //    //****Auth01*****第一次驗證**********
            //    //1.產生SessionHandler,用來處理Auth01與Auth02和使用SessionKEY加解密
            //    //2.先輸入固定RandA與RandB
            //    string auth01Str = "01020103110000000186000000018604230F629F2980    ZOO001123456781001100000003200000032            ";
            //    string auth01DataHex = "303130303030303030308604230F629F29802020202020202020202020202020";
            //    string auth01Hex = hexworker.Str2Hex(auth01Str) + auth01DataHex;
            //    byte[] auth01Bytes = hexworker.Hex2Bytes(auth01Hex);
            //    recieve = s.SendAndReceive(auth01Bytes);
            //    s.CloseConnection();
            //}
            //string result = hexworker.Bytes2Hex(recieve);



            ////取得Center端傳來的的randA
            //byte[] decrypto = sessionhandler.Auth1Response(hexworker.Hex2Bytes(auth1Response));
            ////轉回hex的RandA
            //string ranA2 = hexworker.Bytes2Hex(decrypto);
            ////------------------------------------
            ////****Auth02*****第二次驗證**********
            ////sessionhandler.RndB = ranB;
            //byte[] auth2RequestData = sessionhandler.Auth2Request();
            ////
            //string auth2str = hexworker.Bytes2Hex(auth2RequestData);//2C6362CFC1AB965ED3CB4E19186A917CB0416CA8F5E6A0D136E0D1D2F9E4CAAEDB882103E8EA26C1FCCE014CBDD4FEC2

            //string auth2RequestStr = "01020103210000000186000000018604230F629F2980    ZOO001123456781001100000006400000064            ";
            //string auth2RequestHex = hexworker.Str2Hex(auth2RequestStr);
            //string auth2RequestDataHex = "3031" + hexworker.Bytes2Hex(auth2RequestData) + "2020202020202020202020202020";//header(2bytes) + request(48bytes) + padding(14bytes)

            //byte[] auth2RequestBytes = hexworker.Hex2Bytes(auth2RequestHex + auth2RequestDataHex);
            //SocketClient.Domain.SocketClient s2 = new SocketClient.Domain.SocketClient("10.27.68.155", 8105);//127.0.0.1", 8105);
            //if (s2.ConnectToServer())
            //{

            //    byte[] auth2Result = s2.SendAndReceive(auth2RequestBytes);
            //    s2.CloseConnection();
            //    byte[] formCenter = new byte[hexworker.Hex2Bytes(auth2RequestDataHex).Length];
            //    var sss = hexworker.Bytes2Hex(auth2Result);
            //    Array.Copy(auth2Result, 96, formCenter, 0, formCenter.Length);
            //    ArraySegment<byte> requestRandB = new ArraySegment<byte>(formCenter, 2, 16);//Data共64byte取中間Request部分48byte
            //    byte[] randBbytesEnc = new byte[16];
            //    Buffer.BlockCopy(requestRandB.Array, 2, randBbytesEnc, 0, 16);
            //    //byte[] tt= hexworker.Hex2Bytes(hexworker.Bytes2Hex(auth2Result).Substring(.Length));
            //    byte[] randBbytes = sessionhandler.Auth2Response(randBbytesEnc);
            //    string randB = hexworker.Bytes2Hex(randBbytes);
            //};

            //-----------------------------------------------------------
            //****Txlog*****發送自動加值Txlog電文**********
            string txlogRequestHeader = "010401"+this.COMM_TYPE+"00000001860000000186"+this.TID+"    SET001"+this.store+"100"+this.pos+"100000035200000368            ";
            //string txlogRequestHeader = "01040103330000000186000000018604230F629F2980    SET001000000011001100000035200000368            ";
            //Txlog資料(288bytes)
            string txlogRequestData_txlog = "75"+"20150115135959"+"00000000"+this.cardId+this.AMT+"04230F629F2980001555000469570004424000065488000027170006469204230F629F29800000000000000000000015230000152320151231000000000000F093000ASET00100999407100318604230F00500001000000000000000000000000000000000000000000000000000000000000000000000A2";
            //string txlogRequestData_txlog = "75201501010101010000000004171499840000070000050004230F629F2980001555000469570004424000065488000027170006469204230F629F29800000000000000000000015230000152320151231000000000000F093000ASET00100999407100318604230F00500001000000000000000000000000000000000000000000000000000000000000000000000A2";
            string txlogRequestData_All = "01"+this.Ans+this.PosNo+ txlogRequestData_txlog + "                                                ";//[header + Ans + PosNo](2+8+6) + txlog(288bytes) + 空白(48bytes)
            string txlogRequestHeaderHex = hexworker.Str2Hex(txlogRequestHeader);//Txlog的header部分(96bytes)
            string txlogRequestData_AllHex = hexworker.Str2Hex(txlogRequestData_All);//要加密的Request全部Data 長度:352 bytes
            byte[] txlogRequestData_AllBytes = hexworker.Hex2Bytes(txlogRequestData_AllHex);//轉byte[]
            byte[] txlogRequestData_txlogHeaderBytes = hexworker.Hex2Bytes(txlogRequestHeaderHex);//header的 hex=>byte[]
            
            //
            byte[] txlogRequestData_AllBytesEnc = sessionhandler.Encrypt(txlogRequestData_AllBytes);//加密後Txlog資料部分(352)
            byte[] SendData = new byte[txlogRequestData_txlogHeaderBytes.Length + txlogRequestData_AllBytesEnc.Length];
            Buffer.BlockCopy(txlogRequestData_txlogHeaderBytes, 0, SendData, 0, txlogRequestData_txlogHeaderBytes.Length);
            Buffer.BlockCopy(txlogRequestData_AllBytesEnc, 0, SendData, txlogRequestData_txlogHeaderBytes.Length, txlogRequestData_AllBytesEnc.Length);
            SocketClient.Domain.SocketClient s3 = new SocketClient.Domain.SocketClient("10.27.68.155",8105);//127.0.0.1", 8105);
            if(s3.ConnectToServer())
            {
                recieve = s3.SendAndReceive(SendData);
                s3.CloseConnection();
            }
            string receiveTxlogHex = hexworker.Bytes2Hex( recieve);
            this.RC = hexworker.Hex2Str(receiveTxlogHex).Substring(10, 6);
            byte[] decBefor = new byte[144];

            Array.Copy(recieve, 96, decBefor, 0, decBefor.Length);
            byte[] decAfter = sessionhandler.Decrypt(decBefor);
            string TxlogDataHex = hexworker.Bytes2Hex(decAfter);
            string TxlogDataStr = hexworker.Hex2Str(TxlogDataHex);
            string receiveTxlogStr = hexworker.Hex2Str(receiveTxlogHex);
         
            //Console.ReadKey();
        }
    }
}
