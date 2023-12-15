using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 * Tyler Aluko
 * IGME.201 - Unit Test #4 (Final)
 * This console application utilizes the previous code to implement a Depth First Search of the digraph.
 */
namespace EX4_Aluko_DFS
{


    enum NodeColor
    {
        Red,
        Blue,
        Light,
        Gray,
        Yellow,
        Orange,
        Purple
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
            
            if (IsValidEdge(source, destination))
            {
                adjacencyMatrix[source, destination] = weight;
                adjacencyList[source].Add(destination);
            }
            else
            {
                Console.WriteLine($"Invalid edge: ({source}, {destination})");
            }

        }

        private bool IsValidEdge(int source, int destination)
        {
            return source >= 0 && source < adjacencyMatrix.GetLength(0) && destination >= 0 && destination < adjacencyMatrix.GetLength(1);
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

        //plz
        public void DFS(int startNode, NodeColor[] colors)
        {
            bool[] visited = new bool[adjacencyList.Length];
            DFSUtil(startNode, visited, colors);
        }

        //plz work plz work plz work plz work plz work
        private void DFSUtil(int currentNode, bool[] visited, NodeColor[] colors)
        {
            
            visited[currentNode] = true; //if at current node

            Console.WriteLine($"Vertex {currentNode} Color: {colors[currentNode]}");

            foreach (int neighbor in adjacencyList[currentNode])
            {
                if (!visited[neighbor])
                {
                    DFSUtil(neighbor, visited, colors);
                }
            }

        }

    }

    class Program
    {
        static void Main()
        {
            
            int numVertices = 7; //adjustable based on number of nodes in graph
            DirectedGraph graph = new DirectedGraph(numVertices);

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

            NodeColor[] colors = { NodeColor.Red, NodeColor.Blue, NodeColor.Light, NodeColor.Gray, NodeColor.Yellow, NodeColor.Orange, NodeColor.Purple };

            graph.DFS(0, colors);

            Console.ReadLine(); //keep that jawn runnin

        }
    }


}
