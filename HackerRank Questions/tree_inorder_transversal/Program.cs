using System;

class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int value)
    {
        data = value;
        left = null;
        right = null;
    }
}

class BinaryTree
{
    public Node root;

    public void InOrder(Node root)
    {
        if (root == null)
            return;

        InOrder(root.left);
        Console.Write(root.data + " ");
        InOrder(root.right);
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        tree.root = new Node(1);
        tree.root.right = new Node(2);
        tree.root.right.right = new Node(5);
        tree.root.right.right.left = new Node(3);
        tree.root.right.right.right = new Node(6);
        tree.root.right.right.left.right = new Node(4);

        Console.WriteLine("Inorder Traversal:");
        tree.InOrder(tree.root);
    }
}