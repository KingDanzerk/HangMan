using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(50, 15);
            HangManLogic hangMan = new HangManLogic();
            GameState gameStatus = GameState.Continue;
            UI UserInterface = new UI();
            string input;
            ConsoleKeyInfo keyInput = default;

            while (gameStatus == GameState.Continue || keyInput == default || keyInput.Key == ConsoleKey.R)
            {
                UserInterface.DisplayScreen(hangMan.WrongLetters, hangMan.Trys, hangMan.GuessedLetters, gameStatus, hangMan.CurrentWord);
                input = UserInterface.ReceiveInput();
                hangMan.MakeGuess(input);
                gameStatus = hangMan.CheckWin();

                if (gameStatus != GameState.Continue)
                {
                    UserInterface.DisplayScreen(hangMan.WrongLetters, hangMan.Trys, hangMan.GuessedLetters, gameStatus, hangMan.CurrentWord);
                    Thread.Sleep(2000);
                    UserInterface.ReplayScreen();
                    keyInput = Console.ReadKey();
                    
                    while (keyInput.Key != ConsoleKey.R && keyInput.Key != ConsoleKey.Enter)
                    {
                        Console.Clear();
                        UserInterface.ReplayScreen();
                        keyInput = Console.ReadKey();
                    }
                    
                    if (keyInput.Key == ConsoleKey.R)
                    {
                        hangMan.ResetGame();
                        gameStatus = GameState.Continue;
                        Console.Clear();
                    }

                    if (keyInput.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            
            UserInterface.ReplayScreenIfEnter();
            Console.ReadLine();
        }
    }
}
