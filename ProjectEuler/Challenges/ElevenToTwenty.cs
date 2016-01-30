using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Challenges
{
    public static class ElevenToTwenty
    {
        public static object Solution(int challenge)
        {
            switch (challenge)
            {
                case 11:
                    return Eleven();
                case 12:
                    return Twelve();
                case 13:
                    return Thirteen();
                case 14:
                    return Fourteen();
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                default:
                    return null;
            }
            return null;
        }

        private static long Eleven()
        {
            const int LIMIT = 4;

            int[,] grid = new int[20, 20]
            {
                { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 },
                { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 },
                { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 },
                { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 },
                { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 },
                { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 },
                { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 },
                { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 },
                { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 },
                { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 },
                { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 },
                { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 },
                { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 },
                { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 },
                { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 },
                { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 },
                { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 },
                { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 },
                { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 },
                { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 },
            };

            decimal result = 0;
            decimal tmp;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {

                    // REMEMBER ARRAY WILL NEED (LIMIT-1)

                    // V
                    if (row < grid.GetLength(1) - LIMIT)
                    {
                        tmp = grid[row, col];
                        for (int i = 1; i < LIMIT; i++)
                        {
                            tmp *= grid[row + i, col];
                        }
                        result = Math.Max(result, tmp);
                    }

                    // H
                    if (col < grid.GetLength(0) - LIMIT)
                    {
                        tmp = grid[row, col];
                        for (int i = 1; i < LIMIT; i++)
                        {
                            tmp *= grid[row, col + i];
                        }
                        result = Math.Max(result, tmp);
                    }

                    // Dd
                    if ((col < grid.GetLength(0) - (LIMIT - 1)) && (row < grid.GetLength(1) - LIMIT))
                    {
                        tmp = grid[row, col];
                        for (int i = 1; i < LIMIT; i++)
                        {
                            //tmp *= grid[row + i, col + i];
                            decimal x = grid[row + i, col + i];
                            tmp *= x;
                        }
                        result = Math.Max(result, tmp);
                    }

                    // Du
                    if ((row < grid.GetLength(0) - LIMIT) && (col >= LIMIT - 1))
                    {
                        tmp = grid[row, col];
                        for (int i = 1; i < LIMIT; i++)
                        {
                            tmp *= grid[row + i, col - i];
                        }
                        result = Math.Max(result, tmp);
                    }
                }
            }

            return (long)result;
        }
        private static long Twelve()
        {
            const int LIMIT = 500;

            int n = 1;
            while (true)
            {
                decimal t = (n * (n + 1)) / 2;
                List<long> factors = Utils.GetFactors((long)t);
                if (factors.Count > LIMIT)
                    return (long)t;
                n++;
            }
        }
        private static string Thirteen()
        {
            string file = string.Format(@"{0}\..\..\Data\Thirteen.txt", Environment.CurrentDirectory);
            List<string> data = Utils.ReadFile(file);

            long result = 0;
            foreach (string line in data)
            {
                long number = Convert.ToInt64(line.Substring(0, 15));
                result += number;

            }
            return result.ToString().Substring(0, 10);
        }
        private static long Fourteen()
        {
            const int LIMIT = 1000000;

            long maxChainLength = 0;
            long startNum = 0;

            long seqVal = 0;
            for (int i = 2; i < LIMIT; i++)
            {
                seqVal = i;
                int chainLength = 0;
                while (seqVal != 1)
                {
                    chainLength++;
                    if (seqVal % 2 == 0)
                        seqVal = seqVal / 2;
                    else
                        seqVal = (3 * seqVal) + 1;
                    if (seqVal == 1)
                    {
                        if (chainLength > maxChainLength)
                        {
                            maxChainLength = chainLength;
                            startNum = i;
                        }
                    }
                }
            }
            return startNum;
        }
        private static long Fifteen()
        {
            return 0;
        }
    }
}
