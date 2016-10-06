using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Deck
    {
        static Deck _Instance;
        public static Deck Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Deck();

                return _Instance;
            }
        }


        private Boolean[] cardDeck;
        private Random Rand;


        public int[] newCard()
        {
            int[] card = new int[2];
            int randCard;
            do 
            {
                 randCard = Rand.Next(51);
            }while(!cardDeck[randCard]);
            
            card[0] = (randCard % 13) + 1;
            card[1] = randCard % 4;
            cardDeck[randCard] = false;

            //Temperary solution
            if (card[0] > 10)
            {
                card[0] = 10;
            }
            return card;
        }

        public void setDeck()
        {
            cardDeck = new Boolean[52];

            Rand = new Random();
            for (int i = 0; i < cardDeck.Length; i++)
            {
                cardDeck[i] = true;
            }
        }
    }
}
