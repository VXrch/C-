
namespace _24._02._02_Coursework
{
    struct Subject
    {
        public Subject() { _subject = null; }

        // ------------------------------------

        string _subject;
        public string SubjectName
        {
            get { return _subject; }
            set
            {
                if (IsValidSubject(value)) { _subject = value; }
                else { Console.WriteLine($"I can't add [{value}] subject! Incorrect name format!"); }
            }
        }

        // ------------------------------------

        bool IsValidSubject(string subject)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrWhiteSpace(subject) || !char.IsUpper(subject[0]) || subject.Length < 3) { return false; }

            foreach (var item in subject)
            {
                if (!char.IsLetter(item)) { return false; }
            }

            return true;
        }
        public override string ToString()
        {
            return SubjectName;
        }
    }

    class GameSubjects
    {
        List<Subject> _subjects;
        public List<Subject> Subjects
        {
            get { return _subjects; }
        }

        public void Add(Subject subject)
        {
            if (Subjects.Contains(subject)) { throw new AlredyExist(); }

            //
            //
            //
        }

    }


}