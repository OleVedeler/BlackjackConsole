using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Players
    {
        private List<int[]> hand;
        public List<int[]> Hand
        {
            set { hand = new List<int[]>(); }
            get { return hand; }
        }

        public void Hit()
        {
            int[] temp = new int[2];
            temp = Deck.Instance.newCard();
            hand.Add(temp);
            
        }

        public void newHand()
        {
            Hit();
            Hit();
        }

        public int checkValue()
        {
            int value = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                int[] temp = new int[2];

                temp = hand[i];
                value += temp[0];
            }

            return value;
        }


        public String toString()
        {
            String Return = "";
            int[] temp = new int[2];
            for (int i = 0; i < hand.Count; i++)
            {
                temp = hand[i];

                Return += temp[0] + " of ";

                if (temp[1] == 0)
                {
                    Return += "heart";
                }
                else if (temp[1] == 1)
                {
                    Return += "Spade";
                }
                else if (temp[1] == 2)
                {
                    Return += "Diamond";
                }
                else
                {
                    Return += "clover";
                }

                Return += "\n";

            }
            return Return;
        }

    }
}
