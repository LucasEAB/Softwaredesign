using System;

namespace sdaufgabe3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Decimal to Hexal: " + ConvertDecimalToHexal(Convert.ToInt32(args[0])));
            Console.WriteLine("Hexal to Dezimal: " + ConvertHexalToDezimal(Convert.ToInt32(args[0])));
            Console.WriteLine("to Base from Decimal: " + ConvertToBaseFromDecimal(Convert.ToInt32(args[0]), Convert.ToInt32(args[1])));
            Console.WriteLine("to Decimal from Base: " + ConvertToDecimalFromBase(Convert.ToInt32(args[0]), Convert.ToInt32(args[1])));
            Console.WriteLine("Number to Base from Base: " + ConvertNumberToBaseFromBase(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), Convert.ToInt32(args[2])));
        }
        public static int ConvertDecimalToHexal(int dec)
        {
            return ConvertToBaseFromDecimal(6, dec);
        }

        public static int ConvertHexalToDezimal(int hexal)
        {
            return ConvertToDecimalFromBase(6, hexal);
        }

        public static int ConvertToBaseFromDecimal(int toBase, int dec)
        {
            int[] arr = new int[4];

            if (0 <= dec && dec <= 1023)
            {
                for (int i = 0; i <= dec.ToString().Length + 2; i++)
                {
                    int value = dec / toBase;
                    int modulo = dec % toBase;
                    arr[i] = modulo;
                    dec = value;
                }
            }

            Array.Reverse(arr);
            int newArray = Convert.ToInt32((string.Join("", arr)));
            return newArray;
        }
        public static int ConvertToDecimalFromBase(int fromBase, int number)
        {
            int length = number.ToString().Length;
            int[] array = new int[length];
            int[] newArray = new int[length];
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                array[i] = number % 10;
                number /= 10;
                newArray[i] += array[i] * Convert.ToInt32(Math.Pow(fromBase, i));
            }

            for (int j = 0; j < newArray.Length; j++)
            {
                sum += newArray[j];
            }
            return sum;
        }
        public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {

            if (2 <= fromBase && fromBase <= 10 && 2 <= toBase && toBase <= 10)
            {
                int dec = ConvertToDecimalFromBase(fromBase, number);
                int value = ConvertToBaseFromDecimal(toBase, dec);
                return value;
            }
            return -1;
        }
    }
}
