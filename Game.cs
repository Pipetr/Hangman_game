using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HangmanProject
{
    /// <summary>
    /// Represents a game of Hangman.
    /// The game has a word to guess, a guess, a number of lives, a list of words to choose from, and flags to indicate if the game is over and if the word has been guessed.
    /// The game can be started, the guess can be checked, the game can be ended, and the hangman can be drawn.
    /// </summary>
    class Game
    {
        // Define the attributes of the game
        private string word = "";
        private string guess = "";
        private bool gameOver;
        private bool wordGuessed;
        private Player[] players;
        private int rounds;
        private string[] gameWords = [
                "hello", "world", "hangman", "computer", "science",
                "programming", "software", "engineering", "university",
                "college", "student", "teacher", "classroom", "education",
                "learning", "knowledge", "wisdom", "intelligence",
                "technology", "innovation", "creativity", "imagination",
                "inspiration", "motivation", "dedication", "determination",
                "perseverance", "success", "achievement", "accomplishment",
                "victory", "triumph", "challenge", "opportunity",
                "possibility", "potential", "future", "career",
                "job", "work", "employment", "profession",
                "occupation", "vocation", "calling", "passion",
                "interest", "hobby", "leisure", "recreation", "entertainment",
                "fun", "joy", "happiness", "laughter", "smile", "friendship",
                "family", "relationship", "love", "romance", "marriage",
        ];

        // Getter and setter methods
        public string GetWord()
        {
            return word;
        }
        public void SetWord(string word)
        {
            this.word = word;
        }
        public string GetGuess()
        {
            return guess;
        }
        public void SetGuess(string guess)
        {
            this.guess = guess;
        }
        public string[] GetGameWords()
        {
            return gameWords;
        }
        public void SetGameWords(string[] gameWords)
        {
            this.gameWords = gameWords;
        }
        public bool GetGameOver()
        {
            return gameOver;
        }
        public void SetGameOver(bool gameOver)
        {
            this.gameOver = gameOver;
        }
        public bool GetWordGuessed()
        {
            return wordGuessed;
        }
        public void SetWordGuessed(bool wordGuessed)
        {
            this.wordGuessed = wordGuessed;
        }
        public Player[] GetPlayers()
        {
            return players;
        }
        public void SetPlayers(Player[] players)
        {
            this.players = players;
        }
        public int GetRounds()
        {
            return rounds;
        }
        public void SetRounds(int rounds)
        {
            this.rounds = rounds;
        }
        // Define the methods of the game
        // Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// Initializes the game with a list of words, chooses a random word from a pre-defined the list, and initializes the guess with dashes.
        /// and sets the game over and word guessed flags to false.
        /// </summary>
        public Game(Player[] players)
        {
            randomWord();
            gameOver = false;
            wordGuessed = false;
            this.players = players;
            rounds = 0;
        }

        /// <summary>
        /// Chooses a random word from the list of words and initializes the guess with dashes.
        /// </summary>
        public void randomWord()
        {
            Random random = new Random();
            word = gameWords[random.Next(gameWords.Length)];
            guess = new string('_', word.Length);
        }

        // Check if the guess is correct

        /// <summary>
        /// Checks if the guessed letter is correct and updates the guess accordingly.
        /// If the guessed letter is correct, the guess is updated with the letter in the correct position.
        /// If the guessed letter is incorrect, the number of lives is decremented.
        /// </summary>
        /// <param name="letter"></param>
        public bool CheckGuess(char letter)
        {
            bool isCorrect = false;
            bool printed = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    guess = guess.Substring(0, i) + letter + guess.Substring(i + 1);
                    isCorrect = true;
                    if (!printed)
                    {
                        Console.Write("Correct guess!\t");
                        printed = true;
                    }
                }
                else if (i == word.Length - 1 && !isCorrect)
                {
                    Console.Write("Incorrect guess!");
                }
            }
            return isCorrect;
        }

        /// <summary>
        /// Initializes a new object Player empty.
        /// Compares the scores of the players and determines the winner.
        /// </summary>
        /// <returns>
        /// The player with the highest score.
        /// If there is a tie, returns an empty player.
        /// </returns>
        public Player GetWinner()
        {
            // Determine the winner based on the highest score, if there is a tie, there is no winner
            Player winner = new Player();
            int maxScore = 0;
            bool tie = false;
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].GetScore() > maxScore)
                {
                    winner = players[i];
                    maxScore = players[i].GetScore();
                    tie = false;
                }
                else if (players[i].GetScore() == maxScore)
                {
                    tie = true;
                }
            }
            if (tie)
            {
                winner = new Player();
            }
            return winner;
        }

       /// <summary>
       /// Checks if the full word guessed is correct and updates the word guessed flag.
       /// </summary>
       /// <param name="fullWord"> Type string</param>
       /// <returns>
       /// Returns true if the full word guessed is correct, otherwise returns false.
       /// </returns>

        public bool fullWordGuess(string fullWord)
        {
            if (fullWord == word)
            {
                wordGuessed = true;
                return true;
            }
            return false;
        }

        // Draw the hangman depending on the number of lives
        
        /// <summary>
        /// Draws the hangman based on the number of lives remaining.
        /// </summary>
        public void DrawHangman(int lives)
        {
            switch (lives)
            {
                case 6:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t   --------");
                    break;
                case 5:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t  O   |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t   --------");
                    break;
                case 4:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t  O   |");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t   --------");

                    break;
                case 3:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t  O   |");
                    Console.WriteLine("\t\t /|   |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t   --------");
                    break;
                case 2:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t  O   |");
                    Console.WriteLine("\t\t /|\\  |");
                    Console.WriteLine("\t\t      |");
                    Console.WriteLine("\t\t   --------");

                    break;
                case 1:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t  O   |");
                    Console.WriteLine("\t\t /|\\  |");
                    Console.WriteLine("\t\t  LL  |");
                    Console.WriteLine("\t\t   --------");
                    break;
                case 0:
                    Console.WriteLine("  +---+");
                    Console.WriteLine("\t\t  |   |");
                    Console.WriteLine("\t\t  O   |");
                    Console.WriteLine("\t\t /T\\  |");
                    Console.WriteLine("\t\t / \\  |");
                    Console.WriteLine("\t\t   --------");
                    break;
            }
        }
    }
}