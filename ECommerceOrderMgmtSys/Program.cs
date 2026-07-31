using System;

class Program
{
    static string[] orders =
    {
        "ORD1001|John Smith|Laptop|2|$1200|Delivered",
        "ORD1002|Alice Brown|Mobile|1|$800|Pending",
        "ORD1003|David Wilson|Keyboard|3|$150|Shipped",
        "ORD1004|Emma Davis|Monitor|2|$350|Delivered",
        "ORD1005|James Miller|Mouse|5|$50|Pending"
    };

    static void Main()
    {
        SearchByOrderId();
    }

    static void DiplayAllOrders()
    {
        Console.WriteLine("\n All Orders are :");

        foreach (string order in orders)
        {
            Console.WriteLine(order);
        }
    }

    static void DisplayOrderDetails()
    {
        Console.WriteLine("\nOrder Details:");

        foreach (string order in orders)
        {
            string[] data = order.Split('|');

            Console.WriteLine("------------------------------");
            Console.WriteLine("Order ID : " + data[0]);
            Console.WriteLine("Customer : " + data[1]);
            Console.WriteLine("Product  : " + data[2]);
            Console.WriteLine("Quantity : " + data[3]);
            Console.WriteLine("Price    : " + data[4]);
            Console.WriteLine("Status   : " + data[5]);
        }
    }

    static void DisplayDeliveredOrders()
    {
        Console.WriteLine("\nDelivered Orders:");

        foreach (string order in orders)
        {
            string[] data = order.Split('|');

            if (data[5] == "Delivered")
            {
                Console.WriteLine(order);
            }
        }
    }

    static void DisplayPendingOrders()
    {
        Console.WriteLine("\nPending Orders:");

        foreach (string order in orders)
        {
            string[] data = order.Split('|');

            if (data[5] == "Pending")
            {
                Console.WriteLine(order);
            }
        }
    }

    static void CustomerInitials()
    {
        Console.WriteLine("\nCustomer Initials:");

        foreach(string order in orders)
        {
            string[] data = order.Split('|');

            string CustomerName = data[1];

            string[] name = CustomerName.Split(' ');

            Console.WriteLine($"{CustomerName} ---> {name[0][0]}.{name[1][0]}");
        }
    }

    static void SearchByOrderId()

    {

        Console.Write("Enter Order ID: ");
        string id = Console.ReadLine();
        bool found = false;

        foreach (string order in orders)
        {
            if (order.StartsWith(id))
            {
                Console.WriteLine(order);
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("Order Not Found.");

    }

    static void CountOrderStatus()
    {
        int delivered = 0;
        int pending = 0;
        int shipped = 0;

        foreach (string order in orders)
        {
            string[] data = order.Split('|');

            if (data[5] == "Delivered")
                delivered++;

            else if (data[5] == "Pending")
                pending++;

            else if (data[5] == "Shipped")
                shipped++;
        }

        Console.WriteLine("\nDelivered : " + delivered);
        Console.WriteLine("Pending   : " + pending);
        Console.WriteLine("Shipped   : " + shipped);
    }

    
}