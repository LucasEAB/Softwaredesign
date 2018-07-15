using System;
using System.Data;
using System.Collections.Generic;

namespace TextAdventure_SWD
{
   public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.BuildGame();
            game.Play();
        }
    }
}
