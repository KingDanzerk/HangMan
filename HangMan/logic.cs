using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Reflection;

namespace HangMan
{
    public enum GameState
    {
        Continue,
        Win,
        Lose,
    }

    public class HangManLogic
    {
        private string[] words;
        private Random random = new Random();
        private int _trys;
        private string _currentWord;
        private int Wins;
        private char[] _guessedLetters;
        private List<string> _wrongLetters = new List<string>();

        /// <summary>
        /// Returns all the WrongLetters that were entered.
        /// </summary>
        public List<string> WrongLetters { get { return _wrongLetters; } }
        /// <summary>
        /// Returns the currentword
        /// </summary>
        public string CurrentWord { get { return _currentWord; } }
        /// <summary>
        /// Returns an array of the correct matches
        /// </summary>
        public char[] GuessedLetters { get { return _guessedLetters; } }
        /// <summary>
        /// Returns how many trys there was starting from 0
        /// </summary>
        public int Trys { get { return _trys; } }
        
        public HangManLogic()
        {
            _trys = 0;
            GenerateRandomWord();
            createInputArray(CurrentWord);
        }
        /// <summary>
        /// Generates a random word
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomWord()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("HangMan.words.txt");
            using StreamReader reader = new StreamReader(stream);
            List<string> list = new List<string>();

            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();
                list.Add(word);
            }

            words = list.ToArray();
            _currentWord = words[random.Next(words.Length)];
            return _currentWord;
        }
        /// <summary>
        /// Creates an array the size of the current word
        /// </summary>
        /// <param name="word"></param>
        public void createInputArray(string word)
        {
            _guessedLetters = new char[word.Length];
        }
        /// <summary>
        /// Checks for a match and adds matches to .GuessedLetters
        /// </summary>
        /// <param name="input"></param>
        public void MakeGuess(string input)
        {
            string currentWord = _currentWord.ToLower();
            string currentInput = input.ToLower();
            int counter = 0;

            if (currentInput.Length == currentWord.Length) //If the user inputs the whole word, then this will initiate.
            {
                for (int i = 0; i < currentWord.Length; i++)
                {
                    for (int e = 0; e < currentInput.Length; e++)
                    {
                        if (currentInput[e] == currentWord[i])
                        {
                            _guessedLetters[i] = currentInput[e];
                            counter += 1; //Using this counter to indicate if there was a match!
                        }
                    }
                }

                if (counter == 0)
                {
                    _trys += 1;
                    _wrongLetters.Add(currentInput);
                }
            }

            if (currentInput.Length == 1)
            {
                for (int i = 0; i < currentWord.Length; i++)
                {
                    if (currentInput[0] == currentWord[i])
                    {
                        _guessedLetters[i] = currentInput[0];
                        counter += 1;
                    }

                    
                }
                
                if (counter == 0)
                {
                    _trys += 1;
                    _wrongLetters.Add(currentInput);
                }
            }
        }
        /// <summary>
        /// Checks for a Win or Loss
        /// </summary>
        /// <returns></returns>
        public GameState CheckWin()
        {
            int indexCounter = 0;
            
            for (int i = 0; i < _guessedLetters.Length; i++)
            {
                if (_guessedLetters[i] != '\0')
                {
                    indexCounter += 1;

                    if (indexCounter == _guessedLetters.Length)
                    {
                        Wins += 1;
                        return GameState.Win;
                    }
                }
            }

            if (_trys == 6)
            {
                return GameState.Lose;
            }

            else
            {
                return GameState.Continue;
            }
        }
        /// <summary>
        /// Resets Game
        /// </summary>
        public void ResetGame()
        {
            _trys = 0;
            GenerateRandomWord();
            createInputArray(CurrentWord);
            _wrongLetters = new List<string>();
        }
    }
}
