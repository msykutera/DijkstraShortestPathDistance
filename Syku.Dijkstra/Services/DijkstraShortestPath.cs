using QuickGraph;
using QuickGraph.Algorithms.ShortestPath;
using System;
using System.Collections.Generic;

namespace Syku.Dijkstra
{
    public class DijkstraShortestPathService : IShortestPath
    {
        private AdjacencyGraph<string, Edge<string>> _graph = new AdjacencyGraph<string, Edge<string>>(true);
        private Dictionary<Edge<string>, double> _edgeCost;
        private DijkstraShortestPathAlgorithm<string, Edge<string>> _dijkstra;

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

            var a_b = new Edge<string>("A", "B");
            var a_d = new Edge<string>("A", "D");
            var b_a = new Edge<string>("B", "A");
            var b_c = new Edge<string>("B", "C");
            var b_e = new Edge<string>("B", "E");
            var c_b = new Edge<string>("C", "B");
            var c_f = new Edge<string>("C", "F");
            var c_j = new Edge<string>("C", "J");
            var d_e = new Edge<string>("D", "E");
            var d_g = new Edge<string>("D", "G");
            var e_d = new Edge<string>("E", "D");
            var e_f = new Edge<string>("E", "F");
            var e_h = new Edge<string>("E", "H");
            var f_i = new Edge<string>("F", "I");
            var f_j = new Edge<string>("F", "J");
            var g_d = new Edge<string>("G", "D");
            var g_h = new Edge<string>("G", "H");
            var h_g = new Edge<string>("H", "G");
            var h_i = new Edge<string>("H", "I");
            var i_f = new Edge<string>("I", "F");
            var i_j = new Edge<string>("I", "J");
            var i_h = new Edge<string>("I", "H");
            var j_f = new Edge<string>("J", "F");

            _graph.AddEdge(a_b);
            _graph.AddEdge(a_d);
            _graph.AddEdge(b_a);
            _graph.AddEdge(b_c);
            _graph.AddEdge(b_e);
            _graph.AddEdge(c_b);
            _graph.AddEdge(c_f);
            _graph.AddEdge(c_j);
            _graph.AddEdge(d_e);
            _graph.AddEdge(d_g);
            _graph.AddEdge(e_d);
            _graph.AddEdge(e_f);
            _graph.AddEdge(e_h);
            _graph.AddEdge(f_i);
            _graph.AddEdge(f_j);
            _graph.AddEdge(g_d);
            _graph.AddEdge(g_h);
            _graph.AddEdge(h_g);
            _graph.AddEdge(h_i);
            _graph.AddEdge(i_f);
            _graph.AddEdge(i_h);
            _graph.AddEdge(i_j);
            _graph.AddEdge(j_f);

            _edgeCost = new Dictionary<Edge<string>, double>(_graph.EdgeCount)
            {
                { a_b, 4 },
                { a_d, 1 },
                { b_a, 74 },
                { b_c, 2 },
                { b_e, 12 },
                { c_b, 12 },
                { c_f, 74 },
                { c_j, 12 },
                { d_e, 32 },
                { d_g, 22 },
                { e_d, 66 },
                { e_f, 76 },
                { e_h, 33 },
                { f_i, 11 },
                { f_j, 21 },
                { g_d, 12 },
                { g_h, 10 },
                { h_g, 2 },
                { h_i, 72 },
                { i_f, 31 },
                { i_h, 18 },
                { i_j, 7 },
                { j_f, 8 }
            };

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
    }
}
