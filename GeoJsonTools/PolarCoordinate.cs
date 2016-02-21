using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoJsonTools
{
    public class PolarCoordinate
    {
        public Angle Angle { get; set; }
        public double Radius { get; set; }

        public double X
        {
            get
            {
                return this.Angle.Sine * this.Radius;
            }
        }

        public double Y
        {
            get
            {
                return this.Angle.Cosine * this.Radius;
            }
        }
        public PolarCoordinate(Angle angle, double radius)
        {
            this.Angle = angle;
            this.Radius = radius;
        }
    }
}
