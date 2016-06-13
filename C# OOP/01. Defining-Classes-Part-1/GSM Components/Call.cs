using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class Call
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string DialedNumber { get; set; }
        public int Duration { get; set; }

        public Call(DateTime dateTime, string dialedNumber, int duration)
        {
            this.Date = dateTime.ToShortDateString();
            this.Time = dateTime.ToShortTimeString();
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public override string ToString()
        {
            var callInfo = new StringBuilder();

            callInfo.AppendFormat("Date: {0}---Time: {1}---Number: {2}---Duration: {3} sec", this.Date, this.Time, this.DialedNumber, this.Duration);
            return callInfo.ToString();
        }
    }
}
