public class HowSum
    {
        public double TargetSum { get; set; }

        public double[] Numbers;

        public Dictionary<double, double[]?> memo = new Dictionary<double, double[]?>();

        public HowSum(double TargetSum, double[] Numbers, Dictionary<double, double[]?> memo)
        {
            this.TargetSum = TargetSum;
            this.Numbers = Numbers;
            this.memo = memo;
        }

        public double[]? SeeHowSum()
        {
            if (memo.ContainsKey(TargetSum)) return memo[TargetSum];
            if (TargetSum == 0) return Array.Empty<double>();
            if (TargetSum < 0) return null;

            foreach (double x in Numbers)
            {
                double remainder = TargetSum - x;
                HowSum remainderSum = new HowSum(remainder, Numbers, memo);
                double[]? remainderResult = remainderSum.SeeHowSum();
                if (remainderResult != null)
                {
                    double[] resultArray = remainderResult.Concat(new double[] { x }).ToArray();
                    memo[TargetSum] = resultArray;
                    return resultArray;
                }
            }
            memo[TargetSum] = null;
            return null;
        }
    }

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

      
        HowSum problem = new HowSum(targetSum, numbers, memo);
        double[]? result = problem.SeeHowSum();
        Console.WriteLine(result == null ? "null" : string.Join(", ", result));




    }
}
