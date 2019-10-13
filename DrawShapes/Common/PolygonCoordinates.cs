using System;
using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace DrawShapes.Common
{
    /// <summary>
    /// Represents the coordinates point of the polygon
    /// </summary>
    public static class PolygonCoordinates
    {
        /// <summary>
        /// Convert side length to radius
        /// </summary>
        /// <param name="sideLength"></param>
        /// <returns>Radius value calculated from length</returns>
        private static int ConvertLengthToRadius(double sideLength)
        {
            var radius = sideLength * Math.Sqrt(1 + 1 / Math.Sqrt(2));
            return (int)radius;
        }

        /// <summary>
        /// Get the value of the start angle
        /// </summary>
        /// <param name="numberOfSides"></param>
        /// <param name="centerAngle"></param>
        /// <returns> Value of the start angle</returns>
        private static double GetStartAngle(int numberOfSides, double centerAngle)
        {
            return IsEvenNumber(numberOfSides) ? (Math.PI - centerAngle / 2) : Math.PI / 2;
        }

        /// <summary>
        /// Check the number is even or odd
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True is even else false</returns>
        private static bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Calculate x and Y coordinates of the shape
        /// </summary>
        /// <returns>List of x, y coordinates</returns>
        public static PointCollection CalculateCoordinateOfShape(int numberOfSides, int length)
        {
            var points = new PointCollection();

            const int centerX = 100; // define initial x value of the center point
            const int centerY = 100; // define initial y value of the center point
            var centerAngle = 2 * Math.PI / numberOfSides;
            var radius = ConvertLengthToRadius(length);
            var startAngle = GetStartAngle(numberOfSides, centerAngle);

            for (var i = 0; i < numberOfSides; i++)
            {
                var angle = startAngle + i * centerAngle;
                var x = IsEvenNumber(numberOfSides) ?
                        (int)Math.Round(centerX - radius * Math.Sin(angle)) :
                        (int)Math.Round(centerX + radius * Math.Cos(angle));

                var y = IsEvenNumber(numberOfSides) ?
                        (int)Math.Round(centerY + radius * Math.Cos(angle)) :
                        (int)Math.Round(centerY - radius * Math.Sin(angle));

                points.Add(new Point(x,y));
            }

            return points;
        }
    }
}
