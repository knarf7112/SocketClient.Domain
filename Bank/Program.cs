using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
                ////Creates the Socket for sending data over TCP.
                //Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                //   ProtocolType.Tcp);
                //string strRetPage;
                //// Connects to host using IPEndPoint.
                //s.Connect(IPAddress.Parse("127.0.0.1"), 6666);
                //if (!s.Connected)
                //{
                //    strRetPage = "Unable to connect to host";
                //    Console.WriteLine(strRetPage);
                //}
                //// Use the SelectWrite enumeration to obtain Socket status.
                //if (s.Poll(-1, SelectMode.SelectWrite))
                //{
                //    Console.WriteLine("This Socket is writable.");
                //}
                ////1 second = 0.000001 second
                //if (s.Poll(9900000, SelectMode.SelectRead))
                //{
                //    Console.WriteLine("This Socket is readable.");
                //}
                //if (s.Poll(1000, SelectMode.SelectError))
                //{
                //    Console.WriteLine("This Socket has an error.");
                //}
                TcpClient tcp = new TcpClient();

                //bool check = tcp.Client.Poll(100, SelectMode.SelectRead);
                tcp.Connect(new System.Net.IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666));
                bool check1 = tcp.Client.Poll(10000000, SelectMode.SelectRead);
                bool check2 = tcp.Client.Poll(100, SelectMode.SelectWrite);
                bool check3 = tcp.Client.Poll(100, SelectMode.SelectError);
                NetworkStream ns = tcp.GetStream();
                byte[] sendBytes = Encoding.UTF8.GetBytes("Qoo");
                ns.Write(sendBytes, 0, sendBytes.Length);
                byte[] receiveBytes = new byte[1024];
                int i = ns.Read(receiveBytes, 0, 1024);
                string receiveStr = Encoding.UTF8.GetString(receiveBytes, 0, i);
                bool check4 = tcp.Client.Poll(100, SelectMode.SelectRead);
                Console.WriteLine(receiveStr);
                tcp.Close();
            }
            catch (Exception ex)
            {

            }
            Console.ReadKey();
        }
    }
}
