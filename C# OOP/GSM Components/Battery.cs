using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Components
{
    public class Battery
    {
        private string model;
        private BatteryType batteryType;
        private double idleHours;
        private double talkHours;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public BatteryType BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        public double IdleHours
        {
            get { return this.idleHours; }
            set { this.idleHours = value; }
        }
        public double TalkHours
        {
            get { return this.talkHours; }
            set { this.talkHours = value; }
        }

        public Battery(string model, string batteryType, double idleHours, double talkHours)
        {
            this.Model = model;
            this.IdleHours = idleHours;
            this.TalkHours = talkHours;
        }

        public override string ToString()
        {
            var batteryInfo = new StringBuilder();

            batteryInfo.AppendFormat("Battery type: {0}", this.BatteryType);

            if (this.idleHours != null)
            {
                batteryInfo.AppendFormat(", Hours idle: {0}", this.idleHours);
            }

            if (this.talkHours != null)
            {
                batteryInfo.AppendFormat(", Hours talk: {0}", this.talkHours);
            }

            return batteryInfo.ToString();
        }
    }

}
