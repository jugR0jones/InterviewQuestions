using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions
{

    /// <summary>
    /// A graph with a single root element
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="S"></typeparam>
    public abstract class Graph<T, S>
    {
        public Vertex<T, S> Root { get; protected set; }

        // Add an edge to the graph
        public abstract void AddEdge(Edge<T, S> edge, Vertex<T, S> toVertex);

        public Graph() {
            this.Root = new Vertex<T, S>();
        }

        public void Clear()
        {
            this.Root = new Vertex<T, S>();
        }
    }

    public class Edge<T, S>
    {
        public T Value { get; set; }
        public Vertex<T, S> Vertex { get; set; }

        public Edge()
        {
            this.Vertex = new Vertex<T, S>();
        }
    }

    public class Vertex<T, S>
    {
        public S Value { get; set; }
        public IList<Edge<T, S>> Edges { get; set; }

        public Vertex()
        {
            this.Edges = new List<Edge<T, S>>();
        }
    }

    public static class GraphExtensionMethods
    {
        // Search through the edges and return the edge with the matching value
        public static Edge<string, string> EdgeStartingWithCharacter(this IList<Edge<string, string>> edges, char ch)
        {
            // Hopefully this returns the children in the order they were added and there is no need to add further ordering
            //            return children.Where(x => x.Data == data).FirstOrDefault();
            return edges.Where(x => x.Value[0] == ch).FirstOrDefault();
        }

    }
}
