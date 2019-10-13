using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DrawShapes.ValueConverter
{
    /// <summary>
    /// Represents a value converter to convert between boolean and Visibility values.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        private Visibility _visibilityWhenFalse = Visibility.Collapsed;
        private Visibility _visibilityWhenTrue = Visibility.Visible;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool b && b)
            {
                return _visibilityWhenTrue;
            }
            return _visibilityWhenFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (value is Visibility visibility && visibility == _visibilityWhenTrue);
        }
    }
}