class Program
{
    static void Main()
    {
        BinaryTree bt = new BinaryTree();
        bt.Root = new BinaryTreeNode(1);
        bt.Root.Left = new BinaryTreeNode(2);
        bt.Root.Right = new BinaryTreeNode(3);
        bt.Root.Left.Left = new BinaryTreeNode(4);

        Console.Write("Inorder: ");
        bt.Inorder(bt.Root);  // Output: 4 2 1 3
        Console.WriteLine();
    }
}