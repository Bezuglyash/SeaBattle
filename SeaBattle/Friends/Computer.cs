using System;
using System.Collections.Generic;

namespace SeaBattle
{
    class Computer : IGame
    {
        private List<string> ComputerMap = new List<string>
        { "А1", "А2", "А3", "А4", "А5", "А6", "А7", "А8", "А9", "А10",
          "Б1", "Б2", "Б3", "Б4", "Б5", "Б6", "Б7", "Б8", "Б9", "Б10",};
        public Computer()
        {
        }
        public void alignment_of_the_ships()
        {
            throw new NotImplementedException();
        }
    }
}
