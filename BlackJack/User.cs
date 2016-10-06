using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class User : Players
    {
        public int Chips{ set; get; }
        private int bet;


        public Boolean Bet(int amount)
        {
            if (Chips < amount)
            {
                return false;
            }
            
            Chips -= amount;
            bet = amount*2;

            return true;
        }

        public void Result(Boolean win)
        {
            if (win)
            {
                Console.WriteLine("You Won!");
                Chips += bet;
            }
            else
            {
                Console.WriteLine("You Lose!");
            }

            bet = 0;
        }


    }
}
