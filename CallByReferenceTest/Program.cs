using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallByReferenceTest
{

    class Program
    {
        static void Main(string[] args)
        {
            CallByRef c = new CallByRef();
            class1 cc1 = c.c1;
            class1 cc2 = c.c2;
            class1 cc3 = new class1();

            c.CallByReference(cc3);
            var ss = cc3;
            c.CallByReference(cc3, "有改嗎");
            var ss2 = cc3;
            c.CallByRefTest(ref cc3);
            var ss3 = cc3;

            Console.ReadKey();
        }
    }
}
