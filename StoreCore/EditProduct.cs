using System;
using System.Collections.Generic;
using System.Text;

namespace StoreCore
{
    // Методы этого класса управляют списком товаров и взаимодействуют с пользователем через консоль.
    internal class EditProduct
    {
        // Список общий для всех объектов EditProduct, потому что свойство объявлено static.
        public static List<ListProducts> Products { get; set; } = new();


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
                foreach (ListProducts product in Products)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(product.Name);
                    Console.ResetColor();
                }
                Console.WriteLine("Нажмите любую клавишу для возврата в главное меню.");
                Console.ReadKey();
            }
        }
        public void AddProduct()
        {
            string[] names;
            string backButton; // заранее присваиваю значение, чтобы избежать ошибки компеляции

            // Можно добавлять товары несколько раз подряд; ввод back завершает этот режим.
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Для возврата в главное меню введите 'back'");
                Console.ResetColor();
                Console.WriteLine("Введите название товаров: ");

                names = InputClass.Input().Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
                backButton = "no values";


                foreach (string name in names)
                {
                    if (name == "back")
                    {
                        backButton = "back";
                    }
                    else
                    {
                        // Считаем пробел, запятую и точку разделителями отдельных названий товаров.
                        Products.Add(new ListProducts(name));
                    }
                }
                if (backButton == "back")
                {
                    return;
                }
            }
        }
        public void RemoveProduct()
        {
            string[] removeArray;
            string backButton; // заранее присваиваю значение, чтобы избежать ошибки компеляции            
            int index;

            // Режим удаления повторяется, пока пользователь не введёт back.
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Для возвращения в главное меню введите 'back'");
                Console.ResetColor();
                Console.WriteLine("Введите название товара для удаления: ");

                // Разделяем введённую строку, чтобы обработать каждое название отдельно.
                removeArray = InputClass.Input().Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
                int arrayIndex = 0;
                backButton = "no values";

                while (arrayIndex < removeArray.Length)
                {
                    // программа запишет желание пользователя в отдельную переменную
                    if (removeArray[arrayIndex] == "back")
                    {
                        backButton = removeArray[arrayIndex];
                    }
                    // сначало программа проверит все аргументы находящиеся в массиве
                    else if ((index = Products.FindIndex(Products => Products.Name == removeArray[arrayIndex])) != -1)
                    {
                        Products.RemoveAt(index);
                    }
                    // программа удаляет совпадения
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Обьект не найден: " + removeArray[arrayIndex] + " нажмите любую кнопку, чтобы продолжить: ");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    arrayIndex++;
                }
                // программа выходит обратно в меню только после того как все обьекты были удалены из обьекта Products 
                if (backButton == "back")
                {
                    return;
                }
            }
        }
    }
}
