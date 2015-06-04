using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //sck.Bind(new EndPoint("",))

            //--------
            Type t = Assembly.GetExecutingAssembly().GetType("SocketService.Program");
            
            string ip = "10.27.88.78";
            int port = 6101;
            SocketClient<ALCommon.AL2POS_Domain> client = new SocketClient<ALCommon.AL2POS_Domain>(ip, port);
            //client.SetAutoloadRst<ALCommon.AL2POS_Domain>();
            //AL2POS_Domain
            //client.SendAndReceive<ALCommon.AL2POS_Domain()
            ALCommon.AL2POS_Domain rsp = client.SendAndReceive();
            Console.WriteLine("通信種別:" + rsp.COM_TYPE);
            Console.WriteLine("卡號:" + rsp.ICC_NO);
            Console.WriteLine("顧客識別子:" + rsp.MERC_FLG);
            Console.WriteLine("端末區分:" + rsp.POS_FLG);
            Console.WriteLine("端末製造序號:" + rsp.READER_ID);
            Console.WriteLine("POS機號:" + rsp.REG_ID);
            Console.WriteLine("特店店號:" + rsp.STORE_NO);
            Console.WriteLine("加值金額:" + rsp.AL_AMT);
            Console.WriteLine("加值序號:" + rsp.AL2POS_SN);
            Console.WriteLine("ReturnCode:" + rsp.AL2POS_RC);
            Console.ReadKey();
        }
    }
}
