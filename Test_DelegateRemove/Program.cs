using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DelegateRemove
{
    class Program
    {
        static void Main(string[] args)
        {

            Test_DeleGateCls t = new Test_DeleGateCls();
            DeleTest tt = new DeleTest((string msg) => { Console.WriteLine("外部的註冊" + msg); });
            t.OnDeleTest += tt;//(string msg) => { Console.WriteLine("外部的註冊" + msg); };
            t.RunDeleTest();
            t.RegisterOnDeleTest(10);
            //t.OnDeleTest = null;//compiler error 無法這樣取消註冊
            t.OnDeleTest += null;
            t.OnDeleTest -= tt;//這樣才能取消註冊//(string msg) => { Console.WriteLine("外部的註冊" + msg); };
            t.RunDeleTest();
            t.Dispose();
            t.RunDeleTest();
            Console.ReadKey();
        }

        
    }
    class Test
    {
        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }

            remove
            {
                Console.WriteLine("remove operation");
            }
        }

        static void Main2()
        {
            Test t = new Test();

            t.MyEvent += new EventHandler(t.DoNothing);
            t.MyEvent -= null;
        }

        void DoNothing(object sender, EventArgs e)
        {
            
        }
    } 
}
