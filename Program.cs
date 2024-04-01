using System.Text.RegularExpressions;

namespace HangmanProject
{
    class Program
    {

        private
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");
            while (true)
            {
                Console.WriteLine("Please enter how many players will be playing: ");
                int numPlayers = Utilities.getNumberOfPlayers();
                // create a number of players based on user input
                Player[] players = new Player[numPlayers];
                for (int i = 0; i < numPlayers; i++)
                {
                    Console.WriteLine("Enter the name of player " + (i + 1) + ": ");
                    string name = Utilities.getValidateNameInput();
                    players[i] = new Player();
                    players[i].SetName(name);
                    players[i].SetTurn(i + 1);
                }
                Console.WriteLine("Enter how many rounds you would like to play: ");
                int numRounds = Utilities.getNumberOfRounds();
                Round round = new Round(numRounds);
                Game game = new Game(players);
                Console.WriteLine("word selected: " + game.GetWord()); // TODO remove this line
                int currentPlayerTurn = 0;
                for (int i = 0; i < numRounds; i++)
                {
                    Console.WriteLine("Round " + (i + 1));
                    for (int j = 0; j < game.GetPlayers().Length; j++)
                    {
                        Player currentPlayer = game.GetPlayers()[currentPlayerTurn];
                        currentPlayer.UpdateGamesPlayed();
                        round.playRound(currentPlayer, game);
                        round.isWin(currentPlayer, game);
                        currentPlayer.UpdateScore(round.GetRoundPoints(), currentPlayer.GetIsRoundWinner());
                        currentPlayer.UpdateGamesWon();
                        Console.WriteLine("************************************");
                        currentPlayer.resetLives();
                        game.randomWord();
                        game.SetWordGuessed(false);
                        currentPlayerTurn++;
                    }
                    currentPlayerTurn = 0;
                }
                Console.WriteLine("Game over!");
                Console.WriteLine("Final scores:");
                for (int i = 0; i < game.GetPlayers().Length; i++)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine(game.GetPlayers()[i].GetName() + ": ");
                    game.GetPlayers()[i].DisplayStats();
                    Console.WriteLine("------------------------------------");
                }
                string winner = game.GetWinner().GetName() != "" ? game.GetWinner().GetName() : "It's a tie!";
                Console.WriteLine("The winner is: " + winner);
                Console.WriteLine("Would you like to play again? (yes/no)");
                if (!Utilities.playAgain())
                {
                    break;
                }
            }
        }
    }
}