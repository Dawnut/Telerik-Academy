using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Components
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;

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

                this.model = value;
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

        }

    }
}
