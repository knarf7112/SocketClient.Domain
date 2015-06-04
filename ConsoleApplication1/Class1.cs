using Kms.PosClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Class1
    {
        

        static object ob1 = new object();
        
        static void Main()
        {
            //string PTCstr = "3031" + "17C0D2DC8B2B8602022CFAD857D3ED6013F9E7B8B8E747AE2D41CD0A817564E0A49A1B9BE26A1C274D3C89D8B085763DD08E6E230C55EDB71B088B6F58BE3557CC5FE7105EB4C3C24A75E54FEBA9812F" + "2020202020202020202020202020";
            string PTCStrAutoloadDecData = "3665778F82D56835398E5103FDDAC56E4BC54FE9E7B37F562549B4A4FA0F416AB32F1039D8E0FD82CA310194B2CEE4432FB0042634332026E36CEA7545FDE9A05DA1800E306011A03AB38DB2971CB6D9ECC849DF369ECEC8DFB8A6E0AAFEF1158756FD39012388D98DFE0BFAC2C6C75472FDB524BD056048A85F3DAB28735C0104704926407771853DB0FC272936AC72";
                                            
            string PTCStrAutoloadEncData = "D2F76FD4B7A6074D288C00C7ABA67579B5B5B972988DA37CA957D1B6E700C22F55EBC14C68DF2DEC7E4F89BA339F130CC36AC8F668DA7D44A9C14FF64C9AB40480CA710AE1ADD7AC223A08FBD6B857656D3935D16986111FB9DF0C14CF19D12C0B21F6EE80EAD291E509F30011FD37042E3AFB51C4DF3F18196AAD7D6D98E6663AC9C396493F596C8A980137F75D8558";
            
            //string tmp = "9C0C87277B77BAE432B095AA986B79A966A6E133894D5AFDC7F1855A9B52567FE69FCD5F8D382CF978F07B400181EA24242DEC932DDA5A3937FAA4AD4E5D3D52C193ED356694ACEA24A4F67B6F2886BC0E419303E3D5EA05E257D622D88B999D";
            SessionHandler session2 = new SessionHandler();
            string ranA = "1234567890ABCDEF1234567890ABCDEF";
            //string ranB = "E6EA143CCB47EAB569C60BE26AAE12D5";
            string ranB = "2848167D24E69499A7168C3B2DCE33E1";//"DD9C75010F8471677A513D294A3CAAEF";
            //string auth1Response = "4A92D4FF3C9F568B06D14B6FD87831F6";//K.M.S Data=0x4A,0x92,.....傳回來的randA加密(hex) 
            session2.TId = "86042720629F2980";//"8604230F629F2980";//86+POS的Reader ID(7碼Binary)
            session2.RndA = ranA;
            session2.FixRndB = true;//固定RandB
            session2.RndB = ranB;
            //-----------------------------------------------------------
            //byte[] tmpbytes = session2.HexConverter.Hex2Bytes(tmp);
            //byte[] tmpDec = session2.Decrypt(tmpbytes);
            //string tmpHexDec = session2.HexConverter.Bytes2Hex(tmpDec);
            //string tmpStrDec = session2.HexConverter.Hex2Str(tmpHexDec);
            //-----------------------------------------------------------
            byte[] PTCBytes = session2.HexConverter.Hex2Bytes(PTCStrAutoloadEncData);
            byte[] PTCBytesDec = session2.Decrypt(PTCBytes);
            string PTCHexDec = session2.HexConverter.Bytes2Hex(PTCBytesDec);
            string PTCstrDec = session2.HexConverter.Hex2Str(PTCHexDec);
            for (int i= 0; i < 1; i++)
            {
                //new Thread(Main3).Start();
                //Main4();
                //new Thread(Main2).Start();
            }
            Console.Read();
        }
        //Autoload
        static void Main2() 
        {
            
            //lock (ob1)
            //{
            string ip = "10.27.68.151";//"127.0.0.1";
            int port = 8105;
            AutoLoad autoload = new AutoLoad(ip, port);

            autoload.pos = "2";//"1";
            autoload.store = "00110013";
            autoload.ALdate = "20150112185959";
            autoload.AMT = "00001000";
            autoload.cardId = "0417149984000007";//"0417149987000005";





            autoload.autoload();
            string RC = autoload.RC;
            string SN = autoload.SN;



            Console.WriteLine("================ TS012 ================");
            Console.WriteLine("輸入     店號　:　" + autoload.store);
            Console.WriteLine("輸入    pos機　:　" + autoload.pos);
            Console.WriteLine("輸入 交易時間　:　" + autoload.ALdate);
            Console.WriteLine("輸入 交易金額　:　" + autoload.AMT);
            Console.WriteLine("輸入     卡號　:　" + autoload.cardId);
            Console.WriteLine("====================================");
            Console.WriteLine("   Return code：　" + RC);
            Console.WriteLine("            SN：　" + SN);
            //Console.WriteLine(" 處理時間(ms):" + autoload.ptime);



            //}


        }
        //Query
        static void Main3()
        {


            Query query = new Query();

            query.pos = "2";//"1";
            query.store = "00852067";
            query.ALdate = "20150112185959";
            query.AMT = "00000500";
            query.cardId = "0417149984000007";//"0417149987000005";//"0417149987000005";





            query.Main2();
            string RC = query.RC;
            string SN = query.SN;



            Console.WriteLine("================ TS021 ================");


            Console.WriteLine("輸入     店號　:　" + query.store);
            Console.WriteLine("輸入    pos機　:　" + query.pos);
            Console.WriteLine("輸入 交易時間　:　" + query.ALdate);
            Console.WriteLine("輸入 交易金額　:　" + query.AMT);
            Console.WriteLine("輸入     卡號　:　" + query.cardId);
            Console.WriteLine("====================================");
            Console.WriteLine("   Return code：　" + RC);
            Console.WriteLine("            SN：　" + SN);
            //Console.WriteLine(" 處理時間(ms):" + autoload.ptime);






        }
        /// <summary>
        /// TxLog
        /// </summary>
        static void Main4()
        {


            Txlog txlog = new Txlog();

            txlog.pos = "1";//"1";
            txlog.store = "00896159";
            
            txlog.AMT = "00000501";
            txlog.cardId = "0417149984000007";//"0417149987000005";
           
            txlog.COMM_TYPE = "0334";//0334 沖正
            txlog.PosNo = "000002";//每次都要不一樣


            txlog.Main1();
            string RC = txlog.RC;
            // string SN = txlog.SN;



            Console.WriteLine("================ TS038 ================");


            Console.WriteLine("輸入     店號　:　" + txlog.store);
            Console.WriteLine("輸入    pos機　:　" + txlog.pos);
            Console.WriteLine("輸入 交易金額　:　" + txlog.AMT);
            Console.WriteLine("輸入     卡號　:　" + txlog.cardId);
            Console.WriteLine("comm Type     ：　" + txlog.COMM_TYPE);
            Console.WriteLine("====================================");
            Console.WriteLine("   Return code：　" + RC);
            
            //Console.WriteLine(" 處理時間(ms):" + autoload.ptime);






        }





    }
}
