using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSMComponents;
using GSMTests;

namespace GSMProgram
{
    class Program
    {
        static void Main()
        {
            GSMTest.DevicesTest();

            Console.WriteLine(new string ('-', 20));

            GSMCallHistoryTest.TestCallHistory();
        }
    }
}
