using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangmanProject
{
    class Round(int rounds)
    {
        private int rounds = rounds;
        private bool beginRound = false;
        private bool endRound = false;
        private int roundPoints = 10;

        public int GetRounds()
        {
            return rounds;
        }
        public void SetRounds(int rounds)
        {
            this.rounds = rounds;
        }
        public bool GetBeginRound()
        {
            return beginRound;
        }
        public void SetBeginRound(bool beginRound)
        {
            this.beginRound = beginRound;
        }
        public bool GetEndRound()
        {
            return endRound;
        }
        public void SetEndRound(bool endRound)
        {
            this.endRound = endRound;
        }
        public int GetRoundPoints()
        {
            return roundPoints;
        }

        /// <summary>
        /// Method to play a round of the game
        /// It will display the word to guess and ask the player to guess a letter
        /// If the player guesses the word, the round ends
        /// If the player runs out of lives, the round ends
        /// </summary>
        /// <param name="player"></param>
        /// <param name="game"></param>
        public void playRound(Player player, Game game){
            beginRound = true;
            string playerName = player.GetName();
            Console.WriteLine(playerName + ", it's your turn!");
            Console.WriteLine("Guess the word: " + game.GetGuess());
            while(beginRound){
                if(player.GetLives() == -1){
                    Console.WriteLine("You have no more lives left. Game over!");
                    beginRound = false;
                    break;
                }
                Console.WriteLine("Enter a letter to guess: ");
                char letter = Utilities.getInput();
                if(game.CheckGuess(letter)){
                    Console.WriteLine(game.GetGuess());
                }else
                {
                    game.DrawHangman(player.GetLives());
                    player.SetLives(player.GetLives() - 1);
                    Console.WriteLine("Any letter matched: " + game.GetGuess() + "\n");
                }
                beginRound = !game.fullWordGuess(game.GetGuess());
            }
        }

        /// <summary>
        /// Method to determine if the player won or lost the round
        /// If the player guessed the word, they win the round
        /// If the player ran out of lives, they lose the round
        /// The round ends after the player wins or loses
        /// </summary>
        /// <param name="player"></param>
        /// <param name="game"></param>
        public void isWin(Player player, Game game){
            if(game.GetWordGuessed()){
                Console.WriteLine("The word was: " + game.GetWord());
                Console.WriteLine(player.GetName() + " You win this round!");
                player.SetIsRoundWinner(true);
            }else if(player.GetLives() == -1){
                Console.WriteLine("The word was: " + game.GetWord());
                Console.WriteLine(player.GetName() + " You lose this round!");
                player.SetIsRoundWinner(false);
            }
            endRound = true;
        }
    }
}