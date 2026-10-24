using System;
using System.Collections.Generic;
using System.Text;

namespace ЧТО_ТО1
{
    static class InputClass
    { 
        public static string Input()
        {
            string input;

            while (true)
            {
                input = Console.ReadLine();
                if (input != "")
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    Console.ResetColor();
                }
            }
        }
    }
}
