using System;
using System.Collections.Generic;

public class BTreeNode
{
    public List<int> Keys { get; set; }
    public List<BTreeNode> Children { get; set; }
    public bool IsLeaf { get; set; }

    public BTreeNode(bool isLeaf)
    {
        Keys = new List<int>();
        Children = new List<BTreeNode>();
        IsLeaf = isLeaf;
    }
}

public class BTree
{
    private BTreeNode root;
    private readonly int degree;

    private int MaxKeys => 2 * degree - 1;
    private int MinKeys => degree - 1;

    public BTree(int degree)
    {
        if (degree < 2)
            throw new ArgumentException("B-Tree degree must be at least 2.");

        this.degree = degree;
        root = new BTreeNode(true);
    }

    public void Insert(int key)
    {
        if (root.Keys.Count == MaxKeys)
        {
            BTreeNode newRoot = new BTreeNode(false);
            newRoot.Children.Add(root);

            SplitChild(newRoot, 0);
            root = newRoot;
        }

        InsertNotFull(root, key);
    }

    private void InsertNotFull(BTreeNode node, int key)
    {
        int i = node.Keys.Count - 1;

        if (node.IsLeaf)
        {
            node.Keys.Add(0);

            while (i >= 0 && key < node.Keys[i])
            {
                node.Keys[i + 1] = node.Keys[i];
                i--;
            }

            node.Keys[i + 1] = key;
        }
        else
        {
            while (i >= 0 && key < node.Keys[i])
            {
                i--;
            }

            i++;

            if (node.Children[i].Keys.Count == MaxKeys)
            {
                SplitChild(node, i);

                if (key > node.Keys[i])
                {
                    i++;
                }
            }

            InsertNotFull(node.Children[i], key);
        }
    }

    private void SplitChild(BTreeNode parent, int index)
    {
        BTreeNode child = parent.Children[index];
        BTreeNode newChild = new BTreeNode(child.IsLeaf);

        // Save middle key
        int middleKey = child.Keys[degree - 1];

        // Copy last MinKeys keys to new child
        for (int j = 0; j < MinKeys; j++)
        {
            newChild.Keys.Add(child.Keys[j + degree]);
        }

        // Copy last degree children if not leaf
        if (!child.IsLeaf)
        {
            for (int j = 0; j < degree; j++)
            {
                newChild.Children.Add(child.Children[j + degree]);
            }
        }

        // Remove keys from child (including middle key)
        for (int j = child.Keys.Count - 1; j >= degree - 1; j--)
        {
            child.Keys.RemoveAt(j);
        }

        // Remove moved children
        if (!child.IsLeaf)
        {
            for (int j = child.Children.Count - 1; j >= degree; j--)
            {
                child.Children.RemoveAt(j);
            }
        }

        // Insert into parent
        parent.Children.Insert(index + 1, newChild);
        parent.Keys.Insert(index, middleKey);
    }

    public void Display()
    {
        DisplayRecord(root, 0);
    }

    private void DisplayRecord(BTreeNode node, int level)
    {
        Console.WriteLine(
            $"Level {level}: {string.Join(", ", node.Keys)}");

        if (!node.IsLeaf)
        {
            foreach (var child in node.Children)
            {
                DisplayRecord(child, level + 1);
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        BTree bTree = new BTree(3);

        int[] keys =
        {
            10, 20, 5, 6,
            12, 30, 7, 17
        };

        foreach (int key in keys)
        {
            bTree.Insert(key);
        }

        Console.WriteLine("B-Tree Structure:");
        bTree.Display();
    }
}