using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 * Tyler Aluko
 * IGME.201 - Unit Test #4 (Final)
 * This console application utilizes the previous code to implement Dijkstra's shortest path algorithm.
 */
namespace EX4_Aluko_DijkstraSP
{


    //look at the pwetty colors
    enum NodeColor
    {
        Red,
        Blue,
        Light,
        Gray,
        Yellow,
        Orange,
        Purple,
        Green
    }

    class DirectedGraph
    {
        
        private int[,] adjacencyMatrix;
        private List<int>[] adjacencyList;

        public DirectedGraph(int vertices)
        {
            
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }

        }

        public void AddEdge(int source, int destination, int weight)
        {
            
            if (source >= 0 && source < adjacencyMatrix.GetLength(0) && destination >= 0 && destination < adjacencyMatrix.GetLength(1))
            {
                adjacencyMatrix[source, destination] = weight;
                adjacencyList[source].Add(destination);
            }
            else
            {
                Console.WriteLine($"Invalid edge: ({source}, {destination})");
            }

        }

        public void DisplayAdjacencyMatrix()
        {
            
            Console.WriteLine("Adjacency Matrix:");

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }

                Console.WriteLine();

            }

            Console.WriteLine();

        }

        public void DisplayAdjacencyList()
        {
            
            Console.WriteLine("Adjacency List:");

            for (int i = 0; i < adjacencyList.Length; i++)
            {
                
                Console.Write($"Vertex {i}: ");

                foreach (int neighbor in adjacencyList[i])
                {
                    Console.Write($"{neighbor} ");
                }

                Console.WriteLine();

            }

        }

        public void DijkstraShortestPath(int startNode, NodeColor[] colors)
        {
            
            int numVertices = adjacencyMatrix.GetLength(0);
            int[] distance = new int[numVertices];
            bool[] shortestPathSet = new bool[numVertices];

            //initialize distances and shortestPathSet
            for (int i = 0; i < numVertices; i++)
            {
                distance[i] = int.MaxValue;
                shortestPathSet[i] = false;
            }

            distance[startNode] = 0;

            for (int count = 0; count < numVertices - 1; count++)
            {
                int u = MinDistance(distance, shortestPathSet);
                shortestPathSet[u] = true;

                for (int v = 0; v < numVertices; v++)
                {
                    if (!shortestPathSet[v] && adjacencyMatrix[u, v] != 0 &&
                        distance[u] != int.MaxValue && distance[u] + adjacencyMatrix[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + adjacencyMatrix[u, v];
                    }
                }
            }

            OutputShortestPath(startNode, distance, colors);

        }

        private int MinDistance(int[] distance, bool[] shortestPathSet)
        {
            
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < distance.Length; v++)
            {
                if (!shortestPathSet[v] && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;

        }

        private void OutputShortestPath(int startNode, int[] distance, NodeColor[] colors)
        {
            
            Console.WriteLine("Shortest Paths:");
            
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine($"Red to {colors[i]}: {distance[i]} units");
            }

        }

    }

    class Program
    {
        static void Main()
        {
            
            int numVertices = 7; //adjust based on number of nodes in graph
            DirectedGraph graph = new DirectedGraph(numVertices);

            //add corresponding edges
            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 5, 5);
            graph.AddEdge(1, 0, 1);
            graph.AddEdge(1, 8, 8);
            graph.AddEdge(5, 0, 5);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 1, 1);
            graph.AddEdge(1, 3, 3);
            graph.AddEdge(3, 2, 2);
            graph.AddEdge(2, 4, 8);
            graph.AddEdge(4, 6, 6);
            graph.AddEdge(5, 6, 1);

            NodeColor[] colors = { NodeColor.Red, NodeColor.Blue, NodeColor.Light, NodeColor.Gray, NodeColor.Yellow, NodeColor.Orange, NodeColor.Green };

            //display matrix and list
            graph.DisplayAdjacencyMatrix();
            graph.DisplayAdjacencyList();

            //calculate and output shortest paths
            graph.DijkstraShortestPath(0, colors);

            Console.ReadLine(); //runnnnnnnnnnnnnnnnnnnnnnn

        }
    }


}
