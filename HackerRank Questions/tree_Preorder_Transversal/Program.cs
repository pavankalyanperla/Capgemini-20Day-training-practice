using System;

class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    public Node Root;

    // Preorder Traversal
    public void PreOrder(Node root)
    {
        if (root == null)
            return;

        Console.Write(root.Data + " ");
        PreOrder(root.Left);
        PreOrder(root.Right);
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        // Creating the tree
        tree.Root = new Node(1);
        tree.Root.Right = new Node(2);
        tree.Root.Right.Right = new Node(5);
        tree.Root.Right.Right.Left = new Node(3);
        tree.Root.Right.Right.Right = new Node(6);
        tree.Root.Right.Right.Left.Right = new Node(4);

        Console.WriteLine("Preorder Traversal:");
        tree.PreOrder(tree.Root);
    }
}