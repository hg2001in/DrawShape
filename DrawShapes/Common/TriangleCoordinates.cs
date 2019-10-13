using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace DrawShapes.Common
{
    /// <summary>
    /// Represents the coordinates point of the Isosceles triangle
    /// </summary>
    public static class TriangleCoordinates
    {

        private static readonly int _initialX = 0;
        private static readonly int _initialY = 0;

        /// <summary>
        /// Calculate x and Y coordinates of the Isosceles triangle
        /// </summary>
        /// <returns>List of x, y coordinates</returns>
        public static PointCollection CalculateCoordinateOfIsoscelesTriangle(int height, int length)
        {
            var points = new PointCollection();
            points.Add(new Point(_initialX, _initialY));

            var x1 = _initialX + length; // add length to new x coordinates
            var y1 = _initialY; // y coordinates remain same as initial y 
            points.Add(new Point(x1, y1));

            // use intermediate points to create rectangle and calculate x2 point
            var intermediatePoint1 = new Point(_initialX , _initialY + height);
            var intermediatePoint2 = new Point(x1, _initialY + height);

            var x2 = (intermediatePoint1.X + intermediatePoint2.X) / 2;

            points.Add(new Point(x2, intermediatePoint2.Y));
            

            return points;
        }

        /// <summary>
        /// Calculate x and Y coordinates of the Scalene triangle
        /// </summary>
        /// <returns>List of x, y coordinates</returns>
        public static PointCollection CalculateCoordinateOfScaleneTriangle(int height, int length)
        {
            var points = new PointCollection {new Point(_initialX, _initialY)};

            var x1 = _initialX + length; // add length to new x coordinates
            var y1 = _initialY; // y coordinates remain same as initial y 
            points.Add(new Point(x1, y1));

            // use intermediate points to create rectangle and calculate x2 point
            var intermediatePoint1 = new Point(_initialX, _initialY + height);
            var intermediatePoint2 = new Point(x1, _initialY + height);

            var x2 =  ((intermediatePoint1.X + intermediatePoint2.X) / 2) * -1;

            points.Add(new Point(x2, intermediatePoint2.Y));


            return points;
        }
    }
}
