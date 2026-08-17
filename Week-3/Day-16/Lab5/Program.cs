Console.WriteLine("-- Missing customer name --");
ProcessOrder("", 3, 10m);

Console.WriteLine("\n-- Zero quantity --");
ProcessOrder("Alice", 0, 10m);

Console.WriteLine("\n-- Negative price --");
ProcessOrder("Bob", 2, -5m);

Console.WriteLine("\n-- Valid order, SaveOrder fails --");
ProcessOrder("SaveFailCustomer", 2, 10m);

Console.WriteLine("\n-- Fully valid order --");
ProcessOrder("Charlie", 4, 49.99m);

Console.WriteLine("\n-- Bonus: exception filters (when clauses) --");
DemoQuantityFilters(0);
DemoQuantityFilters(-3);

static decimal ValidateOrder(string customerName, int quantity, decimal unitPrice)
{
    if (string.IsNullOrEmpty(customerName))
        throw new MissingFieldException("customerName");
    if (quantity <= 0)
        throw new InvalidQuantityException("quantity", quantity);
    if (unitPrice < 0)
        throw new OrderValidationException("Unit price cannot be negative");
    return quantity * unitPrice;
}

static void SaveOrder(string customerName, int quantity, decimal unitPrice)
{
    // Simulated low-level failure: pretend the database is unreachable for a
    // particular customer, so both the failure path and the happy path can be
    // demonstrated from the same method.
    if (customerName == "SaveFailCustomer")
        throw new InvalidOperationException("Database unavailable");
}

static void ProcessOrder(string customerName, int quantity, decimal unitPrice)
{
    try
    {
        decimal total = ValidateOrder(customerName, quantity, unitPrice);

        try
        {
            SaveOrder(customerName, quantity, unitPrice);
        }
        catch (InvalidOperationException ex)
        {
            // `throw;` only re-raises the exact exception object currently being
            // caught, reusing its existing stack trace. Here we are constructing a
            // brand NEW exception (OrderValidationException) to represent this
            // failure at a higher level, so there is no caught frame to preserve -
            // we must explicitly `throw` that new object instead.
            throw new OrderValidationException($"Could not save order (caused by: {ex.Message})", ex);
        }

        Console.WriteLine($"Order total: ${total:F2}");
    }
    catch (MissingFieldException ex)
    {
        Console.WriteLine($"Missing field: {ex.FieldName}");
    }
    catch (InvalidQuantityException ex)
    {
        Console.WriteLine($"Invalid quantity for field: {ex.FieldName}");
    }
    catch (OrderValidationException ex)
    {
        Console.WriteLine($"Order validation failed: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Order attempt complete.");
    }
}

static void DemoQuantityFilters(int quantity)
{
    try
    {
        ValidateOrder("Dana", quantity, 10m);
    }
    catch (InvalidQuantityException ex) when (ex.Quantity == 0)
    {
        Console.WriteLine($"Quantity is exactly zero for field: {ex.FieldName}");
    }
    catch (InvalidQuantityException ex) when (ex.Quantity < 0)
    {
        Console.WriteLine($"Quantity is negative for field: {ex.FieldName}");
    }
}

public class OrderValidationException : Exception
{
    public string? FieldName { get; }
    public OrderValidationException() : base() { }
    public OrderValidationException(string message) : base(message) { }
    public OrderValidationException(string message, Exception inner) : base(message, inner) { }
    public OrderValidationException(string message, string fieldName) : base(message) => FieldName = fieldName;
}

public class MissingFieldException : OrderValidationException
{
    public MissingFieldException(string fieldName)
        : base($"Required field '{fieldName}' is missing.", fieldName)
    {
    }
}

public class InvalidQuantityException : OrderValidationException
{
    public int Quantity { get; }

    public InvalidQuantityException(string fieldName, int quantity)
        : base($"Quantity must be greater than zero (got {quantity}).", fieldName)
    {
        Quantity = quantity;
    }
}
