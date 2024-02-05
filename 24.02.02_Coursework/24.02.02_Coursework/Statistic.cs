namespace _24._02._02_Coursework
{
    class Statistic
    {
        public Statistic() { Games = 0; Wins = 0; Loses = 0; }
        public Statistic(int Games, int wins, int losses) { Games = Games; Wins = wins; Loses = losses; }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        int _Games;
        public int Games
        {
            get { return _Games; }
            set { if (value >= 0) _Games = value; else throw new ArgumentOutOfRangeException(); }
        }

        int _wins;
        public int Wins
        {
            get { return _wins; }
            set { if (value >= 0) _wins = value; else throw new ArgumentOutOfRangeException(); }
        }

        int _losses;
        public int Loses
        {
            get { return _losses; }
            set { if (value >= 0) _losses = value; else throw new ArgumentOutOfRangeException(); }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine($"Games: {Games}");
            Console.WriteLine($"Wins: {Wins}");
            Console.WriteLine($"Loses: {Loses}");
            Console.WriteLine();
        }
    }
}
