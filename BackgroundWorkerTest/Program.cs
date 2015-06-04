using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundWorkerTest
{
    class ss
    {

    }
    class Program
    {
        static byte[] StringToByte(string hex)
        {
            
            byte[] b = new byte[(hex.Length * 4)];
            for (int i = 0; i < hex.Length; i++)
            {
                
            }
            return b;
        }
        static string qq(int c)
        {
            if (c / 2 < 1)
            {
                byte end = (byte)(c % 2);
                return end.ToString();
            }
            else if (c / 2 == 0)
            {
                string b2 = "0";
                string tmp = qq(c / 2);
                b2 = b2 + tmp;
                return b2;
            }
            else
            {
                string b2 = "1";
                string tmp = qq(((c / 2) + (c % 2)));
                b2 = b2 + tmp;
                return b2;
            }
        }
        /// <summary>
        /// 10進位轉2進位
        /// ex: 13 => 1101
        /// </summary>
        /// <param name="i">10進位</param>
        /// <returns>轉成2進位的數字</returns>
        static string Base10ToBase2(int i)
        {
            string str = "";
            do
            {
                str = (i % 2).ToString() + str;//為了直接反轉陣列
                i = i / 2;
            }
            while (i > 0);
            return str;
        }
        static void Main(string[] args)
        {
            try
            {

                string qq = Base10ToBase2(13);
                int i = 0;
                LinkedList<string> list = new LinkedList<string>();
                list.AddFirst("0");
                LinkedListNode<string> now = null;
                while (i < 10)
                {
                    i++; 
                    now = list.AddAfter(list.Last, i.ToString());
                    Console.WriteLine(now.Value);
                }
                bool boo = list.Contains("5");
                
                Class1 c1 = new Class1();
                
                //int test
                Console.WriteLine("class1.a=" + (c1.a = 999));
                c1.CallByValue(c1.a);
                Console.WriteLine("class1.a=" + c1.a);

                //string test
                Console.WriteLine("class1.b=" + (c1.b = "ppp"));
                c1.CallByValue(c1.b);
                Console.WriteLine("class1.b=" + c1.b);

                //bool test
                Console.WriteLine("class1.a=" + (c1.c = true));
                c1.CallByValue(c1.c);
                Console.WriteLine("class1.c=" + c1.c);

                //ref test
                Console.WriteLine("class1.class1=" + (c1.class1 = new Class1()));
                c1.CallByRefClass1(c1.class1);
                Console.WriteLine("class1.class1=" + c1.class1);
                Console.ReadKey();
                //throw new SocketException((int)SocketError.TryAgain);
            }
            catch (Exception ex)
            {
                throw new Exception("Test123", ex);
            }
            Dictionary<string, Class1> dic = new Dictionary<string, Class1>();
            if (dic.ContainsKey("QQ"))
            {
                Console.Write("no thing");
            }
            string date = "20150303155959";
            var s2 = date.Substring(4);
            string cc = Assembly.GetExecutingAssembly().Location;//取得執行檔Path位置
            //string date = "20150303155959";
            string ss = date.ToString(); 
            DateTime s = DateTime.ParseExact(date, "yyyyMMddHHmmss",System.Globalization.CultureInfo.CurrentCulture);
            DateTime d = DateTime.Now;
            int a = d.DayOfYear;
            try {
                throw new Exception("...");
            }
            catch(Exception ex) {
                Console.WriteLine("[tttt]dsadasdas:" + ex.ToString());
            }
            finally {
                //Console.WriteLine("run in finally");
            }
            Console.ReadKey();
            ThreadTest c2 = new ThreadTest();
            //for (int i = 0; i < 10; i++)
            //{
            //    c1.Run(i);
            //}
            c2.Run(1);
            //AutoResetEvent mainEvent = new AutoResetEvent(false);
            //int workerThreads;
            //int portThreads;

            //ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
            //Console.WriteLine("\nMaximum worker threads: \t{0}" +
            //    "\nMaximum completion port threads: {1}",
            //    workerThreads, portThreads);

            //ThreadPool.GetAvailableThreads(out workerThreads,
            //    out portThreads);
            //Console.WriteLine("\nAvailable worker threads: \t{0}" +
            //    "\nAvailable completion port threads: {1}\n",
            //    workerThreads, portThreads);

            //ThreadPool.QueueUserWorkItem(new
            //    WaitCallback(ThreadPoolTest.WorkItemMethod), mainEvent);

            //// Since ThreadPool threads are background threads, 
            //// wait for the work item to signal before ending Main.
            //mainEvent.WaitOne(5000, false);
            Console.ReadKey();
        }
    }
}
