
namespace _24._02._02_Coursework
{
    struct Subject
    {
        public Subject() { _subject = null; }
        public Subject(string subject) { if (IsValidSubject(subject)) { _subject = subject; } }

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

        static public bool IsValidSubject(string subject)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrWhiteSpace(subject) || !char.IsUpper(subject[0]) || subject.Length < 2) { return false; }
            return true;
        }
        static public bool IsValidSubject(Subject subject)
        {
            return IsValidSubject(subject.SubjectName);
        }

        public override string ToString()
        {
            return SubjectName;
        }
        static public Subject MakeSubject()
        {



            throw new Exception();
        }

        public static bool operator ==(Subject lsubj, Subject rsubj)
        {
            return lsubj.SubjectName == rsubj.SubjectName;
        }
        public static bool operator !=(Subject lsubj, Subject rsubj)
        {
            return lsubj.SubjectName != rsubj.SubjectName;
        }
    }
}