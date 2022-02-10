using System;
using System.Collections.Generic;

namespace unit03_jumper.Game
{
    
    public class Word
    {

        List<string> _word;

        public Word()
        {
            //create array of words
            _word = new List<string>{"tacos", "car", "apple", "train", "friend", "house", "marshmallow", "colors"};
            

            

       

        }
        public string GetRandomWord()
                {
                    Random _randWord = new Random();
                    int index = _randWord.Next(_word.Count);
                    var _displayWord = _word[index];
                
                    return _displayWord;
                }
                
     

    }
}