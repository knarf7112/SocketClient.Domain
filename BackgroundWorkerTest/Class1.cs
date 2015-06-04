using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundWorkerTest
{
    class Class1
    {
        public int a { get; set; }
        public string b { get; set; }
        public bool c { get; set; }
        public Class1 class1 { get; set; }

        public void CallByValue(int a)
        {
            a = 123;
            Console.WriteLine("CallByValue a=" + a);
        }
        public void CallByValue(string b)
        {
            b = "inside";
            Console.WriteLine("CallByValue b=" + b);
        }
        public void CallByValue(bool c)
        {
            c = false;
            Console.WriteLine("CallByValue c=" + c);
        }

        public void CallByRefClass1(Class1 c)
        {
            c.class1 = new Class1() 
            {
                a = 1,
                b= "b",
                c= true,
                class1 = new Class1()
                {
                    b = "class1"
                }
            };
        }
        public void throwException()
        {
            int tmp = 0;
            for (int i = 0; i < 10000; i++)
            {
                tmp++;
            }
            Random r = new Random();
            //if (r.Next(100) == 1)
                throw new Exception("人工意外");
        }
        public override string ToString()
        {
            if (class1 != null)
                return String.Format("a:{0},  b:{1},  c:{2},  \nclass1:{3}", a, b, c, class1.ToString());
            else
                return String.Format("a:{0},  b:{1},  c:{2}", a, b, c);
        }
    }
}
