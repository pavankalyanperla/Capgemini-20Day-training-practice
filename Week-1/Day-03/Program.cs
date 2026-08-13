using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        SinglyLinkedList list = new SinglyLinkedList();

        list.Insert(10);
        list.Insert(20);
        list.Insert(20);
        list.Insert(20);

        Console.WriteLine("Singly Linked List: ");
        list.Display();

        Console.ReadLine();
    }
}