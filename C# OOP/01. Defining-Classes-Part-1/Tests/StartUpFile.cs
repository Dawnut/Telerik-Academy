﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
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