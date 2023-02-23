namespace Array
{
    static class MakeArray
    {
        public static int[] CreateArray(int length)
        {
            int[] array = new int[length];
            int value;
            Console.WriteLine("Enter values of array:");
            for (int i = 0; i < length; i++)
            {
                value = Convert.ToInt32(Console.ReadLine());
                array[i] = value;
            }

            return array;
        }
    }
}
