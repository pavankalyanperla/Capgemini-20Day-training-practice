/*
Domain: Banking & Financial Services

Real-World Scenario:
Banks process millions of transactions every day. Fraud Detection Systems continuously monitor transactions to identify suspicious activities such as unusually large transfers, repeated transactions from the same account, and abnormal transaction patterns. In this assignment, you will implement core fraud detection features using C# while strengthening your understanding of Arrays, Strings, Loops, Searching, and Problem Solving.

Learning Objectives
After completing this assignment, you will be able to:

Work with arrays of custom objects.
Perform searching and comparison operations.
Apply nested loops effectively.
Build reusable methods.
Analyze time complexity.
Write clean, modular C# code.
Develop logical thinking without relying on AI-generated solutions.
Problem Statement
A bank wants to identify suspicious transactions from a list of customer transactions.

Each transaction contains:

Account ID
Transaction Amount
Timestamp
Merchant Name
You need to implement various fraud detection features.
*/

class Program
{
    static void Main(string[] args)
        {
            Transaction[] transactions = new Transaction[]
            {
                new Transaction("ACC001", 200.00,  new DateTime(2025, 6, 1, 9, 0, 0),  "Kirana Store"),
                new Transaction("ACC001", 150.00,  new DateTime(2025, 6, 1, 10, 0, 0), "Blinkit"),
                new Transaction("ACC001", 9000.00, new DateTime(2025, 6, 1, 11, 0, 0), "Ram Mobile Store"),
                new Transaction("ACC002", 500.00,  new DateTime(2025, 6, 2, 8, 0, 0),  "Gupta's Kitchen"),
                new Transaction("ACC002", 500.00,  new DateTime(2025, 6, 2, 8, 5, 0),  "Gupta's Kitchen"),
                new Transaction("ACC003", 100.00,  new DateTime(2025, 6, 3, 7, 0, 0),  "Book My Show"),
                new Transaction("ACC003", 200.00,  new DateTime(2025, 6, 3, 8, 0, 0),  "Uber"),
                new Transaction("ACC003", 300.00,  new DateTime(2025, 6, 3, 9, 0, 0),  "Zomato"),
                new Transaction("ACC003", 150.00,  new DateTime(2025, 6, 3, 10, 0, 0), "Ola"),
            };
 
            FindHighValueTransactions(transactions, 1000);
            FindDuplicates(transactions);
            FindFrequentAccounts(transactions, 3);
            SearchByAccount(transactions, "ACC001");
        }

    static void FindHighValueTransactions(Transaction[] transactions, double HighValueAmount)
    {
        Console.WriteLine($"High Value Transactions greater than - {HighValueAmount}");
            bool found = false;
            for (int i = 0; i < transactions.Length; i++)
            {
                if (transactions[i].Amount > HighValueAmount)
                {
                    Console.WriteLine("Account: " + transactions[i].AccountId +
                                      " | Amount: " + transactions[i].Amount +
                                      " | Merchant: " + transactions[i].Merchant);
                    found = true;
                }
            }
            if (!found) 
            Console.WriteLine("None found.");
    }

    static void FindDuplicates(Transaction[] transactions)
    {
        Console.WriteLine("\nDuplicate Transactions:");

        bool found = false;

        for (int i = 0; i < transactions.Length - 1; i++)
        {
            for (int j = i + 1; j < transactions.Length; j++)
            {
                if (transactions[i].AccountId == transactions[j].AccountId &&
                    transactions[i].Amount == transactions[j].Amount &&
                    transactions[i].Merchant == transactions[j].Merchant)
                {
                    Console.WriteLine($"{transactions[i].AccountId} | {transactions[i].Amount} | {transactions[i].Merchant}");
                    found = true;
                }
            }
        }

        if (!found)
            Console.WriteLine("None found.");
    }
    static void FindFrequentAccounts(Transaction[] transactions, int limit)
    {
        Console.WriteLine("\nFrequent Accounts:");

        for (int i = 0; i < transactions.Length; i++)
        {
            int count = 0;

            foreach (Transaction t in transactions)
                if (t.AccountId == transactions[i].AccountId)
                    count++;

            if (count > limit)
            {
                Console.WriteLine($"{transactions[i].AccountId} | {count} transactions");

                while (i + 1 < transactions.Length &&
                    transactions[i].AccountId == transactions[i + 1].AccountId)
                    i++;
            }
        }
    }

    static void SearchByAccount(Transaction[] transactions, string accountId)
    {
        Console.WriteLine($"\nTransactions for {accountId}:");

        bool found = false;

        foreach (Transaction t in transactions)
        {
            if (t.AccountId == accountId)
            {
                Console.WriteLine($"{t.Merchant} | {t.Amount} | {t.Timestamp}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Account not found.");
    }
}


class Transaction
{
    public string AccountId;
    public double Amount;
    public DateTime Timestamp;
    public string Merchant;

    public Transaction(string accountId, double amount, DateTime timestamp, string merchant)
        {
            AccountId = accountId;
            Amount = amount;
            Timestamp = timestamp;
            Merchant = merchant;
        }
}