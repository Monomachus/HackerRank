using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackBookingHoliday
{
    class MarkAndToys
    {
        static void Main(string[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] prices_temp = Console.ReadLine().Split(' ');
            int[] prices = Array.ConvertAll(prices_temp, Int32.Parse);

            Array.Sort(prices);

            var priceAllToys = 0;
            var numberToys = 0;

            foreach (var toyPrice in prices)
            {
                priceAllToys += toyPrice;

                if (priceAllToys >= k) {
                    break;
                }

                numberToys++;
            }

            Console.WriteLine(numberToys);
            Console.ReadKey();
        }
    }
}
