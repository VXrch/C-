using System.Text.Json;

namespace _24._02._02_Coursework
{
    class UsersWork
    {
        public List<User> Users { get; set; }

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
                if (in_game_user.Name == "Guest") { return; }

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

        // ----------

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
                    if (Users == null) { Console.WriteLine("Empty data!"); correct = false; }

                    Console.WriteLine("Enter your nickname (or [0] to exit): "); string name = Console.ReadLine();
                    if (name == "0") { throw new Exit(); } else { user.Name = name; }

                    user.Password = User.FillPassword();

                    for (int i = 0; i < Users.Count; i++)
                    {
                        if (user.Equals(Users[i]))
                        {
                            Console.WriteLine("This user already exists! You can log in or create a new account!");
                            correct = false; Console.ReadKey(); Console.Clear(); break;
                        }
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
                catch (Exit) { throw new Exception(); }
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

        // ----------

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
    }

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

        public List<Game> Games { get; set; }

        public User in_game_user { get; set; }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadInfo()
        {
            UsersFileWorkLoad();
            GamesFileWorkLoad();
        }
        public void Final()
        {
            UsersFileWorkSave();
            GamesFileWorkSave();
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

        // ----------

        void SubjectsFileWorkLoad()
        {
            try
            {
                string filename = "AllSubjects.json";

                if (File.Exists(filename))
                {
                    string json = File.ReadAllText(filename);

                    //Users = JsonSerializer.Deserialize<List<User>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("   !!!  EXCEPTION  !!! \n" + ex.Message);
                Console.WriteLine();
            }
        }
        void SubjectsFileWorkSave()
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CreateNewGame()
        {
            try
            {
                Game newGame = new Game();
                bool correct_created = false;

                Console.WriteLine("Enter game subject: "); newGame.subject = Subject.MakeSubject();
                Console.WriteLine("Enter game difficultie: "); newGame.Difficultie = Game.ChooseDifficultie();

                while (true)
                {
                    try
                    {
                        Question temp = Question.MakeQuestion();
                        newGame.Questions.Add(temp);
                        correct_created = true;

                        Console.WriteLine("- - - - - - - - - - - - - - - - - -");
                    }
                    catch (Exit) { break; }                    
                }
                if (correct_created) { Games.Add(newGame); }
            }
            catch (Exception ex) { Console.WriteLine("Error : " + ex); Console.ReadKey(); }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void First()
        {
            LoadInfo();

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
                catch (Exception) { }
            }
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
            Console.ReadKey();
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
                in_game_user.Stats.Loses++;
                in_game_user.Stats.Games++;
            }
            catch (Exception ex) { Console.WriteLine("Error with writing new lose!" + ex.Message); }
            Console.ReadKey();
        }

        // ----------

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
        
    }
}