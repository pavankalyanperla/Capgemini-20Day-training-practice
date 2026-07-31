using System;

class QueueArray
{
    int[] queue = new int[5];
    int front = -1;
    int rear = -1;

    public void Enqueue(int value)
    {
        if (rear == queue.Length - 1)
        {
            Console.WriteLine("Queue Overflow");
            return;
        }

        if (front == -1)
            front = 0;

        queue[++rear] = value;

        Console.WriteLine(value + " Enqueued");
    }

    public void Dequeue()
    {
        if (front == -1 || front > rear)
        {
            Console.WriteLine("Queue Underflow");
            return;
        }

        Console.WriteLine(queue[front++] + " Dequeued");
    }

    public void Peek()
    {
        if (front == -1 || front > rear)
        {
            Console.WriteLine("Queue is Empty");
            return;
        }

        Console.WriteLine("Front Element: " + queue[front]);
    }

    public void Display()
    {
        if (front == -1 || front > rear)
        {
            Console.WriteLine("Queue is Empty");
            return;
        }

        Console.WriteLine("Queue Elements:");

        for (int i = front; i <= rear; i++)
        {
            Console.Write(queue[i] + " ");
        }

        Console.WriteLine();
    }

}