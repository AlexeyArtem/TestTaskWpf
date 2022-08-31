using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestTaskWpf
{
    class DepartmentsSalaryToTotalCompanyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ReadOnlyObservableCollection<object> items) 
            {
                decimal total = 0;
                foreach (CollectionViewGroup viewGroup in items) 
                {
                    foreach (Employee emp in viewGroup.Items) 
                    {
                        total += emp.Salary;
                    }
                }
                return total.ToString();
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
