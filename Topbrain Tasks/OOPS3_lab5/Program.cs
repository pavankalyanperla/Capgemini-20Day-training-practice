using System;
using System.Collections.Generic;

public class Address
{
    public string Street { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;
}

public class Order
{
    public string OrderId { get; }

    public Address? ShipTo { get; set; }

    public List<string> Items { get; set; } = new();

    public decimal Total { get; set; }

    public Order(string orderId)
    {
        OrderId = orderId;
    }
}

class Program
{
    static void Main()
    {
        Order order1 = new Order("ORD-1")
        {
            ShipTo = new Address
            {
                Street = "123 Main Street",
                City = "Springfield",
                ZipCode = "12345"
            },

            Items =
            {
                "Laptop",
                "Mouse"
            },

            Total = 59.98m
        };

        Console.WriteLine(
            $"Order {order1.OrderId} ships to " +
            $"{order1.ShipTo?.City} with " +
            $"{order1.Items.Count} items, " +
            $"Total=${order1.Total}");

        Order order2 = new Order("ORD-2")
        {
            Total = 100.00m
        };

        if (order2.ShipTo == null)
        {
            Console.WriteLine(
                $"Order {order2.OrderId} has no shipping " +
                $"address set (ShipTo is null)");
        }
    }
}