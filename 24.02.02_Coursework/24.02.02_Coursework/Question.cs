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
}
