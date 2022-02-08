using System;
using System.Collections.Generic;

namespace unit03_jumper.Game
{
    public class TerminalService
    {

        public TerminalService()
        {
        }

        public int ReadNumber(string prompt)
        {
            string rawValue = ReadText(prompt);
            return int.Parse(rawValue, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}