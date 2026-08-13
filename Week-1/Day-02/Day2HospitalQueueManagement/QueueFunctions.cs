using System;


class QueueFunctions
{
    static string[] queue = new string[10];
    static int front = -1;
    static int rear = -1;

    public static void Enqueue()
    {
        if (rear == queue.Length - 1)
        {
            Console.WriteLine("Queue Full.");
            return;
        }

        Console.Write("Enter Patient Name: ");

        if (front == -1)
            front = 0;

        queue[++rear] = Console.ReadLine();
    }

    public static void Dequeue()
    {
        if (front == -1 || front > rear)
        {
            Console.WriteLine("Queue Empty.");
            return;
        }

        Console.WriteLine("Calling: " + queue[front]);
        front++;

        if (front > rear)
        {
            front = rear = -1;
        }
    }

    public static void Peek()
    {
        if (front == -1)
            Console.WriteLine("Queue Empty.");
        else
            Console.WriteLine("Next Patient: " + queue[front]);
    }

    public static void Display()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue Empty.");
            return;
        }

        Console.WriteLine("\nWaiting Patients:");

        for (int i = front; i <= rear; i++)
            Console.WriteLine(queue[i]);
    }

    public static void Search()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue Empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        string name = Console.ReadLine();

        bool found = false;

        for (int i = front; i <= rear; i++)
        {
            if (queue[i].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                break;
            }
        }

        Console.WriteLine(found ? "Patient Found." : "Patient Not Found.");
    }

    public static void Count()
    {
        if (front == -1)
            Console.WriteLine("Waiting Patients: 0");
        else
            Console.WriteLine("Waiting Patients: " + (rear - front + 1));
    }
}
