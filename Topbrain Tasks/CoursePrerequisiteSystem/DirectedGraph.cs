using System;
using System.Collections.Generic;

class DirectedGraph
{
    Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    public void AddEdge(int source, int destination)
    {
        if (!graph.ContainsKey(source))
            graph[source] = new List<int>();

        if (!graph.ContainsKey(destination))
            graph[destination] = new List<int>();

        graph[source].Add(destination);
    }

    public void Display()
    {
        foreach (var item in graph)
        {
            Console.Write(item.Key + " -> ");

            foreach (int v in item.Value)
                Console.Write(v + " ");

            Console.WriteLine();
        }
    }

    // Direct prerequisites
    public void DirectPrerequisites(int course)
    {
        foreach (var item in graph)
        {
            if (item.Value.Contains(course))
                Console.Write(item.Key + " ");
        }

        Console.WriteLine();
    }

    // Direct + Indirect prerequisites
    public void GetPrerequisites(int course)
    {
        bool[] visited = new bool[graph.Count];

        DFSReverse(course, visited);

        Console.WriteLine();
    }

    void DFSReverse(int course, bool[] visited)
    {
        foreach (var item in graph)
        {
            if (item.Value.Contains(course) && !visited[item.Key])
            {
                visited[item.Key] = true;

                DFSReverse(item.Key, visited);

                Console.Write(item.Key + " ");
            }
        }
    }

    // Cycle Detection
    public bool HasCycle()
    {
        bool[] visited = new bool[graph.Count];
        bool[] recStack = new bool[graph.Count];

        foreach (int v in graph.Keys)
        {
            if (CycleDFS(v, visited, recStack))
                return true;
        }

        return false;
    }

    bool CycleDFS(int v, bool[] visited, bool[] recStack)
    {
        if (recStack[v])
            return true;

        if (visited[v])
            return false;

        visited[v] = true;
        recStack[v] = true;

        foreach (int child in graph[v])
        {
            if (CycleDFS(child, visited, recStack))
                return true;
        }

        recStack[v] = false;

        return false;
    }

    // Topological Sort
    public void TopologicalSort()
    {
        bool[] visited = new bool[graph.Count];
        Stack<int> stack = new Stack<int>();

        foreach (int v in graph.Keys)
        {
            if (!visited[v])
                TopoDFS(v, visited, stack);
        }

        while (stack.Count > 0)
            Console.Write(stack.Pop() + " ");

        Console.WriteLine();
    }

    void TopoDFS(int v, bool[] visited, Stack<int> stack)
    {
        visited[v] = true;

        foreach (int child in graph[v])
        {
            if (!visited[child])
                TopoDFS(child, visited, stack);
        }

        stack.Push(v);
    }

    // Courses with no prerequisites
    public void NoPrerequisiteCourses()
    {
        foreach (int course in graph.Keys)
        {
            bool hasPrerequisite = false;

            foreach (var item in graph)
            {
                if (item.Value.Contains(course))
                {
                    hasPrerequisite = true;
                    break;
                }
            }

            if (!hasPrerequisite)
                Console.Write(course + " ");
        }

        Console.WriteLine();
    }

    // Count direct dependents
    public int CountDependents(int course)
    {
        if (!graph.ContainsKey(course))
            return 0;

        return graph[course].Count;
    }
}