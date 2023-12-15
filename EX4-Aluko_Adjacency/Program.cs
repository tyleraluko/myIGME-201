using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 * Tyler Aluko
 * IGME.201 - Unit Test #4 (Final)
 * This console application represents a colored node diagraph as an adjacency matrix/list.
 */
namespace EX4_Aluko_Adjacency
{
    
    
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

        //adj matrix
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

        //adj list
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

    }

    class Program
    {
        
        static void Main()
        {
            
            int numVertices = 7; // Adjust based on the number of nodes in your graph
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

            //display matrix and list
            graph.DisplayAdjacencyMatrix();
            graph.DisplayAdjacencyList();

            Console.ReadLine(); //keep program running

        }

    }


}
