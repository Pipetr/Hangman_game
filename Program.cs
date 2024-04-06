using System.Text.RegularExpressions;

namespace HangmanProject
{
    class Program
    {

        private
        static void Main(string[] args)
        {   // Begining of the game
            Console.WriteLine("Welcome to Hangman!");
            while (true) // loop to play the game again
            {   // Get the number of players
                Console.WriteLine("Please enter how many players will be playing: ");
                int numPlayers = Utilities.getNumberOfPlayers();
                // create a number of players based on user input
                Player[] players = new Player[numPlayers];
                for (int i = 0; i < numPlayers; i++)
                {   // Get the name of each player
                    Console.WriteLine("Enter the name of player " + (i + 1) + ": ");
                    string name = Utilities.getValidateNameInput();
                    players[i] = new Player();
                    players[i].SetName(name);
                    players[i].SetTurn(i + 1);
                }  // Get the number of rounds
                Console.WriteLine("Enter how many rounds you would like to play: ");
                int numRounds = Utilities.getNumberOfRounds(); 
                Round round = new Round(numRounds); // create a new round object
                Game game = new Game(players); // create a new game object
                int currentPlayerTurn = 0; // set the current player turn to 0, control variable
                for (int i = 0; i < numRounds; i++)
                {
                    Console.WriteLine("Round " + (i + 1));
                    for (int j = 0; j < game.GetPlayers().Length; j++)
                    {  // Get the current player
                        Player currentPlayer = game.GetPlayers()[currentPlayerTurn];
                        currentPlayer.UpdateGamesPlayed(); // update the number of games played
                        round.playRound(currentPlayer, game); // play the round
                        round.isWin(currentPlayer, game); // check if the player won
                        currentPlayer.UpdateScore(round.GetRoundPoints(), currentPlayer.GetIsRoundWinner()); // update the score
                        currentPlayer.UpdateGamesWon(); // update the number of games won or loose
                        Console.WriteLine("************************************");
                        currentPlayer.resetLives(); // reset the lives
                        game.randomWord(); // get a new word
                        game.SetWordGuessed(false); // set the word guessed to false
                        currentPlayerTurn++; // increment the current player turn
                    }
                    currentPlayerTurn = 0; // reset the current player turn
                }
                Console.WriteLine("Game over!");
                Console.WriteLine("Final scores:");
                for (int i = 0; i < game.GetPlayers().Length; i++)
                {   // Display the final scores
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine(game.GetPlayers()[i].GetName() + ": ");
                    game.GetPlayers()[i].DisplayStats();
                    Console.WriteLine("------------------------------------");
                }
                // Display the winner
                string winner = game.GetWinner().GetName() != "" ? game.GetWinner().GetName() : "It's a tie!";
                Console.WriteLine("The winner is: " + winner);
                Console.WriteLine("Would you like to play again? (yes/no)");
                if (!Utilities.playAgain())
                {   // End the game
                    break;
                }
            }
        }
    }
}