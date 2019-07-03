namespace SeaBattle
{
    class DataUser
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Rank { get; set; }
        public long? NumberOfGames { get; set; }
        public long? NumberOfWins { get; set; }
        public double? PercentWins { get; set; }
        public int UserId { get; set; }
        public virtual User Users { get; set; }
    }
}