using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string answer;
            do
            {
                try
                {
                    string line = GetLine();
                    char firstLetter = GetFirstCharacter(line);
                    Console.WriteLine("The first letter is: " + firstLetter);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + " Probably, the string is empty.");
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message + " Probably, the string is null.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " An unknown error has occured.");
                }

                Console.WriteLine("Do you want to try again? (yes/no) ");
                answer = Console.ReadLine();
            }
            while (answer != "no");
        }

        public static char GetFirstCharacter(string line)
        {
            char firstCharacter;
            if (line == null)
            {
                throw new NullReferenceException();
            }
            else if (line.Length <= 0)
                throw new ArgumentOutOfRangeException();
            else
                firstCharacter = line[0];
            return line[0];
        }

        public static string GetLine()
        {
            Console.WriteLine("Enter any line: ");
            string enteredString = Console.ReadLine();
            return enteredString;
        }
    }
}