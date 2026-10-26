using StoreCore;

public class Program
{
    EditProduct edit = new EditProduct();

    // Числа соответствуют номерам пунктов, которые видит пользователь в главном меню.
    enum MenuMain
    {
        ShowProducts = 1,
        EditProducts = 2,
        Exit = 3,
    }

    // Отдельные пункты меню редактирования, их номера могут совпадать с главным меню.
    enum MenuEdit
    {
        Add = 1,
        Remove = 2,
        Back = 3,
    }

    public static void Main(string[] args)
    {
        // Main статический, поэтому создаём объект для доступа к полю edit и методу EditMenu.
        Program program = new Program();

        string input;

        // Главное меню повторяется, пока пользователь не выберет выход.
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1) просмотр имеющихся товаров\n2) Редактирование товаров\n3) Выход");

            input = InputClass.Input();
            // Проверяем, что ввод — число в диапазоне пунктов меню: приведение к enum само это не проверяет.
            if (!int.TryParse(input, out int number) || number > 3 || number < 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверное значение. Нажмите любую кнопку, чтобы продолжить");
                Console.ResetColor();
                Console.ReadKey();         
                continue;
            }

            switch ((MenuMain)number)
            {
                case MenuMain.ShowProducts:
                    program.edit.ShowProducts();
                    break;
                case MenuMain.EditProducts:
                    program.EditMenu();
                    break;
                case MenuMain.Exit:
                    return;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод. Попробуйте снова. Нажмите любую клавишу для продолжения.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }
        }
    }   
    public void EditMenu()
    {

        string input;

        // Меню редактирования повторяется, пока пользователь не выберет «Назад».
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1) Добавить товар\n2) Удалить товар\n3) Назад");

            input = InputClass.Input();
            // Проверяем, что ввод — число в диапазоне пунктов меню: приведение к enum само это не проверяет.
            if (!int.TryParse(input, out int number) || number > 3 || number < 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверное значение. Нажмите любую кнопку, чтобы продолжить");
                Console.ResetColor();
                Console.ReadKey();
                continue;
            }

            switch ((MenuEdit)number)
            {
                case MenuEdit.Add:
                    edit.AddProduct();
                    break;
                case MenuEdit.Remove:
                    // Удалять нечего, если список товаров пуст.
                    if (EditProduct.Products.Count == 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Список пуст. Нажмите любую клавишу, чтобы продолжить.");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        edit.RemoveProduct();
                    }
                    break;
                case MenuEdit.Back:
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    Console.ResetColor();
                    break;
            }
        }
    }    
}