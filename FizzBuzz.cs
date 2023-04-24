
class Program
{
    static void Main(string[] args)
    {
        string num;
        Console.WriteLine("Enter a number");
        num = Console.ReadLine();
        
        Console.WriteLine(fizzBuzz.FizzOps(num));



    }
}




    public class fizzBuzz
    {
  
        public static string FizzOps(string num)
        {
            int number = int.TryParse(num, out number) ? number : 0;
            string result = string.Empty;

            for (int i = 1; i <= number; i++)
            {

                string Currentresult = string.Empty;
                if (i % 3 == 0)
                {
                   Currentresult += "fizz";
                }
                if (i % 5 == 0)
                {
                    Currentresult += "buzz";
                }
                else if( Currentresult == string.Empty)
                {
                    Currentresult += i.ToString();
                }

                 result += Currentresult + Environment.NewLine;
            }

            return result;
        }

    }

