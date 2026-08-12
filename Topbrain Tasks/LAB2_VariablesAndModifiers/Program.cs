// Lab 2: Instance/Static Variables & Access Modifiers

using System;

public class LibraryBook
{
    // private: only accessible within LibraryBook itself
    private string _isbn;

    // public: accessible from anywhere
    public string Title;

    // protected: accessible within LibraryBook and any subclass
    protected string ShelfLocation = "Unassigned";

    // internal: accessible anywhere within the same assembly
    internal int CopiesAvailable;

    // static: shared across ALL instances, not per-object
    public static int TotalBooksCreated;

    public LibraryBook(string title, string isbn)
    {
        Title = title;
        _isbn = isbn;
        CopiesAvailable = 1;
        TotalBooksCreated++;
        Console.WriteLine($"Book '{Title}' created. Total books so far: {TotalBooksCreated}");
    }

    // protected internal: accessible from subclasses OR same assembly
    protected internal void Relocate(string newLocation)
    {
        ShelfLocation = newLocation;
    }

    // private protected: accessible only from subclasses within the same assembly
    private protected void AdjustCopies(int delta)
    {
        CopiesAvailable += delta;
    }
}

public class ReferenceBook : LibraryBook
{
    public ReferenceBook(string title, string isbn) : base(title, isbn) { }

    public void PrintLocation()
    {
        // ShelfLocation is protected  -> accessible here
        Console.WriteLine($"Current shelf: {ShelfLocation}");

        // Relocate is protected internal -> accessible here
        Relocate("Reference Section");
        Console.WriteLine($"ReferenceBook shelf location after Relocate: \"{ShelfLocation}\"");

        // AdjustCopies is private protected -> accessible here (subclass, same assembly)
        AdjustCopies(2);
        Console.WriteLine($"Copies available after AdjustCopies(+2): {CopiesAvailable}");
    }
}

public class Lab2
{
    public static void Main()
    {
        var book1 = new LibraryBook("Clean Code", "978-0132350884");
        var book2 = new LibraryBook("The Pragmatic Programmer", "978-0201616224");
        var book3 = new LibraryBook("Design Patterns", "978-0201633610");

        Console.WriteLine();

        var refBook = new ReferenceBook("Encyclopedia of CS", "978-0000000001");
        Console.WriteLine();
        refBook.PrintLocation();
    }
}