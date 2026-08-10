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

    public void InsertAtPosition(int data, int position)
    {
        Node newNode = new Node(data);

        // Insert at head
        if (position == 0)
        {
            newNode.Next = head;
            head = newNode;
            return;
        }

        Node? current = head;

        // Move to the node before the required position
        for (int i = 0; i < position - 1; i++)
        {
            if (current == null)
            {
                Console.WriteLine("Invalid position");
                return;
            }

            current = current.Next;
        }

        // Check if position is valid
        if (current == null)
        {
            Console.WriteLine("Invalid position");
            return;
        }

        // Insert the new node
        newNode.Next = current.Next;
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

        list.InsertAtPosition(10, 0);
        list.InsertAtPosition(20, 1);
        list.InsertAtPosition(30, 2);

        // Insert 25 at position 2
        list.InsertAtPosition(25, 2);

        list.Display();
    }
}