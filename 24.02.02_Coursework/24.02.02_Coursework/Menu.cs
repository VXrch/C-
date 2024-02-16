using System.Text.RegularExpressions;

namespace _24._02._02_Coursework
{
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
                Console.ReadKey(); Console.Clear();
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

        //  ----------

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

        Subject ChooseSubject()
        {
            for (int i = 0; i < ; i++)
            {

            }




            throw new Exception();
        }

        void StartGame()
        {
            try
            {
                Subject subj = ChooseSubject();

                Game game = new Game(subj);
                game.Difficultie = Game.ChooseDifficultie();

                game = FindGame(game);
                PlayGame(game);
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
                    Console.WriteLine("[2] - See all games");
                    Console.WriteLine();
                    Console.WriteLine("[3] - Play");
                    Console.WriteLine();
                    Console.WriteLine("[4] - Create a new quizz");
                    Console.WriteLine();

                    int res = IntResult();

                    switch (res)
                    {
                        case 0: exit = true; break;
                        case 1: _startEnd.in_game_user.Show(); break;
                        case 2: _startEnd.ShowAllGames(); break;
                        case 3: StartGame();  break;
                        case 4: _startEnd.CreateNewGame(); break;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            }
            _startEnd.Final();
        }
    }
}