using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallByReferenceTest
{
    public class class1
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsTrue { get; set; }

    }
    public class CallByRef
    {
        public string s1 { get; set; }
        public int s2 { get; set; }
        public class1 c1 { get; set; }

        public class1 c2 { get; set; }

        public void CallByValue(string str, int i)
        {
            str = "Qoo";
            i = 999;
        }

        public void CallByValue(ref string str, ref int i)
        {
            str = "Qoo2";
            i = 888;
        }
        public void CallByRefTest(ref class1 c1)
        {
            c1 = new class1()
            {
                Name ="c1",
                Age = 23,
                IsTrue = true
            };
        }

        public void CallByReference(class1 c2)
        {
            c2 = new class1()
            {
                Name = "c2",
                Age = 99,
                IsTrue = true
            };
        }
        public void CallByReference(class1 c2,string name)
        {
            c2.Name = name;
        }
    }
}
