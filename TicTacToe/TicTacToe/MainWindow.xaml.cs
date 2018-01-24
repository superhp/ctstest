using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }                  

        private Player _player = Player.O; // false - x, true - 0
        private int[,] _matrix = new int[,] { 
            { 0, 0, 0 }, 
            { 0, 0, 0 }, 
            { 0, 0, 0 }
        };

        private Player? DetermineWinner()
        {
            return null;
        }

        private void buttonClicked(object sender, RoutedEventArgs e)
        {
            string coordinates = ((Button)sender).Tag.ToString();
            int x = int.Parse(coordinates[0].ToString()) - 1;
            int y = int.Parse(coordinates[1].ToString()) - 1;

            if (_matrix[x, y] == 0)
            {
                _matrix[x, y] = (int)_player;

                Player? winner = DetermineWinner();
                if (winner != null)
                {
                    winnerLabel.Content = winner == Player.X ? "X" : "O" + " has won!"; 
                }

                ((Button)sender).Content = _player == Player.O ? "0" : "X";
                ((Button)sender).Foreground = _player == Player.O ? Brushes.Blue : Brushes.Red;

                _player = _player == Player.O ? Player.X : Player.O;
            }
        }
    }
}
