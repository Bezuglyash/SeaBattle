using System;
using System.Data.Entity;

namespace SeaBattle
{
    class Program
    {
        public static void Main()
        {
            Console.Title = "Морской бой";
            Console.WindowHeight = 45;
            Console.WindowWidth = 105;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            ConsoleInterface WorkConsole = new ConsoleInterface();
            WorkConsole.Get_start();
            int choice = 0;
            while (true)
            {
                WorkConsole.Set_cursor(38, 9);
                var input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if (choice > 0 && choice <= 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Только цифры от 1 до 3!");
                        for (int i = 0; i < input.Length; i++)
                        {
                            WorkConsole.Set_cursor(38 + i, 9);
                            Console.WriteLine(" ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Неправильный формат ввода!");
                    for (int i = 0; i < input.Length; i++)
                    {
                        WorkConsole.Set_cursor(38 + i, 9);
                        Console.WriteLine(" ");
                    }
                }
            }
            var gameSpace = new GameSpace();
            gameSpace.Get_start(choice);
            /**int key = 1;
            using (var context = new DatabaseContext())
            {
                var data = context.DataUsers.Find(key);
                Console.WriteLine($"id: {data.Users_Id}, Имя: {data.Name}");
            }*/
            Console.ReadLine();
        }
    }
}