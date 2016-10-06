using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Blackjack
    {
        User Player;
        Players dealer;
        int[] results;


        public Blackjack()
        {
            Player = new User();
            dealer = new Players();
            results = new int[2];
            initGame();
            playGame();

        }

        public void initGame()
        {
            resetGame();
            Player.Chips = 1000;
        }

        public void playGame()
        {
            String answer = "";
            Console.WriteLine("Welcome to blackjack V 0.0.1");
            
            while(true){
                bool bet;
                do{
                Console.Write("We will start by taking your bet, you only have " + Player.Chips + " chips:");
                answer = Console.ReadLine();
                bet = Player.Bet(Convert.ToInt16(answer));
                if (!bet)
                {
                    Console.WriteLine("Try again!");
                }
                }while(!bet);

                Console.WriteLine("Okey lets find you some cards");
                Player.newHand();

                do
                {
                    Console.WriteLine(Player.toString());
                    Console.WriteLine("You have a combined score of " + Player.checkValue());
                    Console.WriteLine("There you go. Did you like your cards? Do you want another one? (y/n)");
                    answer = Console.ReadLine();
                
                    if (answer == "y")
                    {
                        Player.Hit();
                    }
                } while (answer == "y");

                results[0] = Player.checkValue();
                dealer.newHand();
                while (dealer.checkValue() < 15)
                {
                    dealer.Hit();
                }
                results[1] = dealer.checkValue();
                compareResults();
                Console.WriteLine("do you want to continou playing(y/n)");
                answer = Console.ReadLine();
                if (answer == "n")
                    break;

                resetGame();
            }
        }

        public void compareResults()
        {
            Console.WriteLine(dealer.toString());
            Player.Result(results[0] > results[1] && results[0] <= 21);
        }

        public void resetGame()
        {
            Deck.Instance.setDeck();
            Player.Hand = null;
            dealer.Hand = null;
        }

    }
}
