using System;

public class TaxCalculator
{
    public virtual decimal CalculateTax(decimal amount)
    {
        return amount * 0.10m;
    }
}

public class RegionalTaxCalculator : TaxCalculator
{
    public sealed override decimal CalculateTax(decimal amount)
    {
        return amount * 0.12m;
    }
}

/*
    This will NOT compile because CalculateTax()
    was sealed in RegionalTaxCalculator.

    public class InvalidTaxCalculator : RegionalTaxCalculator
    {
        public override decimal CalculateTax(decimal amount)
        {
            return amount * 0.15m;
        }
    }
*/

public sealed class FixedDiscountCalculator
{
    public decimal ApplyDiscount(decimal price)
    {
        return price * 0.90m;
    }
}

/*
    This will NOT compile because
    FixedDiscountCalculator is sealed.

    public class SpecialDiscount : FixedDiscountCalculator
    {
    }
*/

class Program
{
    static void Main()
    {
        RegionalTaxCalculator tax =
            new RegionalTaxCalculator();

        FixedDiscountCalculator discount =
            new FixedDiscountCalculator();

        Console.WriteLine(
            $"RegionalTaxCalculator.CalculateTax(200) -> " +
            $"{tax.CalculateTax(200):F2}");

        Console.WriteLine(
            $"FixedDiscountCalculator.ApplyDiscount(50) -> " +
            $"{discount.ApplyDiscount(50):F2}");
    }
}