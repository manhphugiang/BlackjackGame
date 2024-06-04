using BlackjackStarter.Blackjack;
using BlackJackStarter.BlackJack;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BlackJackStarter
{
 
    public partial class MainWindow : Window
    {
        string path = "C:/Users/gmanh/SHERIDAN_COLLEGE/Semester 4/PROG 32356 - C#/Code/BlackjackStarter/BlackjackStarter/JPEG/";
        Random random = new Random();

        BlackjackEngine game; 


        public MainWindow()
        {


            game =  new BlackjackEngine(random);
            InitializeComponent();
            game.Init();

            game.DealToPlayer();
            game.DealToPlayer();
            RefreshScreen();


        }



        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            game = new BlackjackEngine(random);
            game.Init();
            game.DealToPlayer();
            game.DealToPlayer();
            RefreshScreen();
            DealerPanel.Children.Clear();
        }



        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            
                if (game.Deck.Count > 0)
                {
                    game.DealToPlayer();
                    RefreshScreen();

                    if (game.IsPlayerBusted())
                    {
                    game.DealerTurn();

                    RefreshScreen();
                    ShowDealerCards();
                    MessageBox.Show("Player Busted. Dealer won!");
                    }

                }
                else
                {
                    MessageBox.Show("The deck is empty. Cannot draw more cards.");
                }
            
        }



        public void RefreshScreen()
        {
            PlayerPanel.Children.Clear();
            foreach(Card c in game.PlayerHand) {
                ShowCard(path + c.GetFileName());
            }
        }

        private void ShowCard(string filename)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(filename));
            Image image = new Image();
            image.Source = bitmap;
            PlayerPanel.Children.Add(image);
        }



        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            if (!game.IsPlayerBusted())
            {
                game.DealerTurn();

                int playerTotal = game.CalculateHandValue(game.PlayerHand);
                int dealerTotal = game.CalculateHandValue(game.DealerHand);

                if (game.CalculateHandValue(game.DealerHand) > 21)
                {
                    MessageBox.Show("Dealer Busted. Player won!");
                }
                else if (playerTotal > dealerTotal)
                {
                    MessageBox.Show("Player won!");
                }
                else if (playerTotal < dealerTotal)
                {
                    MessageBox.Show("Dealer won!");
                }
                else
                {
                    MessageBox.Show("It's a tie!");
                }

                RefreshScreen();
                ShowDealerCards();
            }

            else
            {
                ShowDealerCards();
                RefreshScreen();
                MessageBox.Show("Player Busted. Dealer won!");
             

            }
        }

   

        private void ShowDealerCards()
        {
            DealerPanel.Children.Clear();
            foreach (Card c in game.DealerHand)
            {
                ShowCard(path + c.GetFileName(), DealerPanel);
            }
        }

        private void ShowCard(string filename, WrapPanel panel)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(filename));
            Image image = new Image();
            image.Source = bitmap;
            panel.Children.Add(image);
        }







    }
}