using System.Globalization;

namespace MemoryCards.Infrastructure.Converters
{
    public  class DivideConverter:MultiConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2) return null;
            if (values.Take(2).Any(v => v == null)) return null;
            float temp = 0;
            var nums = values
                .Take(2)
                .Where(v=>float.TryParse(v.ToString(), out temp))
                .Select(v=>(int)temp)
                .ToList();

            if(nums.Count!=2)return null;
            var result = nums[0] / nums[1];
            return result;

        }
    }
}
