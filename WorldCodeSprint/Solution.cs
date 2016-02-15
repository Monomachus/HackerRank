using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        string S = Console.ReadLine();

        int result = 0;

        if (!string.IsNullOrWhiteSpace(S) && S.Length % 3 == 0) {
            string originalString = string.Empty;
            // modifications
            int sosTimes = S.Length / 3;
            Enumerable.Range(1, sosTimes).ToList().ForEach(i => originalString += "SOS");

            result = originalString.Zip(S, (x, y) => x == y).Count(z => !z);
        }

        Console.WriteLine(result);
        //Console.ReadKey();
    }
}

