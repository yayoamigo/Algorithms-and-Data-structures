
   
   
   
   using learning1;
using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("enter your targetSum");
        double targetSum;
        string input;
        try
        {
            input = Console.ReadLine();
            if (!double.TryParse(input, out targetSum))
            {
                Console.WriteLine("Invalid input. Please enter a valid double value.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return;
        }


        Console.WriteLine("enter your array separated by spaces");
        string arr;
        string[] numberStrings;
        double[] numbers;
        try
        {

            arr = Console.ReadLine();
            numberStrings = (arr ?? "").Split(' ');
            numbers = new double[numberStrings.Length];
            for (int i = 0; i < numberStrings.Length; i++)
            {
                if (!double.TryParse(numberStrings[i], out numbers[i]))
                {
                    Console.WriteLine($"Invalid input '{numberStrings[i]}'. Please enter a valid double value.");
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Dictionary<double, double[]?> memo = new Dictionary<double, double[]?>();

      
        BestSum problem = new BestSum(targetSum, numbers, memo);
        double[]? result = problem.sumOperation();
        Console.WriteLine(result == null ? "null" : string.Join(", ", result));




    }
}

   
    public class BestSum
    {
        public double targetSum;
        public double[] numbers;
        public Dictionary<double, double[]?> memo = new Dictionary<double, double[]?>();
        //constructor
        public BestSum(double targetSum, double[] numbers, Dictionary<double, double[]?> memo)
        {
            this.targetSum = targetSum;
            this.numbers = numbers;
            this.memo = memo;
        }

        public double[]? sumOperation()
        {
            if (memo.ContainsKey(targetSum)) return memo[targetSum];

            if (targetSum == 0) return Array.Empty<double>();

            if (targetSum < 0) return null;

             double[]? shortestCombination = null;

            foreach (int num in numbers)
            {
                double reminder = targetSum - num;

                BestSum reminderSum = new BestSum(reminder, numbers, memo);
                double[]? reminderCombination = reminderSum.sumOperation();
                if (reminderCombination != null)
                {
                    double[] combination = reminderCombination.Concat(new double[] { num }).ToArray();
                    if (shortestCombination == null || combination.Length < shortestCombination.Length)
                    {
                        shortestCombination = combination;
                    }
                }

            }

            memo[targetSum] = shortestCombination;
            return shortestCombination;
        }


    }
