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
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        
        Dictionary<double, bool> memo = new Dictionary<double, bool>();

        CanSum problem = new CanSum(targetSum, numbers, memo);
        Console.WriteLine(problem.seeCanSum());
        


    }
}

public class CanSum
{
    public double targetSum;

    public double[] numbers = { };

    public Dictionary<double,bool> memo = new Dictionary<double,bool>();

    public  CanSum(double targetSum, double[] numbers, Dictionary<double,bool> memo)
    {
        this.targetSum = targetSum;
        this.numbers = numbers;
        this.memo= memo;
    }

    public bool seeCanSum()
    {
        if (memo.ContainsKey(this.targetSum)) { return memo[targetSum]; }
        if( targetSum == 0 ) { return true; }
        if (targetSum < 0 ) { return false; }

        foreach ( double x in numbers )
        {
            double remainder = targetSum - x;
            CanSum remainderSum = new CanSum(remainder, numbers, memo);
            if( remainderSum.seeCanSum() == true ) { 
                memo[targetSum] = true;
                return true;
            };

            
        }
        memo[targetSum] = false;
        return false;
    }

}
