using System;
using System.Collections.Generic;
using VideoMenuBLL;
using static System.Console;

namespace VideoMenuUI
{
    class ExtraUI
    {
        

        public static bool ConfirmInfo()
        {
            WriteLine("(Y/N)");
            string accept = ReadLine().ToLower();
            while (!accept.Equals("y") && !accept.Equals("n"))
            {
                WriteLine("Input Y for yes or N for No");
                accept = ReadLine().ToLower();
            }
            if (accept.Equals("y"))
            {
                return true;
            }

            return false;
        }

        public static int ShowMenu(string[] menuItems)
        {
            Clear();
            WriteLine("Select what you want to do: \n");
            var numberOfItems = menuItems.Length;
            for (int i = 0; i < menuItems.Length; i++)
            {
                WriteLine($"{(i + 1)}: {menuItems[i]}");
            }
            WriteLine($"Please select a menu(1-{numberOfItems}):");
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1
                   || selection > numberOfItems
            )
            {
                WriteLine($"You need to select a number between 1 and {numberOfItems}");
            }

            return selection;
        }
    }
}
