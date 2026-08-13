using System;

public class Subscription
{
    public string Id { get; }

    public string PlanName { get; set; } = string.Empty;

    public DateTime StartedAt { get; init; }

    public bool IsActive { get; private set; } = true;

    public int MonthsActive
    {
        get
        {
            return (DateTime.Now.Year - StartedAt.Year) * 12
                 + DateTime.Now.Month - StartedAt.Month;
        }
    }

    public Subscription(string id)
    {
        Id = id;
    }

    public void Cancel()
    {
        IsActive = false;
    }
}

class Program
{
    static void Main()
    {
        Subscription subscription = new Subscription("SUB-1")
        {
            PlanName = "Pro",
            StartedAt = new DateTime(2026, 1, 1)
        };

        Console.WriteLine(
            $"Id={subscription.Id}, " +
            $"Plan={subscription.PlanName}, " +
            $"Started={subscription.StartedAt:yyyy-MM-dd}, " +
            $"Active={subscription.IsActive}, " +
            $"MonthsActive={subscription.MonthsActive}");

        subscription.Cancel();

        Console.WriteLine(
            $"After Cancel(): Active={subscription.IsActive}");

        // This will NOT compile:
        // subscription.IsActive = true;

        // This will NOT compile:
        // subscription.StartedAt = DateTime.Now;
    }
}