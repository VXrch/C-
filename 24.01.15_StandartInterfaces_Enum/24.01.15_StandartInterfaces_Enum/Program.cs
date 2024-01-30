using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _24._01._15_StandartInterfaces_Enum
{
    internal class Program
    {
        class Director : ICloneable
        {
            public Director(string first_name, string last_name, string gender, int age) { FirstName = first_name; LastName = last_name; Gender = gender; Age = age; }

            private string _firstName;
            public string FirstName
            {
                get { return _firstName; }
                set
                {
                    if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }
                    else { _firstName = value; }
                }
            }

            private string _lastName;
            public string LastName
            {
                get { return _lastName; }
                set
                {
                    if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }
                    else { _lastName = value; }
                }
            }

            private string _gender;
            public string Gender
            {
                get { return _gender; }
                set
                {
                    if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }
                    else { _gender = value; }
                }
            }

            private int _age;
            public int Age
            {
                get { return _age; }
                set
                {
                    if (value < 18 || value > 130) { throw new ArgumentException(); }
                    else { _age = value; }
                }
            }

            public object Clone()
            {
                return new Director(FirstName, LastName, Gender, Age);
            }
            public override string ToString()
            {
                return $"First nama: [{FirstName}] | Last name: [{LastName}] | Gender: [{Gender}] | Age: [{Age}]";
            }
        }

        class Movie : ICloneable, IComparable<Movie>
        {
            public Movie() { Title = "Movie title"; MovieDirector = new Director("FN", "LS", "G", 20); Country = "Movie country"; MovieGenre = Genre.Adventure; Year = 2000; Rating = 5; }
            public Movie(string title, Director director, string country, Genre genre, int year, short rating) { Title = title; MovieDirector = director; Country = country; MovieGenre = genre; Year = year; Rating = rating; }

            public enum Genre
            {
                Action,
                Adventure,
                Comedy,
                Drama,
                Horror,
                Romance,
                SciFi,
                Thriller,
                Fantasy,
                Mystery
            }

            private string _title;
            public string Title
            {
                get { return _title; }
                set
                {
                    if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }
                    else { _title = value; }
                }
            }

            private Director _director;
            public Director MovieDirector
            {
                get { return _director; }
                set { _director = value; }
            }

            private string _country;
            public string Country
            {
                get { return _country; }
                set
                {
                    if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }
                    else { _country = value; }
                }
            }

            public Genre MovieGenre { get; set; }

            private int _year;
            public int Year
            {
                get { return _year; }
                set
                {
                    if (DateTime.Now.Year < value) { throw new ArgumentNullException(nameof(value)); }
                    else { _year = value; }
                }
            }

            private short _rating;
            public short Rating
            {
                get { return _rating; }
                set
                {
                    if (value < 0 || value > 10) { throw new ArgumentNullException(nameof(value)); }
                    else { _rating = value; }
                }
            }

            public object Clone()
            {
                return new Movie(Title, MovieDirector, Country, Genre.Comedy, Year, Rating);
            }
            public int CompareTo(Movie other)
            {
                return Title.CompareTo(other.Title);
            }
            public override string ToString()
            {
                return $"Title: [{Title}] | Director: [{MovieDirector.LastName}] | Country: [{Country}] | Genre: [{MovieGenre}] | Year: [{Year}] | Rating [{Rating}]";
            }

            public class YearComparer : IComparer<Movie>
            {
                public int Compare(Movie x, Movie y)
                {
                    return x.Year.CompareTo(y.Year);
                }
            }
            public class RatingComparer : IComparer<Movie>
            {
                public int Compare(Movie x, Movie y)
                {
                    return x.Rating.CompareTo(y.Rating);
                }
            }
        }

        class Cinema : IEnumerable<Movie>, IComparable<Cinema>
        {
            public Cinema() { _movies = new List<Movie>(); Address = "None"; }
            public Cinema(Movie movie, string address) { _movies.Add(movie); Address = address; }

            private List<Movie> _movies;

            public void Add(Movie movie)
            {
                _movies.Add(movie);
            }

            private string _address;
            public string Address
            {
                get { return _address; }
                set
                {
                    if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }
                    else { _address = value; }
                }
            }

            int GetMoviesNumber
            {
                get { return _movies.Count; }
            }

            public int CompareTo(Cinema other)
            {
                return GetMoviesNumber.CompareTo(other.GetMoviesNumber);
            }
            public override string ToString()
            {
                return $"Cinema address: [{Address}] | Movies in this cinema: [{GetMoviesNumber}]";
            }

            public IEnumerator<Movie> GetEnumerator()
            {
                return _movies.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void PrintMovies()
            {
                for (int i = 0; i < _movies.Count; i++)
                {
                    Console.WriteLine(_movies[i]);
                }
            }
            public void PrintMoviesShort()
            {
                for (int i = 0; i < _movies.Count; i++)
                {
                    Console.WriteLine(_movies[i].Title + " --- " + _movies[i].Country);
                }
            }

            void Swap(int iter1, int iter2)
            {
                Movie temp = _movies[iter1];
                _movies[iter1] = _movies[iter2];
                _movies[iter2] = temp;
            }

            /// <summary>
            /// 1 = sort by title, 2 = sort by rating, 3 = sort by year
            /// </summary>
            /// <param name="Sort"></param>
            public void SortAsc(int sort = 1)
            {
                IComparer<Movie> comparer = null;

                switch (sort)
                {
                    case 1:
                        comparer = Comparer<Movie>.Default;
                        break;
                    case 2:
                        comparer = new Movie.RatingComparer();
                        break;
                    case 3:
                        comparer = new Movie.YearComparer();
                        break;
                    default:
                        throw new ArgumentException("Invalid sort option");
                }

                for (int i = 0; i < _movies.Count; i++)
                {
                    for (int j = 0; j < _movies.Count - 1; j++)
                    {
                        if (comparer.Compare(_movies[j], _movies[j + 1]) > 0)
                        {
                            Swap(j, j + 1);
                        }
                    }
                }
            }

            /// <summary>
            /// 1 = sort by title, 2 = sort by rating, 3 = sort by year
            /// </summary>
            /// <param name="Sort"></param>
            public void SortDesc(int sort = 1)
            {
                IComparer<Movie> comparer = null;

                switch (sort)
                {
                    case 1:
                        comparer = Comparer<Movie>.Default;
                        break;
                    case 2:
                        comparer = new Movie.RatingComparer();
                        break;
                    case 3:
                        comparer = new Movie.YearComparer();
                        break;
                    default:
                        throw new ArgumentException("Invalid sort option");
                }

                for (int i = 0; i < _movies.Count; i++)
                {
                    for (int j = 0; j < _movies.Count - 1; j++)
                    {
                        if (comparer.Compare(_movies[j], _movies[j + 1]) > 0)
                        {
                            Swap(j, j + 1);
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            /*                
                    Створити клас «Cinema», який має колекцію фільмів та методи для їх сортування.
                    Клас імплементує інтерфейс IEnumerable та дозволяє сортувати колекцію по різним
                         критеріям, приймаючи в метод сортування IComparer, який описує алгоритм порівняння.

                    Кожний фільм описуєтся класом «Movie», який містить параметри:
                        • Назва
                        • Опис
                        • Режисер - окремий клас з певними властивостями та інтерфейсом ICloneable
                        • Країна
                        • Жанр - enum
                        • Рік
                        • Рейтинг і тд.

                    Клас повинен реалізовувати інтерфейс IComparable та ICloneable.
                    Для всіх класів потрібно перевизначити метод ToString(), який повертає основну інформацію про об'єкт.
            */

            Cinema cinema = new Cinema();

            Console.WriteLine("=====   Cinema   =====");
            Console.WriteLine(cinema);
            Console.WriteLine();

            Movie movie1 = new Movie();
            cinema.Add(movie1);
            
            Console.WriteLine("=====   Add movie 1   =====");
            Console.WriteLine(cinema);
            Console.WriteLine();

            Console.WriteLine("=====   Movie 1 info   =====");
            Console.WriteLine(movie1);
            Console.WriteLine();

            Console.WriteLine("=====   Movie 1 director info   =====");
            Console.WriteLine(movie1.MovieDirector);
            Console.WriteLine();

            Movie movie2 = new Movie("Title 2", new Director("David", "Kopperfield", "Male", 56), "England", Movie.Genre.Action, 1980, 9);
            cinema.Add(movie2);

            Console.WriteLine("=====   Add movie 2   =====");
            Console.WriteLine(cinema);
            Console.WriteLine();

            Console.WriteLine("=====   Movie 2 info   =====");
            Console.WriteLine(movie2);
            Console.WriteLine();

            Console.WriteLine("=====   Movie 2 director info   =====");
            Console.WriteLine(movie2.MovieDirector);
            Console.WriteLine();

            cinema.SortAsc(1);

            Console.WriteLine("=====   SortAsc Title   =====");
            cinema.PrintMovies();
            Console.WriteLine();

            cinema.SortAsc(2);

            Console.WriteLine("=====   SortAsc Rating   =====");
            cinema.PrintMovies();
            Console.WriteLine();

            cinema.SortAsc(3);

            Console.WriteLine("=====   SortAsc YEAR   =====");
            cinema.PrintMovies();
            Console.WriteLine();
            cinema.SortDesc();

            Console.WriteLine("=====   SortDesc  =====");
            cinema.PrintMovies();
            Console.WriteLine();
        }
    }
}
