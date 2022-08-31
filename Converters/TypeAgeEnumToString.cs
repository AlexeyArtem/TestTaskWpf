using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestTaskWpf
{
    class TypeAgeEnumToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new InvalidOperationException();
            string desc = "";

            if(value is TypeAge type)
            {
                switch (type)
                {
                    case TypeAge.BirthYears:
                        desc = "Год рождения";
                        break;
                    case TypeAge.NumberYears:
                        desc = "Возраст";
                        break;
                }
            }

            return desc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
