using BlackJackStarter.BlackJack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlackjackStarter.Blackjack
{
    internal class BlackjackEngine
    {
        public List<Card> Deck = new List<Card>();
        public List<Card> PlayerHand = new List<Card>();
        public List<Card> DealerHand = new List<Card>();

        private Random random;

        public BlackjackEngine(Random random)
        {
            this.random = random;
        }

        public void Init()
        { 
            string[] suits = { "D", "C", "H", "S" };

            foreach (string suit in suits)
            {
                for (int rank = 1; rank <= 13; rank++) 
                {
                    Deck.Add(new Card(rank, suit));
                }
            }

        }


        public void DealerTurn()
        {
            while (CalculateHandValue(DealerHand) < 17)
            {
                int randomIndex = random.Next(Deck.Count);
                Card c = Deck[randomIndex];
                Deck.RemoveAt(randomIndex);
                DealerHand.Add(c);
            }
        }

        public int CalculateHandValue(List<Card> hand)
        {
            int sum = 0;
            int aces = 0;

            // Calculate the sum of all cards in the hand
            foreach (Card c in hand)
            {
                if (c.Rank >= 2 && c.Rank <= 10)
                {
                    sum += c.Rank; // Number cards (2-10)
                }
                else if (c.Rank >= 11 && c.Rank <= 13)
                {
                    sum += 10; // Face cards (Jack, Queen, King)
                }
                else if (c.Rank == 1)
                {
                    aces += 1; // Aces
                }
            }

            // Add the aces to the sum, considering their value as 1 or 11
            for (int i = 0; i < aces; i++)
            {
                if (sum + 11 <= 21)
                {
                    sum += 11; // If adding 11 doesn't bust, treat Ace as 11
                }
                else
                {
                    sum += 1; // Otherwise, treat Ace as 1
                }
            }

            return sum;
        }

        public void DealToPlayer()
        {

            int randomIndex = random.Next(Deck.Count);
            Card c = Deck[randomIndex];
            Deck.RemoveAt(randomIndex);
            PlayerHand.Add(c);


        }

        public bool IsPlayerBusted()
        {


            int sum = 0;
            int aces = 0;

            foreach (Card c in PlayerHand)
            {
                if (c.Rank >=2 &&  c.Rank <=10)
                {
                    sum+=c.Rank;
                }
                else if (c.Rank >=11  && c.Rank <= 13)
                {
                    sum +=10;
                }
                else if( c.Rank ==1)
                {
                    aces += 1;
                }
            }

            for (int i = 0; i < aces; i++)
            {
                if (sum + 11 <= 21)
                {
                    sum += 11; // If adding 11 doesn't bust, treat Ace as 11
                }
                else
                {
                    sum += 1; // Otherwise, treat Ace as 1
                }
            }


            return sum > 21;

        }

    }
}