using System;


class Program
{
    static void Main(string[] args)
    {
        int m = 3;
        int n = 3;
        Dictionary<string,int> memo = new Dictionary<string,int>();
        int result = gridTravel.Grid(m, n, memo);
        Console.WriteLine(result);
    }
}

public static class gridTravel
{
    public static int Grid(int m, int n, Dictionary<string, int> memo)
    {
        string key = $"{m},{n}";
        if (memo.ContainsKey(key))
        {
            return memo[key];
        }
        if (m == 1 && n == 1)
        {
            return 1;
        }
        if (m == 0 || n == 0)
        {
            return 0;
        }

        memo[key] = Grid(m - 1, n, memo) + Grid(m, n - 1, memo);
        return memo[key];
    }
}
