using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DelegateRemove
{
    public delegate void DeleTest(string msg);
    class Test_DeleGateCls : IDisposable
    {
        public DeleTest OnDD;
        //event field
        public event DeleTest OnDeleTest;

        public void RunDeleTest()
        {
            this.OnDD = new DeleTest((string msg) => { });
            if (OnDeleTest != null)
            {
                OnDeleTest.Invoke("Run...");
            }
        }

        public void RegisterOnDeleTest(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.OnDeleTest += Go;
            }
        }

        private void Go(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Dispose()
        {
            if (OnDeleTest.GetInvocationList().Length != 0)
            {
                //ref:http://stackoverflow.com/questions/153573/how-can-i-clear-event-subscriptions-in-c
                OnDeleTest = null;//直接將event變數設為null
                Delegate q = DeleTest.Remove(OnDeleTest, OnDeleTest);//無效(無法remove event內註冊的方法)  不知這要怎用
                
            }
            var i = OnDeleTest;
        }
    }
}
