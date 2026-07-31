using System;

class Program
{
    static void Main()
    {
        DirectedGraph graph = new DirectedGraph();

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 5);

        Console.WriteLine("Course Dependency Graph");
        graph.Display();

        Console.Write("\nPrerequisites for Course 5: ");
        graph.GetPrerequisites(5);

        Console.Write("\nDirect prerequisites of Course 3: ");
        graph.DirectPrerequisites(3);

        Console.WriteLine("\nCycle Exists: " + graph.HasCycle());

        if (!graph.HasCycle())
        {
            Console.Write("Topological Order: ");
            graph.TopologicalSort();
        }

        Console.Write("\nCourses with No Prerequisites: ");
        graph.NoPrerequisiteCourses();

        Console.WriteLine("\nCourses depending on Course 2: " +
                          graph.CountDependents(2));
    }
}