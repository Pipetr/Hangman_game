using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangmanProject
{
    public static class Utilities
    {
        public static bool validateInput(string input)
        {
            if (input.Length == 1 && char.IsLetter(input[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static char getInput()
        {
            char letter;
            while (true)
            {
                string input = Console.ReadLine();
                if (validateInput(input))
                {
                    letter = input[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a single letter.");
                }
            }
            return letter;
        }

        public static string getValidateNameInput()
        {
            while (true)
            {
                string name = Console.ReadLine();
                if (name.Length > 0)
                {
                    // regex to validate the name
                    // the name can contain numbers and special characters, but should start with letters
                    if(Regex.Match(name, @"^[a-zA-Z]{2,}.*$").Success)
                    {
                        return name;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid name.");
                        Console.WriteLine("The name should start with a letter and contain at least 2 characters.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                }
            }
        }
        public static int getNumberOfPlayers(){
            int numPlayers = 0;
            while (true)
            {
                try
                {
                    numPlayers = Convert.ToInt32(Console.ReadLine());
                    if (numPlayers > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number greater than 0.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            return numPlayers;
        }

        public static int getNumberOfRounds()
        {
            int numRounds = 0;
            while (true)
            {
                try
                {
                    numRounds = Convert.ToInt32(Console.ReadLine());
                    if (numRounds > 0 && numRounds < 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            return numRounds;
        }

        public static bool playAgain()
        {
            while (true)
            {
                string word = Console.ReadLine();
                if (word?.ToLower() == "yes" || word?.ToLower() == "y")
                {
                    return true;
                }
                else if (word?.ToLower() == "no" || word?.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter yes or no.");
                }
            }
        }
    }
}