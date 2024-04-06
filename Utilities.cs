using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HangmanProject
{
    /// <summary>
    /// A class that contains utility methods for the Hangman game.
    /// The utility methods include input validation and user input.
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Method to validate the user input.
        /// The input should be a single letter.
        /// </summary>
        /// <param name="input">The user input to validate</param>
        /// <returns>True if the input is valid, false otherwise</returns>
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

        /// <summary>
        /// Method to get a valid single letter input from the user.
        /// </summary>
        /// <returns>The valid single letter input</returns>
        /// <remarks>
        /// This method will keep asking the user for input until a valid single letter is entered.
        /// </remarks>
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

        /// <summary>
        /// Method to validate the name input.
        /// The name should start with a letter and contain at least 2 characters.
        /// </summary>
        /// <returns>The valid name input</returns>
        /// <remarks>
        /// This method will keep asking the user for input until a valid name is entered.
        /// </remarks>
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
        /// <summary>
        /// Method to get the number of players from the user.
        /// The number of players should be a positive integer.
        /// </summary>
        /// <returns>
        /// Returns the number of players entered by the user.
        /// </returns>
        /// <remarks>
        /// This method will keep asking the user for input until a valid number of players is entered.
        /// </remarks>
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

        /// <summary>
        /// Method to get the number of rounds from the user.
        /// The number of rounds should be between 1 and 4.
        /// </summary>
        /// <returns>
        /// Returns the number of rounds entered by the user.
        /// </returns>
        /// <remarks>
        /// This method will keep asking the user for input until a valid number of rounds is entered.
        /// </remarks>
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

        /// <summary>
        /// Method to get the choice from the user.
        /// The choice should be either 'yes' or 'no'.
        /// </summary>
        /// <returns>
        /// Returns true if the user enters 'yes' or 'y', false if the user enters 'no' or 'n'.
        /// </returns>
        /// <remarks>
        /// This method will keep asking the user for input until a valid choice is entered.
        /// </remarks>
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