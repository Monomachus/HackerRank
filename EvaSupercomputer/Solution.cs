using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaSupercomputer
{
    class Solution
    {
        private const string GOOD_POSITION = "G";

        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);

            var grid = new char[n][m];

            string[] lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();

                for (int j = 0; j < chars.Length; j++)
                {
                    grid[i][j] = chars[j];
                }
            }

            // select middle 
            // find how much of a cross can we have
            var product = -1;

            var initSize = 3;
            var lastKnownCenterY = 

            for (int i = (initSize / 2) - 1; i < n; i++)
            {
                while (new string(grid[i]).Contains(String.Concat(Enumerable.Repeat(GOOD_POSITION, initSize)))) {
                    if (initSize + 2 <= n && initSize + 2 <= m)
                    {
                        i++;
                        initSize += 2;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
