using SQLite;

namespace SeaBattle
{
    class User
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [MaxLength(19), NotNull, Unique]
        public string Login { get; set; }

        [MaxLength(19), NotNull]
        public string Password { get; set; }

        [MaxLength(12), NotNull]
        public string Nickname { get; set; }

        [NotNull]
        public string Rank { get; set; }

        public long NumberOfGames { get; set; }

        public long NumberOfWins { get; set; }

        public int PercentWins { get; set; }

        public long NumberDefeatsConsecutive { get; set; }
    }
}