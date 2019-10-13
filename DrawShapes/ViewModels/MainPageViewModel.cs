using DrawShapes.Common;
using DrawShapes.Models;
using DrawShapes.MVVM;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media;

namespace DrawShapes.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            CreateShapeItemsList();
            CreateShapeCommand = new ViewModelCommand(CreateShape);
        }

        public ViewModelCommand CreateShapeCommand { get; private set; }

        // Create shape by given parameters
        private async void CreateShape()
        {
            if (SelectedShapeItem != null)
            {
                if (SelectedShapeItem.IsCalculationRequired)
                {
                    switch (SelectedShapeItem.Shapes)
                    {
                        case Shape.IsoscelesTriangle:
                            IsoscelesTrianglePoints =
                                TriangleCoordinates.CalculateCoordinateOfIsoscelesTriangle(HeightUnit, WidthUnit);
                            break;
                        case Shape.ScaleneTriangle:
                            ScaleneTrianglePoints = TriangleCoordinates.CalculateCoordinateOfScaleneTriangle(HeightUnit, WidthUnit);
                            break;
                        case Shape.Parallelogram:
                            ParallelogramPoints =
                                ParallelogramCoordinates.CalculateCoordinateOfParallelogram(WidthUnit);
                            break;
                        default:
                        {
                            var numberOfSie = GetNumberOfSideOfShape(SelectedShapeItem.Shapes);
                            PolygonPoints = PolygonCoordinates.CalculateCoordinateOfShape(numberOfSie, WidthUnit);
                            break;
                        }
                    }
                }

                SetCurrentShape(SelectedShapeItem.Shapes);
            }
            else
            {
                var messageDialog = new MessageDialog("Please select the shape.", "Shapes");
                await messageDialog.ShowAsync();
            }
        }

        // Get the number of side by shape
        private int GetNumberOfSideOfShape(Shape shape)
        {
            if (shape == Shape.Pentagon) return 5;
            if (shape == Shape.Hexagon) return 6;
            if (shape == Shape.Heptagon) return 7;
            if (shape == Shape.Octagon) return 8;
            if (shape == Shape.Square) return 4;
            if (shape == Shape.EquilateralTriangle) return 3;
            return 0;
        }

        // Set the current shape
        private void SetCurrentShape(Shape shape)
        {
            IsCircle = shape == Shape.Circle;
            IsIsoscelesTriangle = shape == Shape.IsoscelesTriangle;
            IsScaleneTriangle = shape == Shape.ScaleneTriangle;
            IsRectangle = shape == Shape.Rectangle;
            IsOval = shape == Shape.Oval;
            IsParallelogram = shape == Shape.Parallelogram;
            IsPolygon = IsRegularPolygon(shape);
        }

        // check regular polygon shape
        private bool IsRegularPolygon(Shape shape)
        {
            return shape == Shape.EquilateralTriangle ||
                   shape == Shape.Square ||
                   shape == Shape.Pentagon ||
                   shape == Shape.Hexagon ||
                   shape == Shape.Heptagon ||
                   shape == Shape.Octagon;
        }

        // Create the list of the shapes to display
        private void CreateShapeItemsList()
        {
            ShapeItems = new List<ShapeItem>
            {
                new ShapeItem
                {
                    Shapes = Shape.Circle,
                    IsHeightRequired = false,
                    IsLengthRequired = false,
                    IsRadiusRequired = true,
                    IsCalculationRequired = false
                },
                new ShapeItem
                {
                    Shapes = Shape.EquilateralTriangle,
                    IsHeightRequired = false,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.Heptagon,
                    IsHeightRequired = false,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.Hexagon,
                    IsHeightRequired = false,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.IsoscelesTriangle,
                    IsHeightRequired = true,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.Octagon,
                    IsHeightRequired = false,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.Oval,
                    IsHeightRequired = true,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = false
                },
                new ShapeItem
                {
                    Shapes = Shape.Parallelogram,
                    IsHeightRequired = false,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.Pentagon,
                    IsHeightRequired = false,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.Rectangle,
                    IsHeightRequired = true,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = false
                },
                new ShapeItem
                {
                    Shapes = Shape.ScaleneTriangle,
                    IsHeightRequired = true,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                },
                new ShapeItem
                {
                    Shapes = Shape.Square,
                    IsHeightRequired = false,
                    IsLengthRequired = true,
                    IsRadiusRequired = false,
                    IsCalculationRequired = true
                }
            };
        }

        #region ViewModel properties
        
        private List<ShapeItem> _shapeItems;
        public List<ShapeItem> ShapeItems
        {
            get => _shapeItems;
            set => RaiseAndSetIfChanged(ref _shapeItems, value);
        }

        private ShapeItem _selectedShapeItem;
        public ShapeItem SelectedShapeItem
        {
            get => _selectedShapeItem;
            set
            {
                HeightUnit = 0;
                WidthUnit = 0;
                RadiusUnit = 0;
                RaiseAndSetIfChanged(ref _selectedShapeItem, value);
            }
        }

        private PointCollection _polygonPoints;
        public PointCollection PolygonPoints
        {
            get => _polygonPoints; 
            set => RaiseAndSetIfChanged(ref _polygonPoints, value);
        }

        private PointCollection _isoscelesTrianglePoints;
        public PointCollection IsoscelesTrianglePoints
        {
            get => _isoscelesTrianglePoints; 
            set => RaiseAndSetIfChanged(ref _isoscelesTrianglePoints, value);
        }

        private PointCollection _scaleneTrianglePoints;
        public PointCollection ScaleneTrianglePoints
        {
            get => _scaleneTrianglePoints;
            set => RaiseAndSetIfChanged(ref _scaleneTrianglePoints, value);
        }

        private PointCollection _parallelogramPoints;
        public PointCollection ParallelogramPoints
        {
            get => _parallelogramPoints;
            set => RaiseAndSetIfChanged(ref _parallelogramPoints, value);
        }

        private int _heightUnit;
        public int HeightUnit
        {
            get => _heightUnit;
            set => RaiseAndSetIfChanged(ref _heightUnit, value);
        }

        private int _widthUnit;
        public int WidthUnit
        {
            get => _widthUnit;
            set => RaiseAndSetIfChanged(ref _widthUnit, value);
        }

        private int _radiusUnit;
        public int RadiusUnit
        {
            get => _radiusUnit;
            set
            {
                HeightUnit = value * 2;
                WidthUnit = value * 2;
                RaiseAndSetIfChanged(ref _radiusUnit, value);
            }
        }

        private bool _isCircle;
        public bool IsCircle
        {
            get => _isCircle; 
            set => RaiseAndSetIfChanged(ref _isCircle, value);
        }

        private bool _isScaleneTriangle;
        public bool IsScaleneTriangle
        {
            get => _isScaleneTriangle; 
            set => RaiseAndSetIfChanged(ref _isScaleneTriangle, value);
        }

        private bool _isIsoscelesTriangle;
        public bool IsIsoscelesTriangle
        {
            get => _isIsoscelesTriangle;
            set => RaiseAndSetIfChanged(ref _isIsoscelesTriangle, value);
        }

        private bool _isRectangle;
        public bool IsRectangle
        {
            get => _isRectangle;
            set => RaiseAndSetIfChanged(ref _isRectangle, value);
        }

        private bool _isOval;
        public bool IsOval
        {
            get => _isOval;
            set => RaiseAndSetIfChanged(ref _isOval, value);
        }

        private bool _isPolygon;
        public bool IsPolygon
        {
            get => _isPolygon;
            set => RaiseAndSetIfChanged(ref _isPolygon, value);
        }

        private bool _isParallelogram;
        public bool IsParallelogram
        {
            get => _isParallelogram;
            set => RaiseAndSetIfChanged(ref _isParallelogram, value);
        }
        
        #endregion

    }
}
