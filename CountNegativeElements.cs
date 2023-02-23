using System.Text;

namespace CountNegative
{
    static class CountNegativeElements
    {
        public static string CountNegativeValues(out int count, params int[] numbers)
        {
            count = 0;
            StringBuilder arr = new();
            string negativeElements;

            if (numbers.Length == 0)
            {
                return "Error!!!, No Element passed";
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    count++;
                    arr.Append(numbers[i]);
                    arr.Append(", ");
                }
            }
            if (arr.Length > 0)
            {
                arr.Remove(arr.Length - 2, 1);
            }
            negativeElements = arr.ToString();
            return negativeElements;
        }
    }
}
