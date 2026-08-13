using System;

public static class StringUtils
{
    public static bool IsPalindrome(string s)
    {
        string reversed = Reverse(s);

        return s.Equals(
            reversed,
            StringComparison.OrdinalIgnoreCase);
    }

    public static string Reverse(string s)
    {
        char[] chars = s.ToCharArray();

        Array.Reverse(chars);

        return new string(chars);
    }

    public static int WordCount(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return 0;

        return s.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

public class TrackedWidget
{
    public Guid InstanceId { get; }

    public static int LiveCount { get; private set; }

    public TrackedWidget()
    {
        InstanceId = Guid.NewGuid();
        LiveCount++;
    }

    public void Dispose()
    {
        LiveCount--;
    }

    public void PrintInfo()
    {
        Console.WriteLine(
            $"Widget {InstanceId}: LiveCount={LiveCount}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(
            $"IsPalindrome(\"racecar\") -> " +
            $"{StringUtils.IsPalindrome("racecar")}");

        Console.WriteLine(
            $"Reverse(\"Hello\") -> " +
            $"{StringUtils.Reverse("Hello")}");

        Console.WriteLine(
            $"WordCount(\"the quick brown fox\") -> " +
            $"{StringUtils.WordCount("the quick brown fox")}");

        // This will NOT compile because StringUtils is static:
        // StringUtils obj = new StringUtils();

        TrackedWidget widget1 = new TrackedWidget();
        TrackedWidget widget2 = new TrackedWidget();
        TrackedWidget widget3 = new TrackedWidget();

        Console.WriteLine(
            $"LiveCount after creating 3 widgets: " +
            $"{TrackedWidget.LiveCount}");

        widget1.PrintInfo();
        widget2.PrintInfo();
        widget3.PrintInfo();

        widget1.Dispose();
        widget2.Dispose();

        Console.WriteLine(
            $"LiveCount after disposing 2: " +
            $"{TrackedWidget.LiveCount}");
    }
}