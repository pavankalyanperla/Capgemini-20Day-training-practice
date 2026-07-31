using System;

class QueueFunctions
{
     static string[] queue = new string[20];

        static int front = -1;
        static int rear = -1;

        static string[] tickets =
        {
            "T001|John|Login Issue",
            "T002|Alice|Payment Failed",
            "T003|David|Account Locked",
            "T004|Emma|Refund Request",
            "T005|James|Password Reset"
        };

        public static void InitializeTickets()
        {
            foreach (string ticket in tickets)
            {
                if (front == -1)
                    front = 0;

                queue[++rear] = ticket;
            }
        }


    public static void Display()
    {
        if(front == -1)
        {
            Console.WriteLine("Queue is Empty");
            return;
        }

        for(int i = front; i<= rear; i++)
        {
            string[] data = queue[i].Split('|');

            Console.WriteLine($"{data[0]} {data[1]} {data[2]}");
        }
    }

    public static void Enqueue()
        {
            if (rear == queue.Length - 1)
            {
                Console.WriteLine("Queue Full.");
                return;
            }

            Console.Write("Enter Ticket ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Issue: ");
            string issue = Console.ReadLine();

            if (front == -1)
                front = 0;

            queue[++rear] = id + "|" + name + "|" + issue;

            Console.WriteLine("Ticket Added.");
        }

        // Process Ticket
        public static void Dequeue()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("No Tickets.");
                return;
            }

            Console.WriteLine("Processing Ticket:");
            PrintTicket(queue[front]);

            front++;

            if (front > rear)
            {
                front = -1;
                rear = -1;
            }
        }

        // View Next Ticket
        public static void Peek()
        {
            if (front == -1)
            {
                Console.WriteLine("Queue Empty.");
                return;
            }

            Console.WriteLine("Next Ticket:");
            PrintTicket(queue[front]);
        }

        // Display All Tickets
        public static void Display()
        {
            if (front == -1)
            {
                Console.WriteLine("Queue Empty.");
                return;
            }

            Console.WriteLine("\nWaiting Tickets:");

            for (int i = front; i <= rear; i++)
            {
                PrintTicket(queue[i]);
                Console.WriteLine();
            }
        }

        // Search Ticket
        public static void Search()
        {
            Console.Write("Enter Ticket ID: ");
            string id = Console.ReadLine();

            bool found = false;

            for (int i = front; i <= rear; i++)
            {
                if (queue[i].StartsWith(id))
                {
                    Console.WriteLine("Ticket Found:");
                    PrintTicket(queue[i]);
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Ticket Not Found.");
        }

        // Count Tickets
        public static void Count()
        {
            if (front == -1)
                Console.WriteLine("Total Tickets: 0");
            else
                Console.WriteLine("Total Tickets: " + (rear - front + 1));
        }

        // Print Ticket Details
        static void PrintTicket(string ticket)
        {
            string[] data = ticket.Split('|');

            Console.WriteLine("Ticket ID : " + data[0]);
            Console.WriteLine("Customer  : " + data[1]);
            Console.WriteLine("Issue     : " + data[2]);
        }
}