using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text;

namespace _24._02._02_Coursework
{
    internal class Program
    {
        delegate void FirstAndFinalDelegate();
        delegate void GameModeDelegate();
        class Exit : Exception { }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

            public void SaveToJson(string fileName)
            {
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(fileName, jsonString);
            }
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
            public void SaveToJson(string fileName)
            {
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(fileName, jsonString);
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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        class FirstAndFinal
        {
            public FirstAndFinal()
            {
                Users = new List<User>();
                Games = new List<Game>();

                in_game_user = null;
                First();
            }

            // ---------------------------------------

            public List<User> Users { get; set; }

            // ---------------------------------------

            public List<Game> Games { get; set; }

            // ---------------------------------------

            public User in_game_user { get; set; }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            void UsersFileWorkLoad()
            {
                try
                {
                    string filename = "AllUsers.json";

                    if (File.Exists(filename))
                    {
                        string json = File.ReadAllText(filename);

                        Users = JsonSerializer.Deserialize<List<User>>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("   !!!  EXCEPTION  !!! \n" + ex.Message);
                    Console.WriteLine();
                }
            }
            void UsersFileWorkSave()
            {
                try
                {
                    int index = FindUser(in_game_user);
                    Users[index] = in_game_user;

                    string filename = "AllUsers.json";

                    string json = JsonSerializer.Serialize(Users, new JsonSerializerOptions { WriteIndented = true });

                    File.WriteAllText(filename, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(@"   /~~~/  EXCEPTION  \~~~\ " + '\n' + ex.Message);
                    Console.WriteLine();
                }
            }

            void GamesFileWorkLoad()
            {
                try
                {
                    string filename = "AllGames.json";

                    if (File.Exists(filename))
                    {
                        string json = File.ReadAllText(filename);

                        Games = JsonSerializer.Deserialize<List<Game>>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("   !!!  EXCEPTION  !!! \n" + ex.Message);
                    Console.WriteLine();
                }
            }
            void GamesFileWorkSave()
            {
                try
                {
                    string filename = "AllGames.json";

                    string json = JsonSerializer.Serialize(Games, new JsonSerializerOptions { WriteIndented = true });

                    File.WriteAllText(filename, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("   !!!  EXCEPTION  !!! \n" + ex.Message);
                    Console.WriteLine();
                }
            }

            bool IsExist(User user)
            {
                foreach (var ur in Users)
                {
                    if (ur.Name == user.Name && ur.Password == user.Password)
                    {
                        return true;
                    }
                }
                return false;
            }

            int FindUser(User user)
            {
                for (int i = 0; i < Users.Count; i++)
                {
                    if (Users[i].Name == user.Name && Users[i].Password == user.Password)
                    {
                        return i;
                    }
                }
                throw new Exception();
            }

            public void CreateNewGame()
            {
                try
                {
                    Game newGame = new Game();

                    Console.WriteLine("Enter game subject: "); newGame.Subject = Console.ReadLine();
                    Console.WriteLine("Enter game difficultie: "); newGame.Difficultie = Game.ChooseDifficultie();

                    string tempstr = "";
                    Question temp = new Question();

                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Enter question (or [0] to exit): "); tempstr = Console.ReadLine();
                        if (tempstr == "0") { break; } else { temp.question = tempstr; }
                        Console.Write("Enter correct answer: "); temp.Correct_answer = Console.ReadLine();
                        Console.Write("Enter incorrect answer [1]: "); temp.Incorrect_answer_1 = Console.ReadLine();
                        Console.Write("Enter incorrect answer [2]: "); temp.Incorrect_answer_2 = Console.ReadLine();
                        Console.Write("Enter incorrect answer [3]: "); temp.Incorrect_answer_3 = Console.ReadLine();

                        if (!string.IsNullOrEmpty(temp.question) && !string.IsNullOrEmpty(temp.Correct_answer) && !string.IsNullOrEmpty(temp.Incorrect_answer_1) && !string.IsNullOrEmpty(temp.Incorrect_answer_2) && !string.IsNullOrEmpty(temp.Incorrect_answer_3))
                        {
                            newGame.Questions.Add(temp);
                            Games.Add(newGame);
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error : " + ex); Console.ReadKey(); }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            void LogIn()
            {
                User user = new User();
                while (true)
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine("Enter your nickname (or [0] to exit): "); user.Name = Console.ReadLine();
                        if (user.Name == "0") { throw new Exit(); }

                        Console.Write("(~0_0)~ password ~  "); user.Password = Console.ReadLine();

                        if (IsExist(user))
                        {
                            in_game_user = Users[FindUser(user)];
                            return;
                        }

                        Console.WriteLine("No such user was found!");
                        Console.ReadKey();
                    }
                    catch (Exit) { throw new Exit(); }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }
            void Register()
            {
                bool correct = true;

                User user = new User();
                while (true)
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine("Enter your nickname (or [0] to exit): "); string name = Console.ReadLine();
                        if (name == "0") { throw new Exit(); } else { user.Name = name; }

                        while (true)
                        {
                            Console.WriteLine("Enter your password (8 symbhols, big letters, small letters and numbers): ");
                            Console.WriteLine("(~0_0)~  "); string line = Console.ReadLine();

                            if (Menu.IsCorrectPassword(line)) { user.Password = line; break; }
                            else { Console.WriteLine("Incorrect password! Try again!"); Console.ReadKey(); Console.Clear(); }
                        }

                        if (Users == null) { Console.WriteLine("Empty data!"); correct = false; }
                        for (int i = 0; i < Users.Count; i++)
                        {
                            if (user.Equals(Users[i])) { Console.WriteLine("This user already exists! You can login or create a new account!"); correct = false; break; }
                        }

                        if (correct)
                        {
                            in_game_user = user;
                            Users.Add(in_game_user);

                            Console.WriteLine("You have successfully registered!");
                            Console.ReadKey(); Console.Clear();
                            return;
                        }
                    }
                    catch (Exit) { }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }
            void EnterAsAGuest()
            {
                try
                {
                    Console.WriteLine("If you log in as a guest, your data will not be saved after logging out.");
                    Console.WriteLine("Are you sure you want to continue?");

                    if (Menu.IsContinue()) { in_game_user = new User("Guest"); }
                    else { throw new Exit(); }
                }
                catch (Exit) { throw; }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public void First()
            {
                UsersFileWorkLoad();
                GamesFileWorkLoad();

                bool exit = false;
                while (!exit)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("|=|=|=|   Entry   |=|=|=|");
                        Console.WriteLine();
                        Console.WriteLine("[0] - Exit");
                        Console.WriteLine("[1] - Log in");
                        Console.WriteLine("[2] - Register");
                        Console.WriteLine("[3] - Enter as a guest");
                        Console.WriteLine();

                        int res = Menu.IntResult();

                        FirstAndFinalDelegate[] md = new FirstAndFinalDelegate[] { LogIn, Register, EnterAsAGuest };

                        if (res == 0) { exit = true; }
                        else if (res != -1) { res--; md[res]?.Invoke(); exit = true; }
                    }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
            }
            public void Final()
            {
                UsersFileWorkSave();
                GamesFileWorkSave();
            }

            public void Win(Game game)
            {
                try
                {
                    for (int i = 0; i < Games.Count; i++)
                    {
                        if (Games[i].identString == game.identString)
                        {
                            Games[i].Stats.Wins++;
                            Games[i].Stats.Games++;
                        }
                    }
                    in_game_user.Stats.Wins++;
                    in_game_user.Stats.Games++;
                }
                catch (Exception ex) { Console.WriteLine("Error with writing new win!" + ex.Message); }
            }
            public void Lose(Game game)
            {
                try
                {
                    for (int i = 0; i < Games.Count; i++)
                    {
                        if (Games[i].identString == game.identString)
                        {
                            Games[i].Stats.Loses++;
                            Games[i].Stats.Games++;
                        }
                    }
                    in_game_user.Stats.Wins++;
                    in_game_user.Stats.Games++;
                }
                catch (Exception ex) { Console.WriteLine("Error with writing new lose!" + ex.Message); }
            }

            public void ShowAllGames()
            {
                if (Games.Count == 0) { Console.WriteLine("Games list empty!"); }
                else
                {
                    for (int i = 0; i < Games.Count; i++)
                    {
                        Console.WriteLine(Games[i]);
                    }
                }
                Console.ReadKey();
            }
            public void ShowAllUsers()
            {
                if (Users.Count == 0) { Console.WriteLine("Games list empty!"); Console.ReadKey(); }
                else
                {
                    for (int i = 0; i < Users.Count; i++)
                    {
                        Console.WriteLine(Users[i].Name + " | " + Users[i].Password);
                    }
                }
                Console.ReadKey();
            }
        }
        class Menu
        {
            FirstAndFinal _startEnd;
            public Menu() { _startEnd = new FirstAndFinal(); }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public static bool IsContinue()
            {
                while (true)
                {
                    try
                    {
                        Console.Write(@"[1 - No] '\(+_+)/' [2 - Yes]");
                        Console.Write("(/0_0)/~  "); int result = int.Parse(Console.ReadLine());

                        if (result == 0) return false; else if (result == 1) return true; else throw new ArgumentException();
                    }
                    catch (Exception ex) { Console.WriteLine("Wrong data! " + ex.Message); throw new Exception(); }
                }
            }
            public static bool IsCorrectPassword(string line)
            {
                if (string.IsNullOrEmpty(line)) { return false; }

                string regexPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$";
                MatchCollection matches = Regex.Matches(line, regexPattern);

                if (matches.Count > 0) { return true; }
                else { return false; }
            }
            public static int IntResult()
            {
                try
                {
                    Console.Write("(/^.^)/~  "); int res = int.Parse(Console.ReadLine());
                    return res;
                }
                catch (Exception) { Console.WriteLine("Incorrect data!"); return -1; }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            void Quizz(Game game, ref int points)
            {
                List<string> answers = new List<string>();
                Random random = new Random();

                int[] array = new int[4] { 0, 1, 2, 3 };
                int int_answer = 0;

                for (int i = 0; i < game.Questions.Count; i++)
                {
                    array = array.OrderBy(x => random.Next()).ToArray();
                    answers = game.Questions[i].GetAnswers();

                    Console.WriteLine(game.Questions[i].question);
                    Console.WriteLine("[1]" + answers[0]);
                    Console.WriteLine("[2]" + answers[1]);
                    Console.WriteLine("[3]" + answers[2]);
                    Console.WriteLine("[4]" + answers[3]);

                    Console.WriteLine("Your answer (number): "); int_answer = int.Parse(Console.ReadLine());

                    string answer = "";
                    switch (int_answer)
                    {
                        case 1: answer = answers[0]; break;
                        case 2: answer = answers[1]; break;
                        case 3: answer = answers[2]; break;
                        case 4: answer = answers[3]; break;
                        default: Console.WriteLine("Incorrect answer number!"); break;
                    }

                    if (game.Questions[i].Correct_answer == answer) { Console.WriteLine("Correct! +1 point"); points++; }
                    else { Console.WriteLine("Nope! -1 point"); points--; }
                }
            }
            void GameOver(Game game, int points)
            {
                if (points > 0)
                {
                    Console.WriteLine("You win!");
                    _startEnd.Win(game);
                }
                else
                {
                    Console.WriteLine("You've lost!");
                    _startEnd.Lose(game);
                }
            }

            void PlayGame(Game game)
            {
                int points = 0;

                Console.WriteLine($"The game's about to start. There will be {game.Questions.Count} questions! Good luck!");

                Quizz(game, ref points);
                GameOver(game, points);
            }

            Game FindGame(Game subject_game)
            {
                List<Game> matchingGames = _startEnd.Games
                        .Where(game => game.IsMatchingGame(subject_game))
                        .ToList();

                if (matchingGames.Count == 0)
                {
                    Console.WriteLine("No matching Games found!"); Console.ReadKey(); throw new Exception();
                }
                else if (matchingGames.Count == 1)
                {
                    return matchingGames[0];
                }
                else
                {
                    Console.WriteLine($"{matchingGames.Count} matching Games were found! Choose one of them! (game number)");
                    int choice = IntResult();

                    if (choice < matchingGames.Count && choice >= 0) { return matchingGames[choice]; }
                    else { Console.WriteLine("Incorrect number!"); }
                    throw new Exception("Incorrect data!");
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            void Math()
            {
                try
                {
                    Game math_game = new Game("Math");
                    math_game.Difficultie = Game.ChooseDifficultie();

                    math_game = FindGame(math_game);
                    PlayGame(math_game);
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            }
            void English()
            {
                try
                {
                    Game english_game = new Game("English");
                    english_game.Difficultie = Game.ChooseDifficultie();

                    english_game = FindGame(english_game);
                    PlayGame(english_game);
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public void GameMenu()
            {
                if (_startEnd.in_game_user == null) return;

                bool exit = false;
                while (!exit)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(@"! \(^^)/ !   Welcome to main menu   ! /(^^)\ !");
                        Console.WriteLine(@"------------  Choose one option  ------------");
                        Console.WriteLine();
                        Console.WriteLine("[0] - Exit");
                        Console.WriteLine("[1] - See my stats");
                        Console.WriteLine("[2] - See Games");
                        Console.WriteLine();
                        Console.WriteLine("[3] - Math");
                        Console.WriteLine("[4] - English");
                        Console.WriteLine();
                        Console.WriteLine("[5] - Create a new quizz");
                        Console.WriteLine();

                        int res = IntResult();

                        GameModeDelegate[] gm_delegete = new GameModeDelegate[]
                        {
                            Math, English,
                        };

                        if (res == 0) { exit = true; }
                        else if (res == 1) { _startEnd.in_game_user.Show(); }
                        else if (res == 2) { _startEnd.ShowAllGames(); }
                        else if (res == 5) { _startEnd.CreateNewGame(); }
                        else if (res != -1) { res -= 3; gm_delegete[res]?.Invoke(); }
                    }
                    catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
                }
                _startEnd.Final();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.GameMenu();
        }
    }
}