using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class Utils
    {
        public static string ReverseString(this string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static List<string> ReadFile(string file)
        {
            List<string> data = new List<string>();

            using (StreamReader reader = new StreamReader(file))
            {
                string ln;
                while ((ln = reader.ReadLine()) != null)
                {
                    data.Add(ln);
                }
            }

            return data;
        }
        public static List<long> GetFactors(long number)
        {
            List<long> ret = new List<long>();

            ret.Add(number);

            int sqrt = (int)Math.Ceiling(Math.Sqrt(number));

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    ret.Add((long)(number / i));
                    ret.Add((long)i);
                }
            }

            if (sqrt * sqrt == number)
            {
                ret.Add(sqrt);
            }

            return ret.Distinct().ToList();
        }
        public static bool IsPrime(int number) { return IsPrime((long)number); }
        public static bool IsPrime(long number)
        {
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;
            if (number % 2 == 0 || number % 3 == 0)
                return false;
            long sqrt = (long)Math.Sqrt(number) + 1;

            for (long i = 5; i <= sqrt; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}
