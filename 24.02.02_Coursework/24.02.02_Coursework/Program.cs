using System.Net.NetworkInformation;

namespace _24._02._02_Coursework
{
    internal class Program
    {
        public delegate bool MenuDelegate();

        class Statistic
        {
            public Statistic() { Games = 0; Wins = 0; Looses = 0; }
            public Statistic(int games, int wins, int losses) { Games = games; Wins = wins; Looses = losses; }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            int _games;
            public int Games
            {
                get { return _games; }
                set { if (value >= 0) _games = value; else throw new ArgumentOutOfRangeException(); }
            }

            int _wins;
            public int Wins
            {
                get { return _wins; }
                set { if (value >= 0) _wins = value; else throw new ArgumentOutOfRangeException(); }
            }

            int _losses;
            public int Looses
            {
                get { return _losses; }
                set { if (value >= 0) _losses = value; else throw new ArgumentOutOfRangeException(); }
            }
        }
        class User
        {
            public User() { Name = "Guest"; Stats = new Statistic(); }
            public User(string name) { Name = name; Stats = new Statistic(); }
            public User(string name, Statistic stats) { Name = name; Stats = stats; }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string _name;
            public string Name 
            { 
                get { return _name; } 
                set { if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(); } else _name = value; } 
            }

            public Statistic Stats { get; set; }
        }
        class Game
        {
            public enum Difficulties { Easy, Normal, Medium, Difficult, Impossible }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public Game() { Question = new List<string>(); MaxTimeForOneQuestion = 240; Stats = new Statistic(); Difficultie = Difficulties.Easy; }
            public Game(List<string> questions, Statistic stats, Difficulties difficultie, int maxTimeForOneQuestion) 
            { Question = questions; Stats = stats; Difficultie = difficultie; MaxTimeForOneQuestion = maxTimeForOneQuestion; }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public List<string> Question { get; set; }

            public Statistic Stats { get; set; }

            public Difficulties Difficultie { get; set; }

            int _maxTimeForOneQuestion;
            public int MaxTimeForOneQuestion
            {
                get { return _maxTimeForOneQuestion; }
                set { if (value >= 30) _maxTimeForOneQuestion = value; else throw new ArgumentOutOfRangeException(); }
            }
        }

        class Menu
        {
            bool LogIn()
            {
                return false;
            }
            bool Register()
            {
                return false;
            }
            void Start()
            {
                // Hello
                // Menu = Exit / Log in / Register / Enter as a guest
                // Input
                // 
                // If (result = true)
                // MainMenu();

                Console.WriteLine("|=|=|=|   CALCULATE MENU   |=|=|=|");
                Console.WriteLine("[0] - Exit");
                Console.WriteLine("[1] - Log in");
                Console.WriteLine("[2] - Register");
                Console.WriteLine("[3] - Enter as a guest");
                Console.WriteLine();

                Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());

                MenuDelegate[] md = new MenuDelegate[] { delegate() { return true; }, LogIn, Register};
                md[res]?.Invoke();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {





        }
    }    
}