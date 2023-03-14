using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        int n = 10;
        Dictionary<int, BigInteger> memo = new Dictionary<int, BigInteger>();

        BigInteger result = Fibonacci.Fib(n, memo);
        Console.WriteLine($"The {n}th Fibonacci number is {result}.");
    }
}

public static class Fibonacci
{
    public static BigInteger Fib(int n, Dictionary<int, BigInteger> memo)
    {
        if (memo.ContainsKey(n))
        {
            return memo[n];
        }

        if (n <= 2)
        {
            return 1;
        }

        memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
        return memo[n];
    }
}
