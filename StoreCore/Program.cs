using ЧТО_ТО1;

public class Program
{
    EditProduct edit = new EditProduct();

    public static void Main(string[] args)
    {
        Program program = new Program();

        string input;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1) просмотр имеющихся товаров\n2) Редактирование товаров\n3) Выход");            
            switch (InputClass.Input())
            {
                case "1":
                    program.edit.ShowProducts();
                    break;
                case "2":
                    program.EditMenu();
                    break;
                case "3":
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
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1) Добавить товар\n2) Удалить товар\n3) Назад");

            switch (InputClass.Input())
            {
                case "1":
                    edit.AddProduct();
                    break;
                case "2":
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
                case "3":
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