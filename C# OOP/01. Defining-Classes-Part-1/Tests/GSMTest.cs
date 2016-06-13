using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public static class GSMTest
    {
        public static void DevicesTest() 
        {

            // Initializing batteries and displays outside of the GSM constructors,
            // as the constructors should not initialize anyhting (good practice).

            Battery[] batteries = 
            {
            new Battery ("Toshiba", BatteryType.Li_Ion, 15, 10),
            new Battery ("Samsung", BatteryType.NiCd, 20, 15.5),
            new Battery ("Huawei", BatteryType.NiMH, 30.6, 12.3),
            };

            Display[] displays = 
            {
                new Display (5.2, 24000),
                new Display (4.0, 16000000),
                new Display (5.7, 32000000)
            };

            GSM[] phones = 
            {
                new GSM ("Galaxy S7", "Samsung", 700, "Pesho", batteries[0], displays[0]),
                new GSM ("Huawei p8", "Huawei", 900, "Petkan", batteries[1], displays[1]),
                new GSM ("Nexus 6p", "Google", 999.99m, "Dragan", batteries[2], displays[2])
            };

            foreach (var phone in phones)
            {
                Console.WriteLine(phone + "\n");
            }
            Console.WriteLine(GSM.Iphone4s);
        }
    }
}
