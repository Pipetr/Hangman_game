using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanProject
{
    /// <summary>
    /// Represents a player of the game.
    /// The player has a name, a score, a number of games played, a number of games won, and a number of games lost.
    /// The player can update their score, games played, games won, and games lost, display their stats, and reset their stats.
    /// </summary>
    class Player
    {
        // Define the attributes of the player
        private string name;
        private int score;
        private int gamesPlayed;
        private int gamesWon;
        private int gamesLost;
        private int turn;
        private int lives;
        private bool isRoundWinner = false;

        // Getter and setter methods
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public int GetScore()
        {
            return score;
        }
        public void SetScore(int score)
        {
            this.score = score;
        }
        public int GetGamesPlayed()
        {
            return gamesPlayed;
        }
        public void SetGamesPlayed(int gamesPlayed)
        {
            this.gamesPlayed = gamesPlayed;
        }
        public int GetGamesWon()
        {
            return gamesWon;
        }
        public void SetGamesWon(int gamesWon)
        {
            this.gamesWon = gamesWon;
        }
        public int GetGamesLost()
        {
            return gamesLost;
        }
        public void SetGamesLost(int gamesLost)
        {
            this.gamesLost = gamesLost;
        }
        public int GetTurn()
        {
            return turn;
        }
        public void SetTurn(int turn)
        {
            this.turn = turn;
        }
        public int GetLives()
        {
            return lives;
        }
        public void SetLives(int lives)
        {
            this.lives = lives;
        }
        public bool GetIsRoundWinner()
        {
            return isRoundWinner;
        }
        public void SetIsRoundWinner(bool isRoundWinner)
        {
            this.isRoundWinner = isRoundWinner;
        }
        // Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// The player has a name, if not specified, the name is an empty string.
        /// The player has a score, initially set to 0. The player has a number of games played, initially set to 0.
        /// The player has a number of games won, initially set to 0. The player has a number of games lost, initially set to 0.
        /// The player can update their score, games played, games won, and games lost, display their stats, and reset their stats.
        /// </summary>
        public Player()
        {
            name = "";
            score = 0;
            gamesPlayed = 0;
            gamesWon = 0;
            gamesLost = 0;
            lives = 6;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// The player has a name, the name is specified by the user and should not be empty. That is the only parameter.
        /// The player has a score, initially set to 0. The player has a number of games played, initially set to 0.
        /// The player has a number of games won, initially set to 0. The player has a number of games lost, initially set to 0.
        /// The player can update their score, games played, games won, and games lost, display their stats, and reset their stats.
        /// </summary>
        public Player(string name)
        {
            this.name = name;
            score = 0;
            gamesPlayed = 0;
            gamesWon = 0;
            gamesLost = 0;
            lives = 6;
        }

        // Helper method
        /*
        * Validates that the number of games played is equal to the sum of games won and games lost.
        If the number of games played is equal to the sum of games won and games lost, the method returns true.
        */

        // Define the methods of the player
        /// <summary>
        /// Updates the player's score by adding the specified score.
        /// Parameters:
        /// score: The score to add to the player's score. must be an integer.
        /// Returns: nothing.(void)
        /// </summary>
        public void UpdateScore(int score, bool isRoundWinner)
        {
            if (isRoundWinner)
            {
                this.score += score;
            }
        }

        /// <summary>
        /// Updates the player's games played by adding 1.
        /// Parameters: none.
        /// Returns: nothing.(void)
        /// </summary>
        public void UpdateGamesPlayed()
        {
            gamesPlayed++;
        }

        /// <summary>
        /// Updates the player's games won by adding 1.
        /// Parameters: none.
        /// Returns: nothing.(void)
        /// </summary>
        public void UpdateGamesWon()
        {
            if (isRoundWinner)
            {
                gamesWon++;
            }
            else
            {
                gamesLost++;
            }
        }

        /// <summary>
        /// Displays the player's stats: name, score, games played, games won, and games lost.
        /// Parameters: none.
        /// Returns: nothing.(void)
        /// </summary>
        public void DisplayStats()
        {
            Console.WriteLine("Player: " + name);
            Console.WriteLine("Score: " + score);
            Console.WriteLine("Games Played: " + gamesPlayed);
            Console.WriteLine("Games Won: " + gamesWon);
            Console.WriteLine("Games Lost: " + gamesLost);
        }

        /// <summary>
        /// Resets the player's stats: score, games played, games won, and games lost.
        /// Parameters: none.
        /// Returns: nothing.(void)
        /// </summary>
        public void resetLives()
        {
            lives = 6;
        }
    }
}