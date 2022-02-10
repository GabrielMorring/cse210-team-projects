using System;
using System.Collections.Generic;

namespace unit03_jumper.Game
{
    public class Jumper
    {

        int parachuteLives;

        public Jumper()
        {
            parachuteLives = 4;
        }

        public bool CheckAlive()
        {
            if (parachuteLives == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public void UpdateLives()
        {
            parachuteLives -= 1;
        }

        public int GetParachuteLives()
        {
            return parachuteLives;
        }
        
    }
}