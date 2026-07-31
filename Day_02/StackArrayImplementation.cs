
using System;
class StackArray
{
    int[] stack = new int[5];
    int top = -1;

    public void Push(int value)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }

        stack[++top] = value;
        Console.WriteLine(value + " Pushed");
    }

    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Underflow");
            return;
        }

        Console.WriteLine(stack[top--] + " Popped");
    }

    public void Peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is Empty");
            return;
        }

        Console.WriteLine("Top Element: " + stack[top]);
    }

    public void Display()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is Empty");
            return;
        }

        Console.WriteLine("Stack Elements:");

        for (int i = top; i >= 0; i--)
        {
            Console.Write(stack[i] + " ");
        }

        Console.WriteLine();
    }

}