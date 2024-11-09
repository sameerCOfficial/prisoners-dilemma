namespace PrisonersDilemma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to the Prisoner's Dilemma, do you need the rules? (y or n)");
            string? userInput = Console.ReadLine();
            char rules = 'n';
            
            //Making sure the user provides the corect format
            if (!string.IsNullOrEmpty(userInput) && userInput.Length == 1)
            {
                rules = Convert.ToChar(userInput);
            } else {
                Console.WriteLine("Invalid format, I'll assume you don't need the rules!!");
            }
            
            if (rules == 'y')
            {
                Console.WriteLine("In the Prisoner's Dilemma, both you and your opponent have two choices: Cooperate or Defect.");
                Console.WriteLine("If both players cooperate, they both receive 3 points.");
                Console.WriteLine("If one defects and the other cooperates, the defector gets 5 points and the cooperator gets 0 :(");
                Console.WriteLine("If both defect, they both receive a single point.");
                Console.WriteLine("The game is played for a fixed number of rounds, most points wins.");
            }

            Console.WriteLine("Choose your opponent's strategy");
            Console.WriteLine("Choices are: \n1 - Tit For Tat, Opponent will mirror your moves, \n2 - Unconditionally Defect, \n3 - Unconditionally Cooperate");
            int strategy = Convert.ToInt32(Console.ReadLine());

            PlayerStrategy opponentStrategy;

            // Determine the opponent's strategy based on user input
            switch (strategy)
            {
                case 1:
                    opponentStrategy = new PlayerStrategy(Types.Strategy.TFT); // Tit For Tat
                    break;

                case 2:
                    opponentStrategy = new PlayerStrategy(Types.Strategy.DU); // Defect Unconditionally
                    break;

                case 3:
                    opponentStrategy = new PlayerStrategy(Types.Strategy.CU); // Cooperate Unconditionally
                    break;

                default:
                    Console.WriteLine("Invalid choice, I'll assume you want me to constantly defect, you sly dog.");
                    opponentStrategy = new PlayerStrategy(Types.Strategy.DU);
                    break;
            }

            int rounds  = 0;
            int player1Score = 0;
            int player2Score = 0;
            Console.WriteLine("Enter 1 to Cooperate, 0 to defect, and if any other number is entered, we will assume defection");
            Console.WriteLine("Your Score  Opponent Score    Rounds");
            while (rounds <= 100) {
                //Need to fix this to handle the error when the user provides the empty string
                int playerMove = Convert.ToInt32(Console.ReadLine());
                Types.Move move;
                if (playerMove == 1) {
                    move = Types.Move.Cooperate;
                } else {
                    move = Types.Move.Defect;
                }
                Types.Move opponentMove = opponentStrategy.GetMove(move);
                if (opponentMove == Types.Move.Cooperate && move == Types.Move.Cooperate) {
                    player1Score += 3;
                    player2Score += 3;
                } else if (opponentMove == Types.Move.Defect && move == Types.Move.Defect) {
                    player1Score += 1;
                    player2Score += 1;
                } else if (opponentMove == Types.Move.Defect && move == Types.Move.Cooperate) {
                    player2Score += 5;
                } else {
                    player1Score += 5;
                }
                Console.WriteLine(player1Score + " " + player2Score + " " + rounds);
                rounds++;
            }
        }
    }
}
