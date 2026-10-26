using System;
using System.Collections.Generic;
using System.Text;

namespace StoreCore
{
    // Методы этого класса управляют списком товаров и взаимодействуют с пользователем через консоль.
    internal class EditProduct
    {
        // Список общий для всех объектов EditProduct, потому что свойство объявлено static.
        public static List<string> Products { get; set; } = new();


        //public Program(string products) в будущем пригодится
        //{
        //   Products = new List<string>(products.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries));
        //}

        public void ShowProducts()
        {
            // Отдельно обрабатываем пустой список, чтобы не выводить пустой перечень.
            if (Products == null || Products.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет доступных товаров, нажмите любую клавишу для возврата в главное меню.");
                Console.ResetColor();
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Список товаров:");
                foreach (string product in Products)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(product);
                    Console.ResetColor();
                }
                Console.WriteLine("Нажмите любую клавишу для возврата в главное меню.");
                Console.ReadKey();
            }
        }
        public void AddProduct()
        {
            string Addinput;
            // Можно добавлять товары несколько раз подряд; ввод back завершает этот режим.
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Для возврата в главное меню введите 'back'");
                Console.ResetColor();
                Console.WriteLine("Введите название товаров: ");

                Addinput = InputClass.Input();
                if (Addinput == "back")
                {
                    return;
                }
                else
                {
                    // Считаем пробел, запятую и точку разделителями отдельных названий товаров.
                    Products.AddRange(Addinput.Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
        }
        public void RemoveProduct()
        {
            string RemoveInput;
            string[] RemoveArray;

            // Режим удаления повторяется, пока пользователь не введёт back.
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Для возвращения в главное меню введите 'back'");
                Console.ResetColor();
                Console.WriteLine("Введите название товара для удаления: ");

                RemoveInput = InputClass.Input();
                // Разделяем введённую строку, чтобы обработать каждое название отдельно.
                RemoveArray = RemoveInput.Split(' ', ',', '.');

                for (int x = 0; x != RemoveArray.Length; x++)
                {
                    if (RemoveInput != "back")
                    {
                        Products.Remove(RemoveArray[x]);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
