using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangMan
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

        private List<char> guessedLetters = new List<char>(); 

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] words = File.ReadAllLines("words.txt");

            Random random = new Random();
            int randomIndex = random.Next(0, words.Length - 1); 
            string secretWord = words[randomIndex];

            secretWordLbl.Content = MaskWord(secretWord, guessedLetters); 
        }

        private string MaskWord(string secretWord, List<char> letters)
        {
            string maskedWord = "";
            foreach (char letter in secretWord)
            {
                if (letters.Contains(letter)) 
                {
                    maskedWord = maskedWord + letter + " ";
                }
                else
                {
                    maskedWord = maskedWord + "*" + " "; 
                }
            }
            return maskedWord; 
        }

    }
}
