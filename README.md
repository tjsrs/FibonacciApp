# Fibonacci Application

In this example we went through each of the steps of generating a programme with a successful end result.

## First Step
Create the base application, this will error creating a stackoverflow exception

```
class Program
{
    public static void Main()
    {
        uint n = 20;
		n--; // where first number in sequence is 0
		uint sequence = n;		

        Console.Write($"The Answer for sequence { sequence} is { Fibonacci(n)}");
    }
	
    private static ulong Fibonacci(int n)
    {
        return Fibonacci(n - 2) + Fibonacci(n - 1);
    }
}
```

## Second Step
Solves the stack overflow, however, takes too long to calculate large numbers

class Program
{
    public static void Main()
    {
        uint n = 50;
        n--; // where first number in sequence is 0
        uint sequence = n;

        Console.Write($"The Answer for sequence { sequence + 1 } is { Fibonacci(n)}");
        Console.WriteLine();
    }

    private static ulong Fibonacci(ulong n)
    {
        if (n <= 1)
            return n;
        else
            return Fibonacci(n - 2) + Fibonacci(n - 1);
    }
}

## Third Step
Storing the numbers in sequence making it quicker to respond (Memoisation)

class Program
{
    private static ulong[] cache;
    public static void Main()
    {
        uint n = 50;
        n--; // where first number in sequence is 0
        uint sequence = n;
        cache = new ulong[n + 1];

        Console.Write($"The Answer for sequence { sequence + 1 } is { Fibonacci(n)}");
        Console.WriteLine();
    }

    private static ulong Fibonacci(ulong n)
    {
        if (n <= 1)
            return n;
        
        if (cache[n] != 0)
        {
            return cache[n];
        }

        ulong tempcache = Fibonacci(n - 2) + Fibonacci(n - 1);
        cache[n] = tempcache;
        return tempcache;
    }
}

## Final Step
Finished application with added comments for clarity and using the BigInteger datatype to manage numbers exceeding the ulong range.

using System.Numerics;

class Program
{
    // Cache array to store computed Fibonacci values for memoisation
    private static BigInteger[]? cache;

    public static void Main()
    {
        uint n = 100;
        n--; // Decrement n to adjust for zero-based indexing (first number in sequence is 0)
        uint sequence = n;
        cache = new BigInteger[n + 1]; // Initialize the cache array with size n + 1

        // Calculate and print the Fibonacci number at position n (adjusted back to 1-based for output) with comma separation
        Console.Write($"The Answer for sequence {sequence + 1} is {Fibonacci(n):N0}");
        Console.WriteLine();

        // Output all the values of the sequence from 0 to n
        for (int i = 0; i < cache.Length; i++)
        {
            if (cache[i] == 0 && i < 1)
            {
                // Force output of 0 for the first element in the sequence
                Console.WriteLine($"Sequence {(i + 1)} 0");
            }
            else if (cache[i] == 0 && i == 1)
            {
                // Force output of 1 for the second element in the sequence
                Console.WriteLine($"Sequence {(i + 1)} 1");
            }
            else if (cache[i] == 0 && i > 0)
            {
                // This case should never happen if the Fibonacci function works correctly
                Console.WriteLine("Shouldn't happen");
            }
            else
            {
                // Output the computed Fibonacci value, formatted with commas
                Console.WriteLine($"Sequence {(i + 1)} {cache[i]:N0}");
            }
        }
    }

    private static BigInteger Fibonacci(ulong n)
    {
        // Base cases: return n for 0 or 1
        if (n <= 1)
            return n;

        // If the value is already cached, return it to avoid redundant computation
        if (cache?[n] != 0)
        {
            return cache[n];
        }

        // Compute Fibonacci using memoisation and store the result in the cache
        BigInteger tempStore = Fibonacci(n - 2) + Fibonacci(n - 1);
        cache[n] = tempStore;
        return tempStore;
    }
}
