using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundWorkerTest
{
    class ThreadTest
    {

        private int workThreads;
        private int completeThreads;
        private BackgroundWorker bw;
        public ThreadTest()
        {
            //ThreadPool.SetMaxThreads(16, 160);
            bw = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += new DoWorkEventHandler(Do_Work);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Complete);
        }

        public void Run(int i)
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync(i);
            else
            {
                Thread.Yield();
                Run(i);
            }
        }
        public void Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            Console.WriteLine(" Complete:" + ((int)e.Result).ToString());
        }
        public void Do_Work(object sender, DoWorkEventArgs e)
        {
            Class1 c1 = new Class1();
            c1.throwException();
            object o = new object();
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolRun), o);
            ThreadPool.GetAvailableThreads(out workThreads, out completeThreads);//.GetMinThreads(out workThreads, out completeThreads);
            bool isThreadPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            bool isBackground = Thread.CurrentThread.IsBackground;
            Console.Write(">> workThreads:" + workThreads + "  completeThreads:" + completeThreads + "\nisThreadPoolThread:" + isThreadPoolThread + " isBackground:" + isBackground);
            e.Result = e.Argument;
        }

        private void ThreadPoolRun(object obj)
        {
            //lock (obj)
            //{
                int tmp = 0;
                for (int i = 0; i < 100000; i++)
                {
                    tmp++;
                }
            //}
        }
    }
}
