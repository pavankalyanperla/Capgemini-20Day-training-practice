using System;
using System.Collections.Generic;
using System.Linq;

public abstract class NotificationChannel
{
    public bool TrySend(string message)
    {
        try
        {
            return Send(message);
        }
        catch
        {
            return false;
        }
    }

    protected abstract bool Send(string message);
}

public class EmailChannel : NotificationChannel
{
    protected override bool Send(string message)
    {
        return true;
    }
}

public class SmsChannel : NotificationChannel
{
    protected override bool Send(string message)
    {
        if (message.Length > 160)
        {
            throw new Exception("SMS message too long");
        }

        return true;
    }
}

class Program
{
    static void Main()
    {
        List<NotificationChannel> channels =
            new List<NotificationChannel>
            {
                new EmailChannel(),
                new SmsChannel(),
                new EmailChannel(),
                new SmsChannel()
            };

        string shortMessage = "Hello from ABC Technologies";

        string longMessage = new string('A', 200);

        List<(NotificationChannel Channel, string Message)> tests =
            new List<(NotificationChannel, string)>
            {
                (channels[0], shortMessage),
                (channels[1], shortMessage),
                (channels[2], longMessage),
                (channels[3], longMessage)
            };

        var report = tests.Select(x => new
        {
            ChannelType = x.Channel.GetType().Name,
            Success = x.Channel.TrySend(x.Message)
        }).ToList();

        foreach (var result in report)
        {
            Console.WriteLine(
                $"{result.ChannelType}: " +
                $"{(result.Success ? "Success" : "Failed")}");
        }

        int succeeded = report.Count(x => x.Success);
        int failed = report.Count(x => !x.Success);

        Console.WriteLine();
        Console.WriteLine(
            $"Succeeded: {succeeded}, Failed: {failed}");
    }
}