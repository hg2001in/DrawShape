using Windows.Foundation;
using Windows.UI.Xaml.Media;

namespace DrawShapes.Common
{
    /// <summary>
    /// Represents the coordinates point of the Parallelogram
    /// </summary>
    public static class ParallelogramCoordinates
    {
        private static readonly int _initialX = 0;
        private static readonly int _initialY = 0;
        private static readonly int OffSet = 30;

        /// <summary>
        /// Calculate x and Y coordinates of the Parallelogram
        /// </summary>
        /// <returns>List of x, y coordinates</returns>
        public static PointCollection CalculateCoordinateOfParallelogram(int length)
        {
            var points = new PointCollection();
            points.Add(new Point(_initialX, _initialY));

            var x1 = _initialX + OffSet; // add offSet to new x coordinates
            var y1 = _initialY + length; // add length to new y coordinates
            points.Add(new Point(x1, y1));

            var x2 = length + OffSet;
            var y2 = y1;
            points.Add(new Point(x2, y2));

            var x3 = _initialX + length;
            var y3 = _initialY;
            points.Add(new Point(x3, y3));

            return points;
        }
    }
}
