using System;
using System.Collections.Generic;

namespace unit03_jumper.Game
{
    public class TerminalService
    {

        public TerminalService()
        {
        }

        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }
    }
}