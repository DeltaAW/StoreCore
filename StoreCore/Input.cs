using System;
using System.Collections.Generic;
using System.Text;

namespace StoreCore
{
    static class InputClass
    { 
        public static string Input()
        {
            string input;

            // Повторяем чтение, пока пользователь не введёт хотя бы один символ.
            while (true)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
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
