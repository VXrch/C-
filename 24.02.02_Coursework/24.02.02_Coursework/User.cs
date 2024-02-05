using System.Text;

namespace _24._02._02_Coursework
{
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
}