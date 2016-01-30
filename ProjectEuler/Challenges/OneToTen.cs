using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Challenges
{
    public static class OneToTen
    {
        public static object Solution(int challenge)
        {
            switch (challenge)
            {
                case 1:
                    return One();
                case 2:
                    return Two();
                case 3:
                    return Three();
                case 4:
                    return Four();
                case 5:
                    return Five();
                case 6:
                    return Six();
                case 7:
                    return Seven();
                case 8:
                    return Eight();
                case 9:
                    return Nine();
                case 10:
                    return Ten();
                default:
                    return "Unknown challenge";
            }
        }

        private static int One()
        {
            const int LIMIT = 1000;

            int result = 0;
            for (int i = LIMIT - 1; i > 0; i--)
            {
                if ((i % 3 == 0) || (i % 5 == 0)) result += i;
            }
            return result;
        }
        private static int Two()
        {
            const long LIMIT = 4000000;
            List<int> fibSeq = new List<int>();

            int a = 0;
            int b = 1;
            while (true)
            {
                int c = a;
                a = b;
                b = c + b;
                if (b > LIMIT) break;
                fibSeq.Add(b);
            }

            return fibSeq.Where(x => x % 2 == 0).Sum();
        }
        private static long Three()
        {
            const long LIMIT = 600851475143;

            List<long> factors = Utils.GetFactors(LIMIT);
            return factors.FindLast(x => Utils.IsPrime(x) == true);
        }
        private static int Four()
        {
            int palindrome = 0;
            int result;
            for (int a = 1; a < 1000; a++)
            {
                for (int b = 1; b < 1000; b++)
                {
                    result = a * b;
                    string str = result.ToString();
                    if (str == str.ReverseString())
                        if (result > palindrome)
                            palindrome = result;
                }
            }
            return palindrome;
        }
        private static long Five()
        {
            const int LIMIT = 20;

            long number = 1;
            while (true)
            {
                int count = 0;
                for (int i = 1; i <= LIMIT; i++)
                {
                    if (number % i == 0)
                        count++;
                    else break;
                    if (count == LIMIT)
                        return number;
                }
                number++;
            }
        }
        private static long Six()
        {
            const int LIMIT = 100;

            long sum_of_square = 0;
            long square_of_sum = 0;
            for (int i = 1; i <= LIMIT; i++)
            {
                sum_of_square += i * i;
                square_of_sum += i;
            }
            square_of_sum = square_of_sum * square_of_sum;
            return (square_of_sum - sum_of_square);
        }
        private static long Seven()
        {
            const int LIMIT = 10001;
            int count = 0;
            int i = 1;
            while (true)
            {
                if (Utils.IsPrime(i))
                {
                    count++;
                    if (count == LIMIT)
                        return i;
                }
                i++;
            }
        }
        private static long Eight()
        {
            const int LIMIT = 13;
            string full = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            int[] items = new int[LIMIT];

            long tmp;
            long result = 0;
            char[] charArray = full.ToCharArray();
            for (int n = LIMIT - 1; n < charArray.Length - 1; n++)
            {
                int count = LIMIT - 1;
                for (int i = n; i > (n-LIMIT); i--)
                {
                    items[count] = (int)Char.GetNumericValue(charArray[i]);
                    count--;
                }
                tmp = 1;
                foreach (int x in items)
                {
                    tmp = tmp * x;
                }
                if (tmp > result)
                    result = tmp;
            }
            return result;
        }
        private static long Nine()
        {
            const int LIMIT = 1000;

            for (int a = 1; a < LIMIT; a++)
            {
                for (int b = a+1; b < LIMIT; b++)
                {
                    int aSq = a * a;
                    int bSq = b * b;
                    int cSq = aSq + bSq;
                    double c = Math.Sqrt(cSq);
                    if (c % 1 ==0 )
                        if (a + b + c == 1000)
                            return (long)(a * b * c);
                }
            }
            return -1;
        }
        private static long Ten()
        {
            const int LIMIT = 2000000;

            long result = 0;
            for (int i = LIMIT; i > 0; i--)
            {
                if (Utils.IsPrime(i))
                    result += i;
            }

            return result;
        }
    }
}
