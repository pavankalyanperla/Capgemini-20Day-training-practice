using System;

public class BinaryTreeNode
{
    public int Value { get; set; }
    public BinaryTreeNode Left { get; set; }
    public BinaryTreeNode Right { get; set; }

    public BinaryTreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTree
{
    public BinaryTreeNode Root { get; set; }

    public BinaryTree()
    {
        Root = null;
    }

    // Inorder Traversal: Left → Root → Right
    public void Inorder(BinaryTreeNode node)
    {
        if (node != null)
        {
            Inorder(node.Left);
            Console.Write(node.Value + " ");
            Inorder(node.Right);
        }
    }

    // Preorder Traversal: Root → Left → Right
    public void Preorder(BinaryTreeNode node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }
    }

    // Postorder Traversal: Left → Right → Root
    public void Postorder(BinaryTreeNode node)
    {
        if (node != null)
        {
            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Value + " ");
        }
    }
}

