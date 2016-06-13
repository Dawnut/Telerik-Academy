using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class GSM
    {
        private static decimal pricePerMin = 0.37m;
        public static readonly GSM Iphone4s = new GSM("iPhone 4S", "Apple", 500, "Ivanka", new Battery("Toshiba", BatteryType.Li_Ion, 48, 24), new Display(4.5, 16000000));
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();


        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model must be set!");
                }

                this.model = value;
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer must be set!");
                }
                
                this.manufacturer = value;
            }
        }
        public decimal? Price
        {
            get { return this.price; }
            set { this.price = value; }
        } 
        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        } 
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        public  List<Call> CallHistory 
        {
            get
            {
                if (callHistory.Count == 0)
                {
                    throw new ArgumentException("Call history is empty!");
                } 
                else 
                {
                    return this.callHistory;

                    //var callInfo = new StringBuilder();

                    //for (int i = 1; i <= callHistory.Count; i++)
                    //{
                    //    callInfo.AppendFormat("{0}. {1}n", i, this.callHistory[i-1].ToString());
                    //} 
                    //return callInfo.ToString().TrimEnd('\n');
                }
            }
            set
            {
                this.callHistory = value;
            }
        }

        // Only one constructor for all cases (has optional parameters)
        public GSM (string model,        
                    string manufacturer,
                    decimal? price = null,
                    string owner = null,
                    Battery battery = null,
                    Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;

        }

        public override string ToString()
        {
            var gsmSpecs = new StringBuilder();

            gsmSpecs.AppendFormat("Model: {0}\n", this.model);
            gsmSpecs.AppendFormat("Manufacturer: {0}\n", this.manufacturer);

            if (this.price != null)
            {
                gsmSpecs.AppendFormat("Price: {0:C2}\n", this.price);
            }

            if (this.Owner != null)
            {
                gsmSpecs.AppendFormat("Owner: {0}\n", this.owner);
            }

            gsmSpecs.AppendFormat(this.battery.ToString());
            gsmSpecs.AppendFormat(this.display.ToString());

            return gsmSpecs.ToString();

        }

        public void AddCall(DateTime dateTime, string dialedNumber, int duration)
        {
            this.callHistory.Add(new Call(dateTime, dialedNumber, duration));
        }

        public void DeleteCall(int callIndex)
        {
            this.callHistory.Remove(callHistory[callIndex]);
        }

        public string DisplayCallHistory()
        {
            var historyString = new StringBuilder();

            for (int i = 1; i <= callHistory.Count; i++)
			{
                historyString.AppendFormat("{0}. {1}\n", i, this.callHistory[i-1]);
			}
            return historyString.ToString().TrimEnd('\n');
        }

        public decimal GetPrice()
        {
            decimal totalPrice = 0;

            for (int i = 0; i < callHistory.Count; i++)
            {
                totalPrice += (callHistory[i].Duration / 60m) * pricePerMin;
            }

            return totalPrice;
        }
    }
}
