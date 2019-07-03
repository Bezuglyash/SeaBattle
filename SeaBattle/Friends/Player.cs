using System;

namespace SeaBattle
{
    class Player : GameSpace, IGame
    {
        private string Rank;
        private long? NumberGames;
        private long? NumberWins;
        private double? PercentOfWins;
        private GameLogic logic = new GameLogic();

        public Player()
        {
            Rank = logic.GetRank();
            NumberGames = logic.GetNumberGames();
            NumberWins = logic.GetNumberWins();
            PercentOfWins = logic.GetPercentOfWins();
        }
        public void alignment_of_the_ships()
        {
            throw new NotImplementedException();
        }
    }
}
