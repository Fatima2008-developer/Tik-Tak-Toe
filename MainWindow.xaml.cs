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

namespace Tik_Tak_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isPlayerX = true;

        private int xWins = 0, oWins = 0, ties = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

      
        private void Btn01_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Content == null)
            {
                btn.Content = isPlayerX ? "X" : "o";
                isPlayerX = !isPlayerX;

                lblTurn.Text = "Current Turn: " + (isPlayerX ? "X" : "o");

                Checkwinner();

            }
        }
        private void Checkwinner()
        {
            string[,] board = new string[3, 3]
            {
                {
                    Btn00.Content?.ToString(),
                    Btn01.Content?.ToString(),
                    Btn02.Content?.ToString()
                },


              {
                    Btn10.Content?.ToString(),
                    Btn11.Content?.ToString(),
                    Btn12.Content?.ToString()
                },

            {
                    Btn20.Content?.ToString(),
                    Btn21.Content?.ToString(),
                    Btn22.Content?.ToString()
            },



            };

            for (int i = 0; i < 3; i++)
            {

                if (!string.IsNullOrEmpty(board[i, 0]) && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    DeclareWinner(board[i, 0]);
                    return;
                }


                if (!string.IsNullOrEmpty(board[0, i]) && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    DeclareWinner(board[0, i]);
                    return;
                }

                if (!string.IsNullOrEmpty(board[0, 0]) && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 0])
                {
                    DeclareWinner(board[0, 0]);
                    return;
                }

                if (!string.IsNullOrEmpty(board[0, 2]) && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                {
                    DeclareWinner(board[0, 2]);
                    return;
                }

                bool tie = true;
                foreach (Button b in new Button[] { Btn00, Btn01, Btn02, Btn10, Btn11, Btn12, Btn20, Btn21, Btn22 })
                {
                    if (b.Content == null) tie = false;
                }
                if (tie)
                {
                    ties++;
                    MessageBox.Show("it's a tie!");
                    UpdateScoreboard();
                    ResetBoard();


                }
            }
        }
            private void DeclareWinner(string player)
            {
            if (player == "X")
                xWins++;
            else oWins++;

            MessageBox.Show($"{player} Wins!");
            UpdateScoreboard();
            ResetBoard();


            }


        private void themetoggle_Unchecked(RoutedEventArgs e)
        {

        }

        private void themetoggle_Checked(object sender, RoutedEventArgs e)
        {

Apptheme.Changetheme(new Uri("/Dictionary2.xaml",UriKind.Relative));

        }

        private void themetoggle_Unchecked_1(object sender, RoutedEventArgs e)
        {

            Apptheme.Changetheme(new Uri("/Dictionary1.xaml", UriKind.Relative));

        }

        private void ResetBoard()
        {
            foreach (Button b in new Button[] { Btn00, Btn01, Btn02, Btn10, Btn11, Btn12, Btn20, Btn21, Btn22 })
            {
                b.Content = null;
            }
            isPlayerX = true;
            lblTurn.Text = "Current turn:X";
        }

        private void UpdateScoreboard()
        {
            lblScore.Text = $"X Wins:{xWins} o Wins: {oWins} Ties: {ties}";
        }
    }  
    
}