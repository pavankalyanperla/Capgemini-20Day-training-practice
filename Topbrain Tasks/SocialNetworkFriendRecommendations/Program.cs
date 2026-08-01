using System;

class Program
{
    static void Main()
    {
        SocialNetwork graph = new SocialNetwork(6);

        // Friendships
        graph.AddFriendship(0, 1);
        graph.AddFriendship(0, 2);
        graph.AddFriendship(1, 3);
        graph.AddFriendship(2, 3);
        graph.AddFriendship(2, 4);
        graph.AddFriendship(3, 5);
        graph.AddFriendship(4, 5);

        Console.WriteLine("Social Network");
        graph.Display();

        Console.Write("\nFriends of User 2: ");
        graph.FindFriends(2);

        Console.WriteLine("\nUser 0 and User 5 Connected: " +
                          graph.IsConnected(0, 5));

        Console.Write("\nShortest Path (0 -> 5): ");
        graph.ShortestPath(0, 5);

        Console.Write("\nUsers at Distance 2 from User 1: ");
        graph.DistanceTwo(1);

        Console.WriteLine("\nCycle Exists: " + graph.HasCycle());

        Console.WriteLine("\nConnected Components:");
        graph.ConnectedComponents();
    }
}