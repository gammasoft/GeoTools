using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoJsonTools
{
    public class Polygon
    {
        private List<Coordinate> coordinates;
        public List<Coordinate> Coordinates
        {
            get
            {
                // TODO: Retornar ImmutableList
                return coordinates;
            }

            private set
            {
                coordinates = value;
            }
        }

        public Polygon()
        {
            this.Coordinates = new List<Coordinate>();
        }

        public void AddVertex(Coordinate coordinate)
        {
            this.Coordinates.Add(coordinate);
        }

        public void AddVertexFromPolarCoordinate(PolarCoordinate polarCoordinate)
        {
            var lastCoordinate = this.Coordinates.Last();
            var newCoordinate = Coordinate.FromPolarCoordinate(lastCoordinate, polarCoordinate);

            this.Coordinates.Add(newCoordinate);
        }

        public void close()
        {
            var firstCoordinate = this.Coordinates.First();
            this.Coordinates.Add(firstCoordinate);
        }
    }
}

