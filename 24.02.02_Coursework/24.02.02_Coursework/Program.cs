﻿

namespace _24._02._02_Coursework
{
    delegate void FirstAndFinalDelegate();
    delegate void GameModeDelegate();

    class Exit : Exception { }
    class AlredyExist : Exception { }

    internal class Program
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.GameMenu();
        }
    }
}