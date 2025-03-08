using System;

// Fraction class to represent and work with fractions
class Fraction
{
    // Properties for numerator and denominator
    private int _numerator;
    private int _denominator;

    // Default constructor - creates the fraction 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor for whole numbers - creates the fraction n/1
    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    // Constructor for fractions - creates the fraction top/bottom
    public Fraction(int top, int bottom)
    {
        // Handle division by zero
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero");
        }

        _numerator = top;
        _denominator = bottom;
    }

    // Method to get the fraction as a decimal value
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }

    // Method to display the fraction in various formats
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to display a mixed number format when applicable
    public string GetDisplayValue()
    {
        if (_numerator == 0)
        {
            return "0";
        }
        else if (_denominator == 1)
        {
            return _numerator.ToString();
        }
        else if (Math.Abs(_numerator) > _denominator)
        {
            int wholeNumber = _numerator / _denominator;
            int remainder = Math.Abs(_numerator) % _denominator;
            
            if (remainder == 0)
            {
                return wholeNumber.ToString();
            }
            else
            {
                return $"{wholeNumber} {remainder}/{_denominator}";
            }
        }
        else
        {
            return GetFractionString();
        }
    }

    // Method to reduce the fraction to lowest terms
    public void Reduce()
    {
        int gcd = CalculateGCD(Math.Abs(_numerator), Math.Abs(_denominator));
        _numerator /= gcd;
        _denominator /= gcd;
        
        // Ensure the sign is in the numerator
        if (_denominator < 0)
        {
            _numerator = -_numerator;
            _denominator = -_denominator;
        }
    }

    // Helper method to calculate the Greatest Common Divisor using Euclidean algorithm
    private int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Arithmetic operations
    public Fraction Add(Fraction other)
    {
        int newNumerator = _numerator * other._denominator + other._numerator * _denominator;
        int newDenominator = _denominator * other._denominator;
        Fraction result = new Fraction(newNumerator, newDenominator);
        result.Reduce();
        return result;
    }

    public Fraction Subtract(Fraction other)
    {
        int newNumerator = _numerator * other._denominator - other._numerator * _denominator;
        int newDenominator = _denominator * other._denominator;
        Fraction result = new Fraction(newNumerator, newDenominator);
        result.Reduce();
        return result;
    }

    public Fraction Multiply(Fraction other)
    {
        int newNumerator = _numerator * other._numerator;
        int newDenominator = _denominator * other._denominator;
        Fraction result = new Fraction(newNumerator, newDenominator);
        result.Reduce();
        return result;
    }

    public Fraction Divide(Fraction other)
    {
        // Dividing by a fraction is the same as multiplying by its reciprocal
        if (other._numerator == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        
        int newNumerator = _numerator * other._denominator;
        int newDenominator = _denominator * other._numerator;
        Fraction result = new Fraction(newNumerator, newDenominator);
        result.Reduce();
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Fractions Program");
        Console.WriteLine("----------------");

        // Example 1: Default constructor (1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine($"Fraction 1: {f1.GetDisplayValue()}");
        Console.WriteLine($"Decimal value: {f1.GetDecimalValue()}");
        
        // Example 2: Constructor with whole number (6/1)
        Fraction f2 = new Fraction(6);
        Console.WriteLine($"\nFraction 2: {f2.GetDisplayValue()}");
        Console.WriteLine($"Decimal value: {f2.GetDecimalValue()}");
        
        // Example 3: Constructor with numerator and denominator (6/7)
        Fraction f3 = new Fraction(6, 7);
        Console.WriteLine($"\nFraction 3: {f3.GetDisplayValue()}");
        Console.WriteLine($"Decimal value: {f3.GetDecimalValue()}");
        
        // Example 4: Mixed number display (3 1/2)
        Fraction f4 = new Fraction(7, 2);
        Console.WriteLine($"\nFraction 4: {f4.GetDisplayValue()}");
        Console.WriteLine($"Decimal value: {f4.GetDecimalValue()}");
        
        // Example 5: Reducing fractions
        Fraction f5 = new Fraction(12, 30);
        Console.WriteLine($"\nBefore reduction: {f5.GetFractionString()}");
        f5.Reduce();
        Console.WriteLine($"After reduction: {f5.GetFractionString()}");
        
        // Example 6: Arithmetic operations
        Fraction f6 = new Fraction(1, 4);
        Fraction f7 = new Fraction(1, 2);
        
        Console.WriteLine($"\nArithmetic operations with {f6.GetFractionString()} and {f7.GetFractionString()}:");
        
        Fraction sum = f6.Add(f7);
        Console.WriteLine($"Addition: {f6.GetFractionString()} + {f7.GetFractionString()} = {sum.GetFractionString()} or {sum.GetDisplayValue()}");
        
        Fraction difference = f6.Subtract(f7);
        Console.WriteLine($"Subtraction: {f6.GetFractionString()} - {f7.GetFractionString()} = {difference.GetFractionString()} or {difference.GetDisplayValue()}");
        
        Fraction product = f6.Multiply(f7);
        Console.WriteLine($"Multiplication: {f6.GetFractionString()} * {f7.GetFractionString()} = {product.GetFractionString()} or {product.GetDisplayValue()}");
        
        Fraction quotient = f6.Divide(f7);
        Console.WriteLine($"Division: {f6.GetFractionString()} / {f7.GetFractionString()} = {quotient.GetFractionString()} or {quotient.GetDisplayValue()}");
    }
}