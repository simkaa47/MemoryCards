using System.Globalization;

namespace MemoryCards.Infrastructure.Converters
{
    public class MultiConverter : IMultiValueConverter
    {
        public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
