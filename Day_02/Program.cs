using System;
class Program
{
    static void Main(string[] args)
        {
            StackArray s = new StackArray();

            s.Push(10);
            s.Push(20);
            s.Push(30);

            s.Display();

            s.Peek();

            s.Pop();

            s.Display();


            QueueArray q = new QueueArray();

            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);

            q.Display();

            q.Peek();

            q.Dequeue();

            q.Display();
        }
}
        