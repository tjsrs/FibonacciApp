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
        // Memoisation explained: https://www.geeksforgeeks.org/what-is-memoization-a-complete-tutorial/
        BigInteger tempStore = Fibonacci(n - 2) + Fibonacci(n - 1);
        cache[n] = tempStore;
        return tempStore;
    }
}
