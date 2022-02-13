using System;
using System.Collections.Generic;

namespace unit03_jumper.Game
{

    public class Director
    {
        Word word = new Word();
        TerminalService terminal = new TerminalService();
        Jumper jumper = new Jumper();
        private bool _isPlaying;
        private string _secretWord;
        private string _userGuesses;
        private string _currentGuess;
        private string _printableWord;
        public Director()
        {
            _isPlaying = true;
            _secretWord = word.GetRandomWord();
            _userGuesses = "";
            
            for (int i = 0; i < _secretWord.Length; i++)
            {
                _userGuesses += "_";
            }
            _printableWord = _userGuesses;
        }

        public void StartGame()
        {
            PrintUserGuesses();
            PrintJumper();

            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        private void GetInputs()
        {
            _currentGuess = terminal.GetInput("Guess a letter [a-z]: ");
        }

        private void DoUpdates()
        {
            
            if (_secretWord.Contains(_currentGuess))
            {
                _printableWord = "";
                for (int i = 0; i < _secretWord.Length; i++)
                {
                    if(_secretWord[i] == _currentGuess[0])
                    {
                        _printableWord += _currentGuess;
                    }
                    else
                    {
                        _printableWord += _userGuesses[i];
                    }
                }
                _userGuesses  = _printableWord;
            }
            else 
            {
                jumper.UpdateLives();
            }
        }

        private void DoOutputs()
        {
            PrintUserGuesses();
            PrintJumper();
            _isPlaying = jumper.CheckAlive();
            if (_printableWord == _secretWord)
            {
                _isPlaying = false;
            }
        }

        private void PrintUserGuesses()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < _printableWord.Length; i++)
            {
                Console.Write($"{_printableWord[i]} ");
            }
            Console.WriteLine("\n");
        }

        private void PrintJumper()
        {
            PrintParachute();
            bool isAlive = jumper.CheckAlive();
            if (isAlive)
            {
                Console.WriteLine("   o");
            }
            else 
            {
                Console.WriteLine("   x");
            }
            Console.WriteLine("  /|\\");
            Console.WriteLine("  / \\\n");
            Console.WriteLine("^^^^^^^\n");
        }

        private void PrintParachute()
        {
            int lives = jumper.GetParachuteLives();
            if (lives == 4)
            {
                Console.WriteLine("  ___");
                Console.WriteLine(" /   \\");
                Console.WriteLine(" \\   /");
                Console.WriteLine("  \\ /");
            }
            else if (lives == 3)
            {
                Console.WriteLine(" /   \\");
                Console.WriteLine(" \\   /");
                Console.WriteLine("  \\ /");
            }
            else if (lives == 2)
            {
                Console.WriteLine(" \\   /");
                Console.WriteLine("  \\ /");
            }
            else if (lives == 1)
            {
                Console.WriteLine("  \\ /");
            }
        }
        
    }

}