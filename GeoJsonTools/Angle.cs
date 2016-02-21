using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoJsonTools
{
    public class Angle
    {
        public double Degrees { get; set; }

        public double Radians
        {
            get
            {
                return (Math.PI / 180) * this.Degrees;
            }
        }

        public double Cosine
        {
            get
            {
                return Math.Cos(this.Radians);
            }
        }

        public double Sine
        {
            get
            {
                return Math.Sin(this.Radians);
            }
        }

        public Angle(int degrees, int minutes, int seconds)
        {
            this.Degrees = degrees + ((double)minutes / 60) + ((double)seconds / 3600);
        }
    }
}
