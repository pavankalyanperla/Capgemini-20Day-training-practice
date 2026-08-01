using System;
using System.Collections.Generic;

class SocialNetwork
{
    private List<int>[] graph;
    private int vertices;

    public SocialNetwork(int v)
    {
        vertices = v;
        graph = new List<int>[v];

        for (int i = 0; i < v; i++)
            graph[i] = new List<int>();
    }

    // Add Friendship
    public void AddFriendship(int u, int v)
    {
        graph[u].Add(v);
        graph[v].Add(u);
    }

    // Display Graph
    public void Display()
    {
        for (int i = 0; i < vertices; i++)
        {
            Console.Write(i + " -> ");

            foreach (int friend in graph[i])
                Console.Write(friend + " ");

            Console.WriteLine();
        }
    }

    // Find Friends
    public void FindFriends(int user)
    {
        foreach (int friend in graph[user])
            Console.Write(friend + " ");

        Console.WriteLine();
    }

    // Check Connectivity using DFS
    public bool IsConnected(int start, int end)
    {
        bool[] visited = new bool[vertices];
        return DFS(start, end, visited);
    }

    private bool DFS(int current, int target, bool[] visited)
    {
        if (current == target)
            return true;

        visited[current] = true;

        foreach (int friend in graph[current])
        {
            if (!visited[friend])
            {
                if (DFS(friend, target, visited))
                    return true;
            }
        }

        return false;
    }

    // Shortest Path using BFS
    public void ShortestPath(int start, int end)
    {
        bool[] visited = new bool[vertices];
        int[] parent = new int[vertices];

        for (int i = 0; i < vertices; i++)
            parent[i] = -1;

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (int friend in graph[current])
            {
                if (!visited[friend])
                {
                    visited[friend] = true;
                    parent[friend] = current;
                    queue.Enqueue(friend);
                }
            }
        }

        Stack<int> path = new Stack<int>();

        int temp = end;

        while (temp != -1)
        {
            path.Push(temp);
            temp = parent[temp];
        }

        while (path.Count > 0)
            Console.Write(path.Pop() + " ");
    }

    // Users at Distance 2
    public void DistanceTwo(int user)
    {
        bool[] visited = new bool[vertices];

        Queue<int> queue = new Queue<int>();
        Queue<int> level = new Queue<int>();

        queue.Enqueue(user);
        level.Enqueue(0);

        visited[user] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            int distance = level.Dequeue();

            if (distance == 2)
            {
                Console.Write(current + " ");
                continue;
            }

            foreach (int friend in graph[current])
            {
                if (!visited[friend])
                {
                    visited[friend] = true;
                    queue.Enqueue(friend);
                    level.Enqueue(distance + 1);
                }
            }
        }

        Console.WriteLine();
    }

    // Cycle Detection
    public bool HasCycle()
    {
        bool[] visited = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
            {
                if (CycleDFS(i, visited, -1))
                    return true;
            }
        }

        return false;
    }

    private bool CycleDFS(int current, bool[] visited, int parent)
    {
        visited[current] = true;

        foreach (int friend in graph[current])
        {
            if (!visited[friend])
            {
                if (CycleDFS(friend, visited, current))
                    return true;
            }
            else if (friend != parent)
            {
                return true;
            }
        }

        return false;
    }

    // Connected Components
    public void ConnectedComponents()
    {
        bool[] visited = new bool[vertices];

        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
            {
                DFSComponent(i, visited);
                Console.WriteLine();
            }
        }
    }

    private void DFSComponent(int current, bool[] visited)
    {
        visited[current] = true;

        Console.Write(current + " ");

        foreach (int friend in graph[current])
        {
            if (!visited[friend])
                DFSComponent(friend, visited);
        }
    }
}