using System;

class Node
{
    public int Data;
    public Node? Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList
{
    Node? head;

    public void InsertAtTail(int data)
    {
        Node newNode = new Node(data);

        // If the list is empty
        if (head == null)
        {
            head = newNode;
            return;
        }

        // Find the last node
        Node current = head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        // Insert new node at the tail
        current.Next = newNode;
    }

    public void Display()
    {
        Node? current = head;

        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }

        Console.WriteLine("NULL");
    }
}

class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        list.InsertAtTail(10);
        list.InsertAtTail(20);
        list.InsertAtTail(30);
        list.InsertAtTail(40);

        list.Display();
    }
}