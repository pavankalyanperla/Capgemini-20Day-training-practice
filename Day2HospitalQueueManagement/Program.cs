using System;


class Program
{
    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== Hospital Queue Management =====");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Call Next Patient");
            Console.WriteLine("3. View Next Patient");
            Console.WriteLine("4. Display Waiting Patients");
            Console.WriteLine("5. Search Patient");
            Console.WriteLine("6. Count Waiting Patients");
            Console.WriteLine("7. Exit");
            Console.Write("Enter Choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    QueueFunctions.Enqueue();
                    break;

                case 2:
                    QueueFunctions.Dequeue();
                    break;

                case 3:
                    QueueFunctions.Peek();
                    break;

                case 4:
                    QueueFunctions.Display();
                    break;

                case 5:
                    QueueFunctions.Search();
                    break;

                case 6:
                    QueueFunctions.Count();
                    break;
            }

        } while (choice != 7);
    }
}
