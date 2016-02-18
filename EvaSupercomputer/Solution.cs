using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaSupercomputer
{
    class Solution
    {
        private const char GOOD_POSITION = 'G';

        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);

            var grid = new char[n][];

            string[] lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();
                grid[i] = chars;
            }

            // select middle 
            // find how much of a cross can we have
            int? product = null;
            var crossesFound = new List<Tuple<int, int>>();

            var initSize = 3;
            var lastKnownCenterY = -1;
            var lastKnownCenterX = -1;

            for (int i = (initSize / 2); i < n; i++)
            {
                if (crossesFound.Count > 1) break;

                var row = new string(grid[i]);

                while (row.Contains(string.Concat(Enumerable.Repeat(GOOD_POSITION, initSize))))
                {
                    if (initSize + 2 <= n && initSize + 2 <= m && grid.Length >= (i+1) + initSize / 2)
                    {
                        lastKnownCenterY = i;
                        i++;
                        initSize += 2;
                    }
                    else
                    {
                        break;
                    }
                }

                var goodColumnFound = false;

                var initX = row.IndexOf(String.Concat(Enumerable.Repeat(GOOD_POSITION, initSize)),
                        StringComparison.InvariantCulture);

                while (lastKnownCenterY != -1 && !goodColumnFound && initSize > 1)
                {

                    var halfCross = initSize / 2;
                    var possibleKnownCenterX = initX + halfCross;
                    var goodColumn = true;

                    if (grid.Length >= lastKnownCenterY + halfCross)
                    {
                        if (lastKnownCenterY - halfCross < 0) {
                            initSize -= 2;
                            i--;
                            continue;
                        }

                        for (int j = lastKnownCenterY - halfCross; j < lastKnownCenterY + halfCross; j++)
                        {
                            if (grid[j][possibleKnownCenterX] != GOOD_POSITION)
                            {
                                goodColumn &= false;
                                break;
                            }
                        }

                        if (!goodColumn)
                        {
                            if (row.Substring(initX + 1).Contains(String.Concat(Enumerable.Repeat(GOOD_POSITION, initSize))))
                            {
                                initX += 1;
                            }
                            else
                            {
                                initSize -= 2;
                                i--;
                            }
                        }
                        else {
                            goodColumnFound = true;
                            lastKnownCenterX = possibleKnownCenterX;
                        }
                    }
                    else {
                        break;
                    }
                }

                if (lastKnownCenterX != -1 && lastKnownCenterY != -1)
                {
                    if (initSize == 1)
                    {
                        product = 1;
                    }
                    else {
                        var temp_product =  4 * (initSize / 2) + 1;
                        if (!product.HasValue) {
                            product = 1;
                        }
                        product *= temp_product;
                        crossesFound.Add(Tuple.Create(lastKnownCenterX, lastKnownCenterY));
                        lastKnownCenterY = -1;
                        lastKnownCenterX = -1;
                    }
                }
            }

            Console.WriteLine(product);
            Console.ReadKey();
        }
    }
}
