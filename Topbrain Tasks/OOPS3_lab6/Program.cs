using System;
using System.Collections.Generic;

public class CacheEntryOptions
{
    public string Label { get; set; } = string.Empty;

    public bool Pinned { get; set; }
}

public class TypedCache<TKey, TValue>
    where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _store = new();

    private static int _totalInstances;

    public TypedCache()
    {
        _totalInstances++;
    }

    public TValue this[TKey key]
    {
        get
        {
            if (!_store.ContainsKey(key))
            {
                throw new KeyNotFoundException(
                    $"The given key '{key}' was not present in the cache.");
            }

            return _store[key];
        }

        set
        {
            _store[key] = value;
        }
    }

    public int Count => _store.Count;

    public static int TotalCacheInstances
    {
        get
        {
            return _totalInstances;
        }
    }

    public static void PrintGlobalStats()
    {
        Console.WriteLine(
            $"Global TypedCache<string,int> instances created: " +
            $"{_totalInstances}");
    }

    public void Add(
        TKey key,
        TValue value,
        CacheEntryOptions? options = null)
    {
        _store[key] = value;

        if (options != null)
        {
            Console.WriteLine(
                $"Added '{key}' with label '{options.Label}' " +
                $"Pinned={options.Pinned}");
        }
    }
}

class Program
{
    static void Main()
    {
        TypedCache<string, int> cache1 =
            new TypedCache<string, int>();

        TypedCache<string, int> cache2 =
            new TypedCache<string, int>();

        cache1.Add(
            "a",
            1,
            new CacheEntryOptions
            {
                Label = "First Value",
                Pinned = true
            });

        cache1.Add("b", 2);

        cache2.Add("x", 100);
        cache2.Add("y", 200);

        Console.WriteLine(
            $"cache1[\"a\"] = {cache1["a"]}");

        Console.WriteLine(
            $"cache1 Count: {cache1.Count}");

        try
        {
            Console.WriteLine(cache1["z"]);
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(
                $"Missing key caught: {ex.Message}");
        }

        TypedCache<string, int>.PrintGlobalStats();
    }
}