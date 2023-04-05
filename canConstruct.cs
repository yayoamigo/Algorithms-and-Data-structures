class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("enter your targetWord");
        string targetWord;
        
        targetWord = Console.ReadLine();
            
        Console.WriteLine("enter your array separated by spaces");
        string arr;
        string[] wordBank;
        try
        {

            arr = Console.ReadLine();
            wordBank = (arr ?? "").Split(' ');
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Dictionary<string, bool> memo = new Dictionary<string, bool>();

      
        canConstruct problem = new canConstruct(targetWord, wordBank, memo);
        bool? result = problem.canConstructOperation();
        Console.WriteLine(result);




    }
}


    public class canConstruct
    {
        public string targetWord;
        public string[] wordBank;
        public Dictionary<string, bool> memo;

        public canConstruct(string targetWord, string[] wordBank, Dictionary<string, bool> memo)
        {
            this.targetWord = targetWord;
            this.wordBank = wordBank;
            this.memo = memo;
        }

        public bool canConstructOperation()
        {
            if (memo.ContainsKey(targetWord)) return memo[targetWord];
            if (targetWord == "") return true;
            foreach (string word in wordBank)
            {
                if (targetWord.IndexOf(word) == 0)
                {
                    string suffix = targetWord.Substring(word.Length);
                    canConstruct problem  = new canConstruct(suffix, wordBank, memo);
                    if (problem.canConstructOperation() == true)
                    {
                        memo[targetWord] = true;
                        return true;
                    }
                }
            }
            memo[targetWord] = false;
            return false;
        }
       
    }
