class Program
{

    static void Main(string[] args)
    {
        

        Console.WriteLine("please enter your option 1. encode 2. decode");

        int option;
        Boolean isOption = int.TryParse(Console.ReadLine(), out option);
        if (isOption)
        {
            Console.WriteLine("please enter your word");
            string word = Console.ReadLine();
            if (word != null)
            {
                Console.WriteLine("please enter your shift");
                int shift;
                Boolean isShift = int.TryParse(Console.ReadLine(), out shift);
                if (isShift)
                {
                    if (option == 1)
                    {
                        string encodedWord = Cipher.Encode(word, shift);
                        Console.WriteLine("your encoded word is: " + encodedWord);
                    }
                    else if (option == 2)
                    {
                        string decodedWord = Cipher.Decode(word, shift);
                        Console.WriteLine("your decoded word is: " + decodedWord);
                    }
                    else
                    {
                        Console.WriteLine("please enter a valid option");
                    }

                   Console.WriteLine("do you want to continue?  yes or no");
                   string Continue = Console.ReadLine();
                    while (Continue == "yes") 
                    { 
                        Console.WriteLine("please enter your option 1. encode 2. decode");
                        int option1;
                        Boolean isOption1 = int.TryParse(Console.ReadLine(), out option1);
                        if (isOption1)
                        {
                            Console.WriteLine("please enter your word");
                            string word1 = Console.ReadLine();
                            if (word1 != null)
                            {
                                Console.WriteLine("please enter your shift");
                                int shift1;
                                Boolean isShift1 = int.TryParse(Console.ReadLine(), out shift1);
                                if (isShift1)
                                {
                                    if (option1 == 1)
                                    {
                                        string encodedWord1 = Cipher.Encode(word1, shift1);
                                        Console.WriteLine("your encoded word is: " + encodedWord1);
                                    }
                                    else if (option1 == 2)
                                    {
                                        string decodedWord1 = Cipher.Decode(word1, shift1);
                                        Console.WriteLine("your decoded word is: " + decodedWord1);
                                    }
                                    else
                                    {
                                        Console.WriteLine("please enter a valid option");
                                    }
                                    Console.WriteLine("do you want to continue?  yes or no");
                                    string Continue1 = Console.ReadLine();
                                    if (Continue1 == "no")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("please enter a valid option");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("please enter a valid shift");
                                }
                            }
                            else
                            {
                                Console.WriteLine("please enter a valid word");
                            }
                        }
                        else
                        {
                            Console.WriteLine("please enter a valid option");
                        }   
                    
                    }
                }
                else
                {
                    Console.WriteLine("please enter a valid shift");
                }
            }
            else
            {
                    Console.WriteLine("please enter a valid word");
            }
        }
        else
        {
            Console.WriteLine("please enter a valid option");   
        }




    }
}
namespace learning1
{

   


    public class Cipher
    {
        private static char[] letters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                  'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        public static string Encode(string word, int shift )
        {
            word = word.ToUpper();
            int maxShift = letters.Length;
            char[] wordArray = new char[word.Length];
            for(int i = 0; i < word.Length; i++)
            {
                wordArray[i] = word[i];
                int index = Array.IndexOf(letters, word[i]);
                if (index != -1)
                {
                    int newIndex = (index + shift);
                    if(newIndex >= maxShift)
                    {
                        newIndex = newIndex - maxShift;
                    }
                    wordArray[i] = letters[newIndex];
                }

            }

            string encodedWord = new string(wordArray);
            return encodedWord;

        }

        public static string Decode(string word, int shift)
        {
            word = word.ToUpper();
            int maxShift = letters.Length;
            char[] wordArray = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                wordArray[i] = word[i];
                int index = Array.IndexOf(letters, word[i]);
                if (index != -1)
                {
                    int newIndex = index - shift;
                    if (newIndex < 0)
                    {
                        newIndex = newIndex + maxShift;
                    }
                    wordArray[i] = letters[newIndex];
                }

            }

            string decodedWord = new string(wordArray);
            return decodedWord;

        }
  

    }
}
