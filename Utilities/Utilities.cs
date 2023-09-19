namespace Utils;

// static classes are not instantiated
public static class Utilities
{
    public static bool IsZeroOrNegative(int value)
    {
        // if the value is less than or equal to zero the value that gets returned is true and vice verrsa
        return value <= 0;
    }

    // Expression-bodied method: this is another way to write a method that's only purpose is to return a value
    public static bool IsNullEmptyOrWhiteSpace(string value) => String.IsNullOrWhiteSpace(value);

    // this method uses the terrinary operator which means if the value is greater than zero return true otherwise return false
    public static bool IsPositive(int value) => value > 0 ? true : false;
    public static bool IsPositive(double value) => value > 0.0 ? true : false;
    public static bool IsPositive(decimal value) => value > 0.0m ? true : false;
    // the above three lines of code are examples of method overloading

    public static bool IsInTheFuture(DateOnly value) => value > DateOnly.FromDateTime(DateTime.Now);
}

