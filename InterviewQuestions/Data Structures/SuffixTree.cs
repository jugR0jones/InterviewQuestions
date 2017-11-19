using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions
{
    public class SuffixTree : Graph<string, string>
    {

        public SuffixTree() : base()
        {
        }

        public SuffixTree(string str)
        {
            this.AddString(str);
        }

        #region Graph Method Overrides

        public override void AddEdge(Edge<string, string> edge, Vertex<string, string> toVertex)
        {

        }

        #endregion


        // Add naively, that is, each edge is one letter long regardless
        public void AddString(string str)
        {
            // For now, add a terminating character.
            //if(!str.EndsWith("$"))
            //{
            //    str = str + "$";
            //}

            for(int i=0; i < str.Length; i++)
            {
                // The root leaf has no value, but it shares edges with it's leaves. So look at the edges to determine if they are the correct edge we should be adding the string to
                Edge<string, string> edge = Root.Edges.EdgeStartingWithCharacter(str[i]);
                if(edge == null)
                {
                    // The edge does not exist, so we add one
                    edge = new Edge<string, string>
                    {
                        Value = str.Substring(i),
                        Vertex = new Vertex<string, string>()
                    };
                    Root.Edges.Add(edge);

                    continue;
                }

                // At this point, we have an edge where the first letter of the edge matches the first letter of our substring
                string substring = str.Substring(i);

                // 1. substring matches the edge completely, in which case we continue checking as this case is already in the list
                if(edge.Value == substring)
                {
                    continue;
                }

                string newEdgeSuffix = "";
                // 2. If the edge value is a substring of the substring, walk down the edge and check each value
                if (edge.Value.Length < substring.Length)
                {
                    for (int j = 0; j < edge.Value.Length; j++)
                    {
                        if(edge.Value[j] == substring[j])
                        {
                            newEdgeSuffix += edge.Value[j];
                        } else
                        {
                            break;
                        }
                    }

                    Edge<string, string> anotherNewEdge = new Edge<string, string>
                    {
                        Value = substring.Substring(newEdgeSuffix.Length),
                        Vertex = new Vertex<string, string>()
                    };

                    edge.Vertex.Edges.Add(anotherNewEdge);

                    continue;
                }
                
                // 3. If the substring is a substring of the edge, then split the value of the edge and insert a new edge
                for(int j=0; j < substring.Length; j++)
                {
                    if(edge.Value[j] == substring[j])
                    {
                        newEdgeSuffix += substring[j];
                    } else
                    {
                        break;
                    }
                }

                // The new edge value for the existing edge
                string newEdgeValue1 = newEdgeSuffix;
                // The new edge value for the new edge
                string newEdgeValue2 = edge.Value.Substring(newEdgeSuffix.Length);

                // 3.1 Change value of edge E1
                edge.Value = newEdgeValue1;
                // 3.2 Create Edge E2
                Edge<string, string> newEdge = new Edge<string, string>
                {
                    // 3.3 Move vertex V1 to Edge E2
                    Vertex = edge.Vertex,
                    Value = newEdgeValue2
                };
                // 3.4 Create Vertex V2
                Vertex<string, string> newVertex = new Vertex<string, string>();
                // 3.5 Add Vertex V2 to Edge E1
                edge.Vertex = newVertex;
                // 3.6 Add edge E2 to Vertex V2
                edge.Vertex.Edges.Add(newEdge);

                string newEdgeValue3 = substring.Substring(newEdgeValue1.Length);
                Edge<string, string> newEdge2 = new Edge<string, string>()
                {
                    Value = newEdgeValue3,
                    Vertex = new Vertex<string, string>()
                };
                newVertex.Edges.Add(newEdge2);
            }
        }

        public IList<string> SuffixesForEdge(Edge<string, string> edge, string suffix = "")
        {
            IList<string> suffixes = new List<string>();

            suffix += edge.Value;

            if (edge.Vertex.Edges.Count > 0)
            {
                foreach(Edge<string, string> _edge in edge.Vertex.Edges)
                {
                    IList<string> newSuffixes = SuffixesForEdge(_edge, suffix);
                    foreach (string newSuffix in newSuffixes)
                    {
                        suffixes.Add(newSuffix);
                    }
                }
            }
            else
            {
                // Reached the end of the line, we have a suffix.
                suffixes.Add(suffix);
            }

            return suffixes;
        }

        public void OutputSuffixes()
        {
            IList<string> suffixes = new List<string>();
            foreach(Edge<string, string> edge in base.Root.Edges)
            {
                IList<string> tmpSuffixes = this.SuffixesForEdge(edge, "");
                foreach (string suffix in tmpSuffixes)
                {
                    suffixes.Add(suffix);
                }
            }

            foreach (string str in suffixes)
            {
                Console.WriteLine(str);
            }
        }

        #region Longest Repeating Substring

        public string LongestRepeatingSubstring()
        {
            int maximumLength = 0;
            string longestSuffix = "";

            foreach(Edge<string, string> edge in base.Root.Edges)
            {
                string _longestSuffix;
                this.LongestRepeatingSubstringForNode(edge, ref maximumLength, out _longestSuffix);
                if(_longestSuffix.Length > longestSuffix.Length)
                {
                    longestSuffix = _longestSuffix;
                }
            }

            return longestSuffix;
        }

        public void LongestRepeatingSubstringForNode(Edge<string, string> edge, ref int maximumLength, out string longestSuffix)
        {
            string _longestSuffix = "";
            longestSuffix = "";
            
            if (edge.Vertex.Edges.Count > 0)
            {
                foreach (Edge<string, string> _edge in edge.Vertex.Edges)
                {
                    LongestRepeatingSubstringForNode(_edge, ref maximumLength, out _longestSuffix);

                    if (longestSuffix.Length < _longestSuffix.Length)
                    {
                        longestSuffix = _longestSuffix;
                    }
                }
            }

            if(edge.Vertex.Edges.Count > 1) {
                longestSuffix = edge.Value + longestSuffix;
            }
        }

        #endregion
    }
}
