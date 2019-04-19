using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Console
{
    class Program
    {
        public static int processWinLose(int playerpoint, int dealerpoint)
        {
            int res = 0;
            if ((dealerpoint > 21) && (playerpoint <= 21)) res = 1;
            if ((playerpoint > 21) && (dealerpoint <= 21)) res = 0;

            if ((playerpoint <= 21) && (dealerpoint <= 21) && (playerpoint > dealerpoint)) res = 1;
            if ((playerpoint <= 21) && (dealerpoint <= 21) && (playerpoint < dealerpoint)) res = 0;

            if (((dealerpoint > 21) && (playerpoint > 21)) || (playerpoint == dealerpoint)) res = -1;
            return res;
        }
        
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int bet = 0;
            int winMoney = 0;               
            do
            {
                System.Console.WriteLine("How much would you like to bet? ");
                string strbet = System.Console.ReadLine();
                bool tryParseRes = int.TryParse(strbet, out bet);
                if (tryParseRes)        // if TryParse successful
                {                   
                    int player1 = rnd.Next(1, 10);
                    int player2 = rnd.Next(1, 10);
                    int dealer1 = rnd.Next(1, 10);
                    int dealer2 = rnd.Next(1, 10);
                    int sumPlayer = player1 + player2;
                    int sumDealer = dealer1 + dealer2;

                    System.Console.WriteLine($"\t\t Your 2 cards are {player1} & {player2}, YOUR POINT is {sumPlayer} ");
                    System.Console.WriteLine($"\t\t Dealer's 2 cards are {dealer1} & {dealer2}, DEALER POINT is {sumDealer} \n");

      // If Player have more card
                    do
                    {
                        System.Console.WriteLine("Would you like another card? (type Yes or No) ");
                        string choose = System.Console.ReadLine();
                        if (choose.ToLower() == "yes")
                        {
                            int player3 = rnd.Next(1, 10);
                            sumPlayer += player3;
                            System.Console.WriteLine($"\t\tYour another card is {player3}, now YOUR POINT is {sumPlayer} ! \n");
                        }
                        else if (choose.ToLower() == "no") break;                       
                    } while (sumPlayer < 21);

      // If Dealer have more card
                    while (sumDealer <= 17)
                    {
                        System.Console.WriteLine("Dealer withdraw........................");
                        int dealer3 = rnd.Next(1, 10);
                        sumDealer += dealer3;
                        System.Threading.Thread.Sleep(300);
                        System.Console.WriteLine($"\t\t Dealer have another card, now DEALER POINT is {sumDealer}");
                        System.Threading.Thread.Sleep(300);
                    }

    // process Win & Lose
                    try
                    {
                        int result = processWinLose(sumPlayer, sumDealer);
                        // process result
                        if (result == 1)
                        {
                            winMoney += bet;
                            System.Console.WriteLine("\n CONRAT!! YOU WON!!!");
                            System.Console.WriteLine($"YOUR MONEY IS {winMoney}$. \n" +
                                $"Dealer's money is {0 - winMoney}$. \n");
                        }
                        else if (result == 0)
                        {
                            winMoney -= bet;
                            System.Console.WriteLine("\n YOU LOSE!!");
                            System.Console.WriteLine($"YOUR MONEY IS {winMoney}$. \n" +
                                $"DEALER MONEY IS {0 - winMoney}$.\n");
                        }
                        else if (result == -1)
                        {
                            System.Console.WriteLine($"\n DRAW!!! \n YOUR MONEY IS {winMoney}\n" +
                                $"Dealer's money is {0 - winMoney} \n");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("There is error while running the game. Press any key to exit");
                    }
    // Continue
                    System.Console.WriteLine("WANNA PLAY AGAIN!? (Type Yes or No) ");
                    string playAgain = System.Console.ReadLine();
                    if (playAgain.ToLower() == "yes") continue;
                    else if (playAgain.ToLower() == "no") break;
                    else break;
                }
     // If TryParse fail
                else {System.Console.WriteLine("What you have typed is not a numbebr, please try again!"); continue;}               
            }
            while (true);
        }
    }
}
