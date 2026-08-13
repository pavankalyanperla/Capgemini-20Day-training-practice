using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== Browser History System =====");
            Console.WriteLine("1. Visit Page");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Current Page");
            Console.WriteLine("4. Display History");
            Console.WriteLine("5. Clear History");
            Console.WriteLine("6. Total Pages");
            Console.WriteLine("7. Exit");
            Console.Write("Enter Choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    StackFunctions.Push();
                    break;

                case 2:
                    StackFunctions.Pop();
                    break;

                case 3:
                    StackFunctions.Peek();
                    break;

                case 4:
                    StackFunctions.Display();
                    break;

                case 5:
                    StackFunctions.Clear();
                    break;

                case 6:
                    StackFunctions.Count();
                    break;
            }

        } while (choice != 7);
    }
}
