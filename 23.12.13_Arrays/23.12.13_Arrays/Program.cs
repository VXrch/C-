namespace _23._12._13_Array_Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
                Оголосити одновимірний (5 елементів) масив з назвою
                A i двовимірний масив (3 рядки, 4 стовпці) дробових чисел
                з назвою B. Заповнити одновимірний масив А числами,
                введеними з клавіатури користувачем, а двовимірний
                масив В — випадковими числами за допомогою циклів.
                Вивести на екран значення масивів: масиву А — в один
                рядок, масиву В — у вигляді матриці. Знайти у даних
                масивах загальний максимальний елемент, мінімальний
                елемент, загальну суму усіх елементів, загальний добуток
                усіх елементів, суму парних елементів масиву А, суму
                непарних стовпців масиву В.
             */

            int[] array = new int[5];
        }

        #region Task 2
        static void TaksNumberTwo()
        {
            Random rand = new Random();

            int[] array = new int[5];

            for (int i = 0; i < 5; i++)
            {
                array[i] = rand.Next(33);
                Console.WriteLine(array[i]);
            }

            Console.WriteLine("Enter numbers: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"Numbers less than {number}: ");

            bool find = false;
            for (int i = 0; i < 5; i++)
            {
                if (array[i] < number)
                {
                    Console.WriteLine(array[i]);
                    find = true;
                }
            }
            if (find == false)
            {
                Console.WriteLine("None");
            }
        }
        #endregion

        #region Task 1
        static void TaskNumberOne()
        {
            Console.WriteLine("Enter 5 numbers: ");

            int[] array = new int[5];

            for (int i = 0; i < 5; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Eaven numbers: {Eaven(array)}");
            Console.WriteLine($"No eaven numbers: {NonEaven(array)}");
            Console.WriteLine($"Unique numbers: {UniqueElements(array)}");
        }
        static int Eaven(int[] array)
        {
            int res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    res++;
                }
            }
            return res;
        }
        static int NonEaven(int[] array)
        {
            int res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 1)
                {
                    res++;
                }
            }
            return res;
        }
        static int UniqueElements(int[] array)
        {
            int res = 0;
            bool unique;

            for (int i = 0; i < array.Length; i++)
            {
                unique = true;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        unique = false;
                    }
                }
                if (unique == true)
                {
                    res++;
                }
            }
            return res - 1;
        }
        #endregion
    }
}