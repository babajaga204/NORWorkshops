

using System;

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

        public void Show()
        {
            Console.WriteLine($"{MinValue} - {MaxValue}");
        }

        public bool CheckIfInRange(int workshopZip)
        {
            return workshopZip >= MinValue && workshopZip <= MaxValue;
        }
    }
}
