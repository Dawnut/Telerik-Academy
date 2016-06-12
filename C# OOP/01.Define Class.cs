using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Components
{
    class Program
    {
        static void Main()
        {
            var battery1 = new Battery("Toshiba","NiCd", 24, 10);
            var display1 = new Display(5.2, 16000);
            var phone = new GSM("asdasd", "lenovo", battery: battery1);

            Console.WriteLine((phone.Battery).ToString());
        }
    }
}
