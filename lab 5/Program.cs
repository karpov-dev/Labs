using System;

namespace lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph;
            while ( true )
            {
                #region Menu 
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine();
                Console.WriteLine("1 - Exercice 1");
                Console.WriteLine("2 - Exercice 2");
                Console.WriteLine("3 - Exercice 3");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");
                Console.Write("Answer: ");
                string selectedPoint = Console.ReadLine();
                #endregion

                switch ( selectedPoint )
                {
                    #region Double Degree
                    case "1":
                        graph = GetGraph();
                        Console.WriteLine("Double degree: ");

                        foreach ( Vertice vertice in graph.Vertices )
                            Console.WriteLine(vertice.Name + ": " + vertice.DoubleDegree() + " ");

                        Console.ReadKey();
                        break;
                    #endregion

                    #region Is Cycled
                    case "2":
                        graph = GetGraph();
                        Console.WriteLine("Is Cycled: " + graph.IsCycled());

                        Console.ReadKey();
                        break;
                    #endregion

                    #region Is Bipartite
                    case "3":
                        graph = GetGraph();
                        Console.WriteLine("Is Bipartite: " + graph.IsBipartite());

                        Console.ReadKey();
                        break;
                    #endregion

                    #region Exit
                    case "0":
                        return;
                    #endregion

                    #region Not Found
                    default:
                        Console.WriteLine("Not found");
                        break;
                        #endregion
                }
            }
        }

        #region Methods
        private static Graph GetGraph()
        {
            Console.Clear();
            Console.Write("Vertices: ");
            int amountOfVertices = Convert.ToInt32(Console.ReadLine()),
                edgeNumber = 0;

            Graph graph = new Graph();
            for ( int i = 0; i < amountOfVertices; i++ )
                graph.Vertices.Add(new Vertice());

            while ( true )
            {
                Console.WriteLine("Enter connectivities");
                Console.WriteLine("0 - End");
                Console.WriteLine("Vertices (counting from 0): " + amountOfVertices);
                string input = Console.ReadLine();
                if ( input == "0" ) break;
                string[] vertices = input.Split(" ");

                if ( int.Parse(vertices[0]) >= amountOfVertices || int.Parse(vertices[1]) >= amountOfVertices ) continue;
                graph.Vertices[int.Parse(vertices[0])].AdjacentEdges.Add(new Edge(graph.Vertices[int.Parse(vertices[0])], graph.Vertices[int.Parse(vertices[1])], "E" + edgeNumber.ToString()));

                if ( int.Parse(vertices[1]) == int.Parse(vertices[0]) ) continue;
                graph.Vertices[int.Parse(vertices[1])].AdjacentEdges.Add(new Edge(graph.Vertices[int.Parse(vertices[1])], graph.Vertices[int.Parse(vertices[0])], "E" + edgeNumber.ToString()));
                edgeNumber++;
            }
            return graph;
        }
        #endregion
    }


}
