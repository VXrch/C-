using System.Text;

namespace _24._02._02_Coursework
{
    class Question
    {
        public string question { get; set; }
        public string Correct_answer { get; set; }

        public string Incorrect_answer_1 { get; set; }
        public string Incorrect_answer_2 { get; set; }
        public string Incorrect_answer_3 { get; set; }

        public Question() { question = Correct_answer = Incorrect_answer_1 = Incorrect_answer_2 = Incorrect_answer_3 = string.Empty; }
        public Question(string question, string correct_answer, string incorrect_answer_1, string incorrect_answer_2, string incorrect_answer_3)
        { this.question = question; Correct_answer = correct_answer; Incorrect_answer_1 = incorrect_answer_1; Incorrect_answer_2 = incorrect_answer_2; Incorrect_answer_3 = incorrect_answer_3; }

        public List<string> GetAnswers()
        {
            List<string> answers = new List<string> { Correct_answer, Incorrect_answer_1, Incorrect_answer_2, Incorrect_answer_3, };

            Random random = new Random();
            answers = answers.OrderBy(x => random.Next()).ToList();

            return answers;
        }
    }
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
            Console.WriteLine($"Games: {Loses}");
            Console.WriteLine();
        }
    }

    [Serializable]
    class User : IEquatable<User>
    {
        string _name;
        public string Name
        {
            get { return _name; }
            set { if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(); } else _name = value; }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { if (string.IsNullOrEmpty(value) || !Menu.IsCorrectPassword(value)) { throw new ArgumentNullException(); } else _password = value; }
        }

        public string identString { get; }

        public Statistic Stats { get; set; }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public User() { Name = "Guest"; Stats = new Statistic(); identString = GenerateIdentString(); }

        public User(string name) : this() { Name = name; }
        public User(string name, Statistic stats) { Name = name; Stats = stats; identString = GenerateIdentString(); }
        public User(string name, Statistic stats, string identificationString) { Name = name; Stats = stats; identString = identificationString; }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        // ---------------------------------------

        public void Show()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Password : {Password}");
            Console.WriteLine();

            if (Stats != null) { Stats.Show(); }

            Console.ReadKey();
        }

        // ---------------------------------------

        public bool Equals(User other)
        {
            if (other == null) return false;

            if (GetType() != other.GetType()) return false;

            return string.Equals(Name, other.Name) && string.Equals(Password, other.Password);
        }
    }

    [Serializable]
    class Game
    {
        public enum Difficulties { Easy, Normal, Medium, Difficult, Impossible }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Game() { Subject = "None"; Questions = new List<Question>(); Stats = new Statistic(); Difficultie = Difficulties.Easy; identString = GenerateIdentString(); }
        public Game(string subject) : this() { Subject = subject; }
        public Game(string subject, List<Question> questions, Statistic stats, Difficulties difficultie)
        { Subject = subject; Questions = questions; Stats = stats; Difficultie = difficultie; identString = GenerateIdentString(); }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Subject { get; set; }

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
            return Subject == newGame.Subject && Difficultie == newGame.Difficultie;
        }

        public override string ToString()
        {
            return $"Subject: {Subject} | Difficultie: {Difficultie} | Total Games: {Stats.Games} | Of those, they won: {Stats.Wins}";
        }
    }
}
