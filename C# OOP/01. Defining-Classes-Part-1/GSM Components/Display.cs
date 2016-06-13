using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSM
{
    public class Display
    {
        private double? size;
        private int? colors;

        public double? Size
        {
            get { return this.size; }

            set
            {
                if (value < 3 || value > 6)
                {
                    throw new ArgumentException("Supported screen size is 3-6 inches!");
                }
                this.size = value;

            }
        }
        public int? Colors
        {
            get { return this.colors; }

            set
            {
                if (value < 16000)
                {
                    throw new ArgumentException("Screen must support at least 16,000 colors!");
                }
                this.colors = value;
            }
        }

        // Only one constructor for all cases (has optional parameters)
        public Display(double? size = null, int? colors = null)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public override string ToString()
        {
            var displaySpecs = new StringBuilder();

            if (this.size != null)
            {
                displaySpecs.AppendFormat("Display Size: {0:F1} inch\n", this.size);
            }

            if (this.colors != null)
            {
                displaySpecs.AppendFormat("Display Colors: {0}", this.colors);
            }

            return displaySpecs.ToString();
        }
    }

}
