using QuickGraph;
using QuickGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;

namespace Syku.Dijkstra
{
    public class DijkstraShortestPathService : IShortestPath
    {
        private readonly AdjacencyGraph<string, Edge<string>> _graph = new AdjacencyGraph<string, Edge<string>>(true);
        private readonly Dictionary<Edge<string>, double> _edgeCost = new Dictionary<Edge<string>, double>();
        private readonly DijkstraShortestPathAlgorithm<string, Edge<string>> _dijkstra;

        public DijkstraShortestPathService()
        {
            _graph.AddVertex("A");
            _graph.AddVertex("B");
            _graph.AddVertex("C");
            _graph.AddVertex("D");
            _graph.AddVertex("E");
            _graph.AddVertex("F");
            _graph.AddVertex("G");
            _graph.AddVertex("H");
            _graph.AddVertex("I");
            _graph.AddVertex("J");

            AddEdge("A", "B", 4);
            AddEdge("A", "D", 1);
            AddEdge("B", "A", 74);
            AddEdge("B", "C", 2);
            AddEdge("B", "E", 12);
            AddEdge("C", "B", 12);
            AddEdge("C", "F", 74);
            AddEdge("C", "J", 12);
            AddEdge("D", "E", 32);
            AddEdge("D", "G", 22);
            AddEdge("E", "D", 66);
            AddEdge("E", "F", 76);
            AddEdge("E", "H", 33);
            AddEdge("F", "I", 11);
            AddEdge("F", "J", 21);
            AddEdge("G", "D", 12);
            AddEdge("G", "H", 10);
            AddEdge("H", "G", 2);
            AddEdge("H", "I", 72);
            AddEdge("I", "F", 31);
            AddEdge("I", "J", 18);
            AddEdge("I", "H", 7);
            AddEdge("J", "F", 8);

            _dijkstra = new DijkstraShortestPathAlgorithm<string, Edge<string>>(_graph, e => _edgeCost[e]);
        }

        public double GetDistance(string from, string to)
        {
            _dijkstra.Compute(from);
            if (_dijkstra.TryGetDistance(to, out double distance))
            {
                return distance;
            }
            else
            {
                throw new Exception($"Couldn't get distance from {from} to {to}.");
            }
        }

        private void AddEdge(string from, string to, double weight)
        {
            var edge = new Edge<string>(from, to);
            _graph.AddEdge(edge);
            _edgeCost.Add(edge, weight);
        }
    }
}
