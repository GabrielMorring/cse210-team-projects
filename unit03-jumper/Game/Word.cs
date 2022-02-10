using System;
using System.Collections.Generic;

namespace unit03_jumper.Game
{
    
    public class Word
    {

        public Word()
        {
            //create array of words
            string[] _word = {"tacos", "car", "apple", "train", "friend", "house", "marshmallow", "colors"};
            

            Random _randWord = new Random();


            int index = _randWord.Next(_word.Length);

            var _displayWord = _word[index];

            return;

        }

     

    }
}