using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM.Components
{
        public class Display
    {
        private double size;
        private int colors;

        public double Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public int Colors
        {
            get { return this.colors; }
            set { this.colors = value; }
        }

        public Display(double size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }
    }

}
