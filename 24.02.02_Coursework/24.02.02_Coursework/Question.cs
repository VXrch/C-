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

        static bool IsValid(params string[] value)
        {
            foreach (var item in value)
            {
                if (string.IsNullOrEmpty(item) || string.IsNullOrWhiteSpace(item))
                {
                    return false;
                }
            }
            return true;
        }

        public List<string> GetAnswers()
        {
            List<string> answers = new List<string> { Correct_answer, Incorrect_answer_1, Incorrect_answer_2, Incorrect_answer_3, };

            Random random = new Random();
            answers = answers.OrderBy(x => random.Next()).ToList();

            return answers;
        }
        static public Question MakeQuestion()
        {
            while (true)
            {
                Question temp = new Question();

                string t0, t1, t2, t3, t4;

                Console.Clear();
                Console.Write("Enter question (or [0] to exit): "); t0 = Console.ReadLine();
                if (t0 == "0") { throw new Exit(); }

                Console.Write("Enter correct answer: "); t1 = Console.ReadLine();

                Console.Write("Enter incorrect answer [1]: "); t2 = Console.ReadLine();
                Console.Write("Enter incorrect answer [2]: "); t3 = Console.ReadLine();
                Console.Write("Enter incorrect answer [3]: "); t4 = Console.ReadLine();

                if (IsValid(t0, t1, t2, t3, t4))
                {
                    temp.question = t0;
                    temp.Correct_answer = t1;
                    temp.Incorrect_answer_1 = t2;
                    temp.Incorrect_answer_2 = t3;
                    temp.Incorrect_answer_3 = t4;
                    return temp;
                }
            }
        }
    }
}
