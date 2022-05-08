using System;

namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerRandomNum;
            int enemyRandomNum;

            int playerPoints = 0;
            int enemyoints = 0;

            Random random = new Random();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Press any key to roll the dice.");

                Console.ReadKey();

                playerRandomNum = random.Next(1, 7);
                Console.WriteLine("You rolled a " + playerRandomNum);

                Console.WriteLine("...");
                System.Threading.Thread.Sleep(1000);

                enemyRandomNum = random.Next(1, 7); 
                Console.WriteLine("Enemy AI rolled a " + enemyRandomNum);

                if(playerRandomNum > enemyRandomNum)
                {
                    playerPoints++;
                    Console.WriteLine("Player wins this rounds!");
                }
                else if(playerRandomNum < enemyRandomNum)
                {
                    enemyRandomNum++;
                    Console.WriteLine("Enemy wins this round!");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
                Console.WriteLine("The score is now - Player : " + playerRandomNum + ". Enemy : " + enemyRandomNum + ".");
                Console.WriteLine();
            }
            if(playerPoints > enemyoints)
            {
                Console.WriteLine("You win!");
            }
            else if(enemyoints > playerPoints)
            {
                Console.WriteLine("You lose!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
            Console.ReadKey();
        }
    }
}
