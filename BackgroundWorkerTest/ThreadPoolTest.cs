﻿using System;
using System.IO;
using System.Threading;

namespace BackgroundWorkerTest
{
    public class ThreadPoolTest
    {
        // Maintains state information to be passed to EndWriteCallback.
        // This information allows the callback to end the asynchronous
        // write operation and signal when it is finished.
        class State
        {
            public FileStream fStream;
            public AutoResetEvent autoEvent;

            public State(FileStream fStream, AutoResetEvent autoEvent)
            {
                this.fStream = fStream;
                this.autoEvent = autoEvent;
            }
        }

        ThreadPoolTest() { }

        public static void WorkItemMethod(object mainEvent)
        {
            Console.WriteLine("\nStarting WorkItem.\n");
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            // Create some data.
            const int ArraySize = 10000;
            const int BufferSize = 1000;
            byte[] byteArray = new Byte[ArraySize];
            new Random().NextBytes(byteArray);

            // Create two files and two State objects. 
            FileStream fileWriter1 =
                new FileStream(@"C:\Test1@##.dat", FileMode.Create,
                FileAccess.ReadWrite, FileShare.ReadWrite,
                BufferSize, true);
            FileStream fileWriter2 =
                new FileStream(@"C:\Test2@##.dat", FileMode.Create,
                FileAccess.ReadWrite, FileShare.ReadWrite,
                BufferSize, true);
            State stateInfo1 = new State(fileWriter1, autoEvent);
            State stateInfo2 = new State(fileWriter2, autoEvent);

            // Asynchronously write to the files.
            fileWriter1.BeginWrite(byteArray, 0, byteArray.Length,
                new AsyncCallback(EndWriteCallback), stateInfo1);
            fileWriter2.BeginWrite(byteArray, 0, byteArray.Length,
                new AsyncCallback(EndWriteCallback), stateInfo2);

            // Wait for the callbacks to signal.
            autoEvent.WaitOne();
            autoEvent.WaitOne();

            fileWriter1.Close();
            fileWriter2.Close();
            Console.WriteLine("\nEnding WorkItem.\n");

            // Signal Main that the work item is finished.
            ((AutoResetEvent)mainEvent).Set();
        }

        static void EndWriteCallback(IAsyncResult asyncResult)
        {
            Console.WriteLine("Starting EndWriteCallback.");

            State stateInfo = (State)asyncResult.AsyncState;
            int workerThreads;
            int portThreads;
            try
            {
                ThreadPool.GetAvailableThreads(out workerThreads,
                    out portThreads);
                Console.WriteLine("\nAvailable worker threads: \t{0}" +
                    "\nAvailable completion port threads: {1}\n",
                    workerThreads, portThreads);

                stateInfo.fStream.EndWrite(asyncResult);

                // Sleep so the other thread has a chance to run
                // before the current thread ends.
                Thread.Sleep(2500);
            }
            finally
            {
                // Signal that the current thread is finished.
                stateInfo.autoEvent.Set();
                Console.WriteLine("Ending EndWriteCallback.");
            }
        }
    }
}
