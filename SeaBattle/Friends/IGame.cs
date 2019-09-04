namespace SeaBattle
{
    interface IGame
    {
        void AlignmentOfTheShips();

        bool ComplementTheDeck(int length);

        void NullCoordinate(int CountDeck);

        string MakeShot(out int numberCoordinateShot);

        bool CheckTheShips(string coordinate, out int resultGameOfThisShot);
    }
}