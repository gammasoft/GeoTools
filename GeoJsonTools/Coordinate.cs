using GeoAPI.CoordinateSystems;
using GeoAPI.CoordinateSystems.Transformations;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using System;

namespace GeoJsonTools
{
    public class Coordinate
    {
        private double x;
        public double X
        {
            get
            {
                return x;
            }

            private set
            {
                x = value;
            }
        }

        private double y;
        public double Y
        {
            get
            {
                return y;
            }

            private set
            {
                y = value;
            }
        }

        private string zone;
        public string Zone
        {
            get
            {
                return zone;
            }

            private set
            {
                zone = value;
            }
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }

            private set
            {
                latitude = value;
            }
        }

        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }

            private set
            {
                longitude = value;
            }
        }

        public Coordinate(double longitude, double latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;

            ToUTM(longitude, latitude, out x, out y, out zone);
        }

        public Coordinate(double x, double y, string zone)
        {
            this.X = x;
            this.Y = y;
            this.Zone = zone;

            ToLatLon(x, y, zone, out latitude, out longitude);
        }

        private static void ToLatLon(double utmX, double utmY, string utmZone, out double latitude, out double longitude)
        {
            ICoordinateSystem gcs_WGS84 = GeographicCoordinateSystem.WGS84;
            IProjectedCoordinateSystem pcs_UTM31N = ProjectedCoordinateSystem.WGS84_UTM(23, false);

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(pcs_UTM31N, gcs_WGS84);
            double[] fromPoint = new double[] { utmX, utmY };
            double[] toPoint = trans.MathTransform.Transform(fromPoint);

            longitude = toPoint[0];
            latitude = toPoint[1];
        }

        private static void ToUTM(double longitude, double latitude, out double x, out double y, out string zone)
        {
            ICoordinateSystem gcs_WGS84 = GeographicCoordinateSystem.WGS84;
            IProjectedCoordinateSystem pcs_UTM31N = ProjectedCoordinateSystem.WGS84_UTM(23, false);

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(gcs_WGS84, pcs_UTM31N);
            double[] fromPoint = new double[] { longitude, latitude };
            double[] toPoint = trans.MathTransform.Transform(fromPoint);

            x = toPoint[0];
            y = toPoint[1];
            zone = "23S";
        }

        public static Coordinate FromPolarCoordinate(Coordinate origin, PolarCoordinate polarCoordinate)
        {
            return new Coordinate(origin.X + polarCoordinate.X, origin.Y + polarCoordinate.Y, origin.Zone);
        }
    }
}