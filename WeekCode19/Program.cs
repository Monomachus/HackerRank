using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeekCode19
{
    class Program
    {
        private const int UPPER_LIMIT = 20;

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

            var dictCycles = new Dictionary<string, List<GraphEdge>>();

            var dict = listEdges.Select(singleEdge =>
                new KeyValuePair<string, GraphEdge>(singleEdge.Key, singleEdge)).
                ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


            foreach (var edge in listEdges)
            {
                var cycles = new List<GraphEdge>();

                cycles.Add(edge);

                var initialEdgeFromNode = edge.FromNode;
                var nextToNode = edge.ToNode;
                GraphEdge nextEdge = edge;

                do
                {
                    var toNode = dict[nextEdge.Key].ToNode;
                    var edgeSearch = dict.Where(kvp => kvp.Key.StartsWith(toNode.ToString()));

                    var searchedEdge = edgeSearch.First().Value;

                    cycles.Add(searchedEdge);
                    nextToNode = searchedEdge.ToNode;
                    nextEdge = searchedEdge;
                }
                while (initialEdgeFromNode != nextToNode);

                dictCycles.Add(new string(cycles.Select(a => a.Key).Aggregate((a, b) => a + b).ToCharArray().Distinct().ToArray()), cycles);
            }

            var negativeCycles = dictCycles.Where(kvp => kvp.Value.Sum(g => g.Weight) < 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            if (negativeCycles.Any())
            {
                minEdge = negativeCycles.SelectMany(kvp => kvp.Value).OrderBy(g => g.Weight).First();

                var minEdgeWeight = minEdge.Weight;

                var tempEdgeWeight = minEdgeWeight;

                foreach (var cycles in negativeCycles)
                {
                    int tempSum = cycles.Value.Sum(g => g.Weight);
                    tempEdgeWeight = Math.Max(Math.Abs(tempSum), tempEdgeWeight);
                }

                result = tempEdgeWeight;

            }
            else {
                result = -1;
            }

            Console.WriteLine(result);
            Console.ReadKey();
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
