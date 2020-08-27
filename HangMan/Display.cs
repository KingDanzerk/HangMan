using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HangMan
{
    
    class UI
    {
        /// <summary>
        /// Receives input from a user
        /// </summary>
        /// <returns></returns>
        public string ReceiveInput()
        {
            string input;
            
            Console.SetCursorPosition(1, 1);
            input = Console.ReadLine();
            Console.Clear();

            return input;
        }
        /// <summary>
        /// Displays what was entered.
        /// </summary>
        /// <param name="input"></param>
        public void DisplayChoices(char[] input)
        {
            Console.SetCursorPosition(7, 5);
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($" {input[i]}");
            }

            Console.SetCursorPosition(7, 6);
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($" Θ");
            }
        }
        /// <summary>
        /// Displays a losing message
        /// </summary>
        public void LoseMessage()
        {
            Console.SetCursorPosition(9, 3);
            Console.Write("YOU LOSE!!!");
        }
        /// <summary>
        /// Displays a win message
        /// </summary>
        public void WinMessage()
        {
            Console.SetCursorPosition(9, 3);
            Console.Write("YOU WIN!!!");
        }
        /// <summary>
        /// Displays all displays
        /// </summary>
        /// <param name="wrongChoices"></param>
        /// <param name="Trys"></param>
        /// <param name="wordDisplay"></param>
        /// <param name="gameStatus"></param>
        /// <param name="currentWord"></param>
        public void DisplayScreen(List<string> wrongChoices, int Trys, char[] wordDisplay, GameState gameStatus, string currentWord)
        {
            DisplayWrongChoices(wrongChoices);
            DisplayChoices(wordDisplay);
            DisplayGuesses();
            DisplayHangyMan(Trys);

            if (gameStatus == GameState.Lose)
            {
                DisplayWrongChoices(wrongChoices);
                DisplayChoices(wordDisplay);
                DisplayGuesses();
                DisplayHangyMan(Trys);
                DisplayWord(currentWord);
                LoseMessage();
            }

            if (gameStatus == GameState.Win)
            {
                DisplayWrongChoices(wrongChoices);
                DisplayChoices(wordDisplay);
                DisplayGuesses();
                DisplayHangyMan(Trys);
                DisplayWord(currentWord);
                WinMessage();
            }
        }
        /// <summary>
        /// Displays the current word
        /// </summary>
        /// <param name="currentWord"></param>
        public void DisplayWord(string currentWord)
        {
            Console.SetCursorPosition(7, 5);

            for (int i = 0; i < currentWord.Length; i++)
            {
                Console.Write($" {currentWord[i]}");
            }
        }
        /// <summary>
        /// Displays the wrong choices
        /// </summary>
        /// <param name="input"></param>
        public void DisplayWrongChoices(List<string> input)
        {
            
            Console.SetCursorPosition(7, 10);

            if (input.Count == 1)
            {
                Console.Write($"[{input[0]}");
            }

            if (input.Count > 1)
            {
                
                Console.Write($"[{input[0]}");

                for (int i = 1; i < input.Count - 1; i++)
                {
                    Console.Write($", {input[i]}");
                }

                Console.Write($", {input[input.Count - 1]}]");

            }
        }
        /// <summary>
        /// Displays the title for Wrong Letters
        /// </summary>
        public void DisplayGuesses()
        {
            Console.SetCursorPosition(7, 9);
            Console.Write(" Wrong Letters: ");
        }
        /// <summary>
        /// Displays the hangman
        /// </summary>
        /// <param name="trys"></param>
        public void DisplayHangyMan(int trys)
        {
            string[] lines = Ascii.Renders[trys].Split('\n');

            for (int i = 0, e = 1; i < lines.Length; i++, e++)
            {
                Console.SetCursorPosition(32, e);
                Console.WriteLine(lines[i]);
            }
        }
        /// <summary>
        /// Displays restart display.
        /// </summary>
        public void ReplayScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(5, 5);
            Console.Write("Press R to restart!, press ENTER to end!");
        }

    }
}
