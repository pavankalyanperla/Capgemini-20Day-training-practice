using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class CircularLinkedList
{
    Node head;

    // Insert at End
    public void Insert(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
            return;
        }

        Node temp = head;

        while (temp.Next != head)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
        newNode.Next = head;
    }

    // Display Circular Linked List
    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List is Empty");
            return;
        }

        Node temp = head;

        do
        {
            Console.Write(temp.Data + " -> ");
            temp = temp.Next;
        }
        while (temp != head);

        Console.WriteLine("(Back to Head)");
    }

}