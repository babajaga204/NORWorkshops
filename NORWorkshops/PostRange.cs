

namespace NORWorkshops
{
    public class PostRange
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public PostRange(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
