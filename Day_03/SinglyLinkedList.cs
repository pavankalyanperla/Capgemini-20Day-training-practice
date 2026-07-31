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

class SinglyLinkedList
{
    Node head;

    public void Insert(int data)
    {
        Node newNode = new Node(data);

        if(head == null)
        {
            head = newNode;
            return;

        }

        Node temp = head;

        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
    }

    public void Display()
    {
        if(head == null)
        {
            Console.WriteLine("List is Empty");
            return;
        }

        Node temp = head;

        while(temp != null)
        {
            Console.Write($"{temp.Data} ->");
            temp = temp.Next;
        }

        Console.WriteLine("Null");
    }
}