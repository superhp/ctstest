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

        private List<char> _guessedLetters;
        private string _secretWord;
        private int _triesLeft;
        private bool _gameEnded;

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            var words = File.ReadAllLines("words.txt");

            var random = new Random();
            var randomIndex = random.Next(0, words.Length - 1);
            _secretWord = words[randomIndex];

            _triesLeft = Properties.Settings.Default.TriesLeft;
            _guessedLetters = new List<char>();
            _gameEnded = false;

            secretWordLbl.Content = MaskWord(_secretWord, _guessedLetters);

            ChangeImage();
        }

        private string MaskWord(string secretWord, List<char> letters)
        {
            var maskedWord = "";
            foreach (var letter in secretWord)
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

            if (_gameEnded)
            {
                return;
            }

            var letter = e.Key.ToString().ToLower()[0];
            var correctLetter = _secretWord.Contains(letter);

            if (correctLetter && !_guessedLetters.Contains(letter))
            {
                _guessedLetters.Add(letter);

                var maskedWord = MaskWord(_secretWord, _guessedLetters);
                secretWordLbl.Content = maskedWord;
                if (maskedWord.Replace(" ", "") == _secretWord)
                {
                    winLooselbl.Content = "You Won!";
                    _gameEnded = true;
                    SystemSounds.Exclamation.Play();
                }
            }
            if (!correctLetter)
            {
                _triesLeft = _triesLeft - 1;
                tryCountLbl.Content = _triesLeft;

                if (_triesLeft == 0)
                {
                    winLooselbl.Content = "You lost...";
                    _gameEnded = true;
                    SystemSounds.Question.Play();
                }
            }

            ChangeImage();
        }

        private void ChangeImage()
        {
            var bi = new BitmapImage(new Uri("images/" + _triesLeft + ".png", UriKind.Relative));
            picture.Source = bi;
        }
    }
}
