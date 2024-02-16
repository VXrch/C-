using System.Text;

namespace _24._02._02_Coursework
{
    [Serializable]
    class Game
    {
        public enum Difficulties { Easy, Normal, Medium, Difficult, Impossible }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Game() 
        { 
            subject = new Subject(); 
            Questions = new List<Question>(); 
            Stats = new Statistic(); 
            Difficultie = Difficulties.Easy; 
            identString = GenerateIdentString(); 
        }
        public Game(Subject subj) : this()
        {
            subject = subj;
        }
        public Game (Subject subj, List<Question> questions, Statistic stats, Difficulties difficultie, string identstring)
        { 
            subject = subj; 
            Questions = questions; 
            Stats = stats; 
            Difficultie = difficultie; 
            identString = identstring; 
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Subject subject { get; set; }

        public List<Question> Questions { get; set; }

        public Statistic Stats { get; set; }

        public Difficulties Difficultie { get; set; }

        public readonly string identString;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static public Difficulties ChooseDifficultie()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Choose difficultie: ");

                foreach (int i in Enum.GetValues(typeof(Difficulties)))
                {
                    Console.WriteLine($"[{i}] : {Enum.GetName(typeof(Difficulties), i)}");
                }

                while (true)
                {
                    string userInput = Console.ReadLine();

                    if (Enum.TryParse<Difficulties>(userInput, out var chosenDifficulty))
                    {
                        return chosenDifficulty;
                    }
                    else { Console.WriteLine("Invalid input. Please enter a number corresponding to the difficulty!"); }
                }
            }
            catch (Exception ex) { Console.WriteLine("Exception! " + ex.Message); throw; }
        }

        string GenerateIdentString()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 12; i++)
            {
                int index = random.Next(validChars.Length);
                sb.Append(validChars[index]);
            }

            return sb.ToString();
        }
        public bool IsMatchingGame(Game newGame)
        {
            return subject == newGame.subject && Difficultie == newGame.Difficultie;
        }

        public override string ToString()
        {
            return $"Subject: {subject} | Difficultie: {Difficultie} | Total Games: {Stats.Games} | Of those, they won: {Stats.Wins}";
        }
    }
}
