using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace UT4_Actividad_2
{
    class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((bool)value)
            {
                return "PaleGreen";
            }
            return "IndianRed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
