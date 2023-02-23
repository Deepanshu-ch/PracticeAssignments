namespace Errorhandling
{
    internal class MakeArray
    {
        protected int dividendSize, divisorSize;
        protected int[]? dividend;
        protected int[]? divisor;

        public MakeArray()
        {
            Console.Write("Enter Dividend Size:");
            _ = int.TryParse(Console.ReadLine(), out dividendSize);
            Console.WriteLine();
            Console.Write("Enter Divisor Size:");
            _ = int.TryParse(Console.ReadLine(), out divisorSize);
        }

        public MakeArray(int dividendSize, int divisorSize)
        {
            this.dividendSize = dividendSize;
            this.divisorSize = divisorSize;
        }

        public MakeArray(int[] dividend, int[] divisor)
        {
            this.dividend = dividend;
            this.divisor = divisor;
            divisorSize = divisor.Length;
            dividendSize = dividend.Length;
        }

        public int[] CreateDividendArray()
        {
            dividend = new int[dividendSize];

            Console.WriteLine("\nEnter Dividend Array:");

            for (int i = 0; i < dividendSize; i++)
            {
                _ = int.TryParse(Console.ReadLine(), out dividend[i]);
            }

            return dividend;
        }

        public int[] CreateDivisorArray()
        {
            divisor = new int[divisorSize];

            Console.WriteLine("\nEnter Divisor Array:");

            for (int i = 0; i < divisorSize; i++)
            {
                _ = int.TryParse(Console.ReadLine(), out divisor[i]);
            }

            return divisor;
        }

        public void ShowDivisorArray()
        {
            Console.Write("Divisor Array: ");
            if (divisor!=null)
            {
                foreach (int item in divisor)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine(); 
            }
        }

        public void ShowDividendArray()
        {
            Console.Write("Dividend Array: ");
            if (dividend!=null)
            {
                foreach (int item in dividend)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine(); 
            }
        }

    }

    class Quotient : MakeArray
    {
        int[]? result;

        public Quotient() : base() { }

        public Quotient(int dividendSize, int divisorSize) : base(dividendSize, divisorSize) { }

        public Quotient(int[] dividend, int[] divisor) : base(dividend, divisor) { }

        public int[] Divide()
        {
            Console.WriteLine();
            result = new int[dividendSize];

            for (int i = 0; i < result.Length; i++)
            {
                try
                {
                    if(dividend!=null && divisor!=null)
                    {
                        result[i] = dividend[i] / divisor[i];
                        Console.WriteLine(dividend[i] + " / " + divisor[i] + " is:" + result[i]);
                    }
                }
                catch (DivideByZeroException) { Console.WriteLine("Can't delete by Zero"); }
            }

            return result;
        }

        public void ShowResult()
        {
            Console.Write("\nResultant Array: ");
            if (result!=null)
            {
                foreach (int item in result)
                {
                    Console.Write(item + " ");
                } 
            }
            Console.WriteLine();
        }
    }
}
