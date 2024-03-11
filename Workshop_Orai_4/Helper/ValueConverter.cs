using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Workshop_Orai_4.Helper
{
    internal class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((int)value <=5)
            {
                SolidColorBrush myBrush1 = new SolidColorBrush(Colors.DarkGreen);
                return myBrush1;
            }
            if ((int)value > 5 && (int)value <=10)
            {
                SolidColorBrush myBrush2 = new SolidColorBrush(Colors.Green);
                return myBrush2;
            }
            if ((int)value > 10 && (int)value <= 15)
            {
                SolidColorBrush myBrush3 = new SolidColorBrush(Colors.GreenYellow);
                return myBrush3;
            }
            else
            {
                SolidColorBrush myBrush4 = new SolidColorBrush(Colors.Red);
                return myBrush4;
            }


           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
