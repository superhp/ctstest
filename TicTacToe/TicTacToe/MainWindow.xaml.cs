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

        private void buttonClicked(object sender, RoutedEventArgs e)
        {
            string coordinates = ((Button)sender).Tag.ToString();
            int x = int.Parse(coordinates[0].ToString());
            int y = int.Parse(coordinates[1].ToString());

            _player = _player == Player.O ? Player.X : Player.O;

            ((Button)sender).Content = _player == Player.O ? "0" : "X";
            ((Button)sender).Foreground = _player == Player.O ? Brushes.Blue : Brushes.Red; 
        }
    }
}
