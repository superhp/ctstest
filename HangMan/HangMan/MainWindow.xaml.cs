using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

        private List<char> guessedLetters;
        private string secretWord;
        private int triesLeft;
        private bool gameEnded; 

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] words = File.ReadAllLines("words.txt");

            Random random = new Random();
            int randomIndex = random.Next(0, words.Length - 1);
            secretWord = words[randomIndex];

            triesLeft = 6;
            guessedLetters = new List<char>(); 
            gameEnded = false; 

            secretWordLbl.Content = MaskWord(secretWord, guessedLetters);

            ChangeImage(); 
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

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            SystemSounds.Asterisk.Play(); 

            if (gameEnded)
            {
                return; 
            }

            char letter = e.Key.ToString().ToLower()[0];
            bool correctLetter = secretWord.Contains(letter);

            if (correctLetter && !guessedLetters.Contains(letter))
            {
                guessedLetters.Add(letter);

                string maskedWord = MaskWord(secretWord, guessedLetters);
                secretWordLbl.Content = maskedWord; 
                if (maskedWord.Replace(" ", "") == secretWord)
                {
                    winLooselbl.Content = "You Won!";
                    gameEnded = true;
                    SystemSounds.Exclamation.Play();
                }
            }
            if(!correctLetter)
            {
                triesLeft = triesLeft - 1;
                tryCountLbl.Content = triesLeft;

                if (triesLeft == 0)
                {
                    winLooselbl.Content = "You lost...";
                    gameEnded = true;
                    SystemSounds.Question.Play(); 
                }
            }

            ChangeImage(); 
        }

        private void ChangeImage()
        {
            BitmapImage bi = new BitmapImage(new Uri("images/" + triesLeft + ".png", UriKind.Relative));
            picture.Source = bi; 
        }
    }
}
