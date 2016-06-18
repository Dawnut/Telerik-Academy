using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSMComponents;

namespace GSMTests
{
    public static class GSMCallHistoryTest
    {

        public static void TestCallHistory ()
        {
            // Initializing batteries and displays outside of the GSM constructors,
            // as the constructors should not initialize anyhting (good practice).

            var battery = new Battery("Toshiba", BatteryType.Li_Ion, 15, 10);
            var display = new Display(5.2, 24000);
            var phone = new GSM("Galaxy S7", "Samsung", 700, "Pesho", battery, display);

            phone.AddCall(new Call (DateTime.Now, "0999999999", 60));
            phone.AddCall(new Call (new DateTime(2016, 7, 12, 23, 58, 30), "0444444444", 60));
            phone.AddCall(new Call (new DateTime(2016, 3, 2, 5, 50, 40), "0888888888", 120));

            Console.WriteLine("CALL HISTORY:");
            Console.WriteLine(phone.DisplayCallHistory() + "\n");
            Console.WriteLine("TOTAL PRICE: {0:C2}", phone.GetPrice());
            Console.WriteLine(new string ('-', 20));

            // Removing longest call and re-calculating price
            var longestCallIndex = 0;
            for (int i = 1; i < phone.CallHistory.Count; i++)
            {
                if (phone.CallHistory[i].Duration > phone.CallHistory[i-1].Duration)
                {
                    longestCallIndex = i;
                }
            }
            phone.DeleteCall(longestCallIndex);
            Console.WriteLine("MODIFIED CALL HISTORY:");
            Console.WriteLine(phone.DisplayCallHistory() + "\n");
            Console.WriteLine("NEW TOTAL PRICE: {0:C2}", phone.GetPrice());
        }
    }
}
