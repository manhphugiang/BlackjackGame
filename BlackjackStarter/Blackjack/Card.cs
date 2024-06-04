//using System;
//using System.Collections.Generic;
//using System.IO.Pipes;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media.Imaging;

//namespace BlackjackStarter.Blackjack
//{
//    public class Card
//    {
//        public int Rank; 
//        public string Suit;

//        public Card(int rank, string suit)
//        {
//            Rank = rank;
//            Suit = suit;
//        }

//        public int GetBlackjackValue()
//        {
//            // For blackjack, face cards are worth 10, Aces are worth 1 or 11
//            if (Rank >= 10) return 10; // Jack, Queen, King
//            if (Rank == 0) return 11;  // Ace
//            return Rank + 1;           // 2 through 10
//        }

//        public string GetImageFilename()
//        {
//            string rankString;
//            if (Rank == 1)
//                rankString = "A";
//            else if (Rank == 11)
//                rankString = "J";
//            else if (Rank == 12)
//                rankString = "Q";
//            else if (Rank == 13)
//                rankString = "K";
//            else
//                rankString = Rank.ToString();

//            string suitString;
//            if (Suit == "hearts")
//                suitString = "H";
//            else if (Suit == "diamonds")
//                suitString = "D";
//            else if (Suit == "spades")
//                suitString = "S";
//            else if (Suit == "clubs")
//                suitString = "C";
//            else
//                suitString = Suit; // In case the suit is not recognized, use the original suit string

//            return rankString + suitString + ".jpg";
//        }





//    }
//}











using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlackJackStarter.BlackJack
{
    internal class Card
    {
        public int Rank;
        public string Suit;

        public Card(int rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int GetBlackjackValue() //get the Rank value only actually!!!!
        {
            // 2-10 have their face value (number value);
            // But J, Q, K are worth 10
            // and A is worth 11 or 1

            if (Rank >= 2 && Rank <= 10)
                return Rank;
            else if (Rank >= 11 && Rank <= 13)
                return 10;
            else if (Rank == 1)
                return 11; // Ace
            else
                return 0; // Should never happen
        }


            public string GetFileName()
            {
                string rankText = Rank.ToString();
                if (Rank == 1) rankText = "A";
                if (Rank == 11) rankText = "J";
                if (Rank == 12) rankText = "Q";
                if (Rank == 13) rankText = "K";

                return rankText + Suit + ".jpg";
            }
        }
    }










