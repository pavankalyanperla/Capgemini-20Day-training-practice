// Lab 3: Constructor Design

using System;

public class Appointment
{
    public string Title    { get; }
    public DateTime Start  { get; }
    public TimeSpan Duration { get; }
    public string Location { get; }

    public static int DefaultDurationMinutes;

    // Static constructor: runs once the first time the type is referenced
    static Appointment()
    {
        Console.WriteLine("Appointment type initialized. Default duration set to 30 minutes.");
        DefaultDurationMinutes = 30;
    }

    // Full constructor: all four values
    public Appointment(string title, DateTime start, TimeSpan duration, string location)
    {
        Title    = title;
        Start    = start;
        Duration = duration;
        Location = location;
    }

    // Two-arg constructor: chains to full with defaults
    public Appointment(string title, DateTime start)
        : this(title, start, TimeSpan.FromMinutes(DefaultDurationMinutes), "TBD") { }

    // One-arg constructor: chains to two-arg with tomorrow as default start
    public Appointment(string title)
        : this(title, DateTime.Now.AddDays(1)) { }

    // Bonus: copy-and-reschedule constructor (shifts start by one day)
    public Appointment(Appointment source)
        : this(source.Title, source.Start.AddDays(1), source.Duration, source.Location) { }

    public override string ToString() =>
        $"{Title} @ {Start:yyyy-MM-dd HH:mm}, {Duration.TotalMinutes:0} min, {Location}";
}

public class Lab3
{
    public static void Main()
    {
        // Triggers static constructor on first use
        var full = new Appointment(
            "Standup",
            new DateTime(2026, 8, 12, 9, 0, 0),
            TimeSpan.FromMinutes(30),
            "Room 4");

        var twoArg = new Appointment(
            "Client Call",
            new DateTime(2026, 8, 12, 14, 0, 0));

        var oneArg = new Appointment("Follow Up");

        Console.WriteLine($"Full:    {full}");
        Console.WriteLine($"Two-arg: {twoArg}");
        Console.WriteLine($"One-arg: {oneArg}");
        Console.WriteLine($"DefaultDurationMinutes: {Appointment.DefaultDurationMinutes}");

        Console.WriteLine();

        // Bonus: clone and reschedule
        var rescheduled = new Appointment(full);
        Console.WriteLine($"Rescheduled (full +1 day): {rescheduled}");
    }
}