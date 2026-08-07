class Program
{
    static void Main()
    {
        // Change this number to test different values
        int number = 10; 
        
        bool result = IsPositiveChain(number);
        Console.WriteLine($"Result: {result}");
    }

    static bool IsPositiveChain(int n)
    {
        if (n == 0) return true;
        return IsNegativeChain(n - 1);
    }

    static bool IsNegativeChain(int n)
    {
        if (n == 0) return true;
        return IsPositiveChain(n + 1);
    }
}