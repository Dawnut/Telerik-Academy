using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class Battery
    {
        private string model;
        private BatteryType? batteryType;
        private double? idleHours;
        private double? talkHours;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public BatteryType? BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value;  }
        }

        public double? IdleHours
        {
            get { return this.idleHours; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Idle Hours needs to be a positive integer!");

                }
                this.idleHours = value;
            }
        }
        public double? TalkHours
        {
            get { return this.talkHours; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Talk Hours needs to be a positive integer!");

                }
                this.talkHours = value;

            }
        }

        // Only one constructor for all cases (has optional parameters)
        public Battery(string model = null,
                        BatteryType? batteryType = null,
                        double? idleHours = null,
                        double? talkHours = null)
        {
            this.Model = model;
            this.BatteryType = batteryType;
            this.IdleHours = idleHours;
            this.TalkHours = talkHours;
        }

        public override string ToString()
        {
            var batterySpecs = new StringBuilder();

            if (this.model != null)
            {
                batterySpecs.AppendFormat("Battery Model: {0}\n", this.model);
            }

            if (this.model != null)
            {
                batterySpecs.AppendFormat("Battery type: {0}\n", this.batteryType);
            }

            if (this.idleHours != null)
            {
                batterySpecs.AppendFormat("Hours idle: {0:F1}\n", this.idleHours);
            }

            if (this.talkHours != null)
            {
                batterySpecs.AppendFormat("Hours talk: {0:F1}\n", this.talkHours);
            }

            return batterySpecs.ToString();
        }
    }

}
