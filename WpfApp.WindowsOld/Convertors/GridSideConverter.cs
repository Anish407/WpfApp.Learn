using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp.WindowsOld.Enums;

namespace WpfApp.WindowsOld.Convertors
{
    public class GridSideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GridSide side = (GridSide)value;
            return (int)side;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
