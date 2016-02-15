using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaSupercomputer
{
    class Solution
    {
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);

            var grid = new string[n, m];

            string[] lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            for (int i = 0; i < lines.Length; i++)
            {
                string[] chars = lines[i].Select(c => c.ToString()).ToArray();

                for (int j = 0; j < chars.Length; j++)
                {
                    grid[i, j] = chars[j];
                }
            }

            // select middle 
            // find how much of a cross can we have

        }
    }
}
