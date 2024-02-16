
namespace _24._02._02_Coursework
{
    [Serializable]
    class GameSubjects
    {
        List<Subject> _subjects;
        public List<Subject> Subjects
        {
            get { return _subjects; }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    _subjects.Add(value[i]);
                } 
            }
        }

        public void AddSubject(Subject subject)
        {
            if (Subjects.Contains(subject)) { throw new AlredyExist(); }

            Subjects.Add(subject);
        }
    }
}