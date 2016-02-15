//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//class Solution
//{

//    static void Main(String[] args)
//    {
//        string[] tokens_n = Console.ReadLine().Split(' ');
//        int n = Convert.ToInt32(tokens_n[0]);
//        int m = Convert.ToInt32(tokens_n[1]);
//        string[] c_temp = Console.ReadLine().Split(' ');
//        int[] c = Array.ConvertAll(c_temp, Int32.Parse);

//        int result = -1;

//        if (n > 100000 || (m > n))
//        {
//            return;
//        }

//        if (n == m)
//        {
//            result = 0;
//        }
//        else {
//            int[] distancesFromCities = new int[n];

//            // sorting 
//            Array.Sort(c);

//            for (int i = 0; i < distancesFromCities.Length; i++)
//            {
//                int stationDistance = -1;

//                for (int j = 0; j < c.Length; j++)
//                {
//                    if (i == c[j])
//                    {
//                        stationDistance = 0;
//                        break;
//                    }

//                    int distanceCityAndStation = Math.Abs(i - c[j]);

//                    if (stationDistance == -1) {
//                        stationDistance = distanceCityAndStation;
//                    }
//                    else if (stationDistance > distanceCityAndStation)
//                    {
//                        stationDistance = distanceCityAndStation;
//                    }
//                }

//                distancesFromCities[i] = stationDistance;
//            }

//            result = distancesFromCities.Max();
//        }

//        Console.WriteLine(result);
//    }
//}
