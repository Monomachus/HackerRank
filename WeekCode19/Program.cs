using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeekCode19
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DEFAULT_VALUE = 1000000;

            List<GraphEdge> listEdges = new List<GraphEdge>()
            {
                new GraphEdge { FromNode = 'D', ToNode = 'A' },
                new GraphEdge { FromNode = 'A', ToNode = 'B' },
                new GraphEdge { FromNode = 'B', ToNode = 'C' },
                new GraphEdge { FromNode = 'C', ToNode = 'D' },
                new GraphEdge { FromNode = 'A', ToNode = 'C' },
                new GraphEdge { FromNode = 'B', ToNode = 'D' }
            };

            string[] weights_temp = Console.ReadLine().Split(' ');
            int[] weights = Array.ConvertAll(weights_temp, Int32.Parse);

            var i = 0;
            var min = DEFAULT_VALUE;
            var result = 0 - DEFAULT_VALUE;
            GraphEdge minEdge = null;

            foreach (var edge in listEdges)
            {
                edge.Weight = weights[i];

                if (min > weights[i])
                {
                    min = weights[i];
                    minEdge = edge;
                }

                i++;
            }

            var dict = listEdges.Select(singleEdge =>
                new KeyValuePair<string, GraphEdge>(singleEdge.Key, singleEdge)).
                ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


            int iterations = (minEdge.ToNode == 'A' || minEdge.ToNode == 'B') ? 2 : 1;

            for (int j = 0; j < iterations; j++)
            {
                var minCycleEdges = new List<GraphEdge>();
                minCycleEdges.Add(minEdge);

                var minEdgeFromNode = minEdge.FromNode;
                var nextToNode = minEdge.ToNode;
                GraphEdge nextEdge = minEdge;

                do
                {
                    var toNode = dict[nextEdge.Key].ToNode;
                    var edgeSearch = dict.Where(kvp => kvp.Key.StartsWith(toNode.ToString()));


                    if (toNode == 'A' || toNode == 'B') {
                        edgeSearch = edgeSearch.Skip(j).Take(1);
                    }

                    var edge = edgeSearch.First().Value;

                    minCycleEdges.Add(edge);
                    nextToNode = edge.ToNode;
                    nextEdge = edge;
                }
                while (minEdgeFromNode != nextToNode);

                int sum = minCycleEdges.Sum(edge => edge.Weight);
                result = sum < 0 ? Math.Max(Math.Abs(sum), result) : Math.Max(-1, result);
            }

            //int result = Math.Abs(sum);

            Console.WriteLine(result);
        }
    }

    public class GraphEdge
    {
        public char FromNode { get; set; }
        public char ToNode { get; set; }
        public int Weight { get; set; }
        public string Key { get { return FromNode + "" + ToNode; } }
    }
}
