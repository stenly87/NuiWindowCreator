using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NuiWindowCreator
{
    public class ArrayComboEntryConverter : IMultiValueConverter
    {
        static bool lastBind = false;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            lastBind = (bool)values[1];
            if (lastBind == true)
                return values[0].ToString();
            List<object[]> val = values[0] as List<object[]>;
            if (val == null)
            {
                lastBind = true;
                return values[0].ToString();
            }
            string result = string.Join("\n", val.Select(s => s[0].ToString()));
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string val = value.ToString();
            if (lastBind)
                return new object[2] { val, true };
            int nCount = 0;
            return new object[2]{
                val.Split(new char[]{'\n','\r'}, StringSplitOptions.RemoveEmptyEntries).Select(s => new object[] { s, ++nCount }).ToList(),
                false };
        }
    }
}
