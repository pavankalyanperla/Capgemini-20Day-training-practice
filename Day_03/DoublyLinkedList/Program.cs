using System;

class Program
{
    static void Main()
    
    {
        DoublyLinkedList list = new DoublyLinkedList();

        list.Insert(10);
        list.Insert(20);
        list.Insert(30);
        list.Insert(40);

        Console.WriteLine("Doubly Linked List:");
        list.DisplayForward();
    }
}