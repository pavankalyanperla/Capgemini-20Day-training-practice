using System;

class StackFunctions
{
    static string[] history = new string[10];
    static int top = -1;

    public static void Push()
    {
        if(top == history.Length - 1)
        {
            Console.WriteLine("History Full");
        }

        Console.Write("Enter Website name : ");
        history[++top] = Console.ReadLine();
    }

    public static void Pop()
    {
        if(top == -1)
        {
            Console.WriteLine("History Empty");
        }

        Console.WriteLine($"Back From {history[top--]}");

    }

    public static void Peek()
    {
        if(top == -1)
        {
            Console.WriteLine("There is no Current Page/Website");
        }
        else
        {
            Console.WriteLine($"Current Page/Website: {history[top]}");
        }
    }

    public static void Display()
    {
        if (top == -1)
        {
            Console.WriteLine("history is Empty");
        }

        Console.WriteLine("\n Browser History :");

        for (int i = top; i >= 0; i--)
            Console.WriteLine(history[i]);
    }

    public static void Clear()
        {
            top = -1;
            Console.WriteLine("History Cleared.");
        }

    public static void Count()
        {
            Console.WriteLine("Total Pages: " + (top + 1));
        }
}