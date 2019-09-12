namespace SeaBattle
{
    interface IGame
    {
        string AnswerToMiniGame();

        void AlignmentOfTheShips();

        bool ComplementTheDeck(int length);

        void NullCoordinate(int CountDeck);

        string MakeShot(out int numberCoordinateShot, out int time);

        bool CheckTheShips(string coordinate, out int resultGameOfThisShot);
    }
}