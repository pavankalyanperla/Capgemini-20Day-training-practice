using System;

class Program
{
    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();

        list.Insert(10);
        list.Insert(20);
        list.Insert(30);
        list.Insert(40);

        Console.WriteLine("Circular Linked List:");
        list.Display();

        Console.ReadKey();
    }
}