using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace SocketClient_Query
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "10.27.88.78";
            int port = 6102;
            SocketService.SocketClient query = new SocketService.SocketClient(ip, port);
            query.SetAutoloadRst();
            ALCommon.AL2POS_Domain rsp = query.SendAndReceive();
            Console.WriteLine("通信種別:" + rsp.COM_TYPE);
            Console.WriteLine("卡號:" + rsp.ICC_NO);
            Console.WriteLine("顧客識別子:" + rsp.MERC_FLG);
            Console.WriteLine("端末區分:" + rsp.POS_FLG);
            Console.WriteLine("端末製造序號:" + rsp.READER_ID);
            Console.WriteLine("POS機號:" + rsp.REG_ID);
            Console.WriteLine("特店店號:" + rsp.STORE_NO);
            Console.WriteLine("加值金額:" + rsp.AL_AMT);
            Console.WriteLine("加值序號:" + rsp.AL2POS_SN);
            Console.WriteLine("ReturnCode:" + rsp.AL2POS_RC);//000000
            Console.ReadKey();
        }
    }
}
