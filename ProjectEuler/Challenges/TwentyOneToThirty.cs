using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Challenges
{
    public static class TwentyOneToThirty
    {
        public static object Solution(int challenge)
        {
            switch (challenge)
            {
                case 21:
                    return TwentyOne();
                case 22:
                    return TwentyTwo();
                case 23:
                    return TwentyThree();
                case 24:
                    return TwentyFour();
                case 25:
                    break;
                case 26:
                    break;
                case 27:
                    break;
                case 28:
                    break;
                case 29:
                    break;
                case 30:
                    break;
                default:
                    return "Unknown";
            }
            return "uNKNOWN";
        }

        private static long TwentyOne()
        {
            const int LIMIT = 10000;
            
            long a;
            long b;

            List<long> divisors;
            List<long> amicable = new List<long>();

            long sum;

            for (a = 1; a < LIMIT; a++)
            {
                divisors = Utils.GetFactors(a);
                sum = divisors.Sum();
                b = sum -= a;
                if ((Utils.GetFactors(b).Sum() - b) == a)
                {
                    if (a != b)
                    {
                        if (false == amicable.Exists(x => x == a) && false == amicable.Exists(x => x == b))
                        {
                            amicable.Add(a);
                            amicable.Add(b);
                        }
                    }
                }
            }

            return amicable.Sum();
        }
        private static long TwentyTwo()
        {
            const string FILENAME = @"..\..\Data\TwentyTwo.txt";
            List<string> data = Utils.ReadFile(FILENAME); // will read into one line
            List<string> names = new List<string>();

            Dictionary<char, int> alpha_to_int = new Dictionary<char, int>()
            {
                {'A', 1 }, {'B', 2 }, {'C', 3 }, {'D', 4 }, {'E', 5 }, {'F', 6 }, {'G', 7 },
                {'H', 8 }, {'I', 9 }, {'J', 10 }, {'K', 11 }, {'L', 12 }, {'M', 13 }, {'N', 14 },
                {'O', 15 }, {'P', 16 }, {'Q', 17 }, {'R', 18 }, {'S', 19 }, {'T', 20 }, {'U', 21 },
                {'V', 22 }, {'W', 23 }, {'X', 24 }, {'Y', 25 }, {'Z', 26 }
            };

            string[] n = data.FirstOrDefault().Split(',');
            for (int i = 0; i < n.Length; i++)
            {
                names.Add(n[i].Trim(new char[] { '"', ' ', '\\' }));
            }
            names.Sort();

            int count = 0;
            long result = 0;

            foreach (string name in names)
            {
                count++;
                char[] cArr = name.ToCharArray();
                int tmp = 0;
                for (int i = 0; i < cArr.Length; i++)
                {
                    tmp += alpha_to_int[cArr[i]];
                }
                result += (tmp * count);
            }

            // Could make this less garbagey and reduce it down by at least 75%

            return result;
        }
        private static long TwentyThree()
        {
            const long LIMIT = 28123;
            long sum;
            List<long> abundant = new List<long>();

            for (int i = 12; i < LIMIT; i++)
            {
                List<long> divisors = Utils.GetFactors(i);
                sum = divisors.Sum();
                sum -= i;
                if (sum > i)
                    abundant.Add(i);
            }

            long ret = 0;
            bool[] exclude = new bool[LIMIT];
            for (int x = 0; x < abundant.Count; x++)
            {
                for (int y = x; y < abundant.Count; y++)
                {
                    if (abundant[x] + abundant[y] < LIMIT)
                    {
                        exclude[abundant[x] + abundant[y]] = true;
                    }
                }
            }
            for (int i = 0; i < LIMIT; i++)
            {
                if (exclude[i] == false)
                    ret += i;
            }
            return ret;
        }
        private static long TwentyFour()
        {
            return new long { };
        }
    }
}
