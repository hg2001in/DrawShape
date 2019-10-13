using DrawShapes.Common;

namespace DrawShapes.Models
{
    public class ShapeItem
    {
        public Shape Shapes { get; set; }
        public bool IsHeightRequired { get; set; }
        public bool IsLengthRequired { get; set; }
        public bool IsRadiusRequired { get; set; }
        public bool IsCalculationRequired { get; set; }
    }
}
