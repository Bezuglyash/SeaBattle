using System;

namespace SeaBattle
{
    public class ConsoleInterface
    {
        public void Get_start()
        {
            Set_cursor(34, 0);
            Console.WriteLine("Добро пожаловать в игру Морской бой!");
            Set_cursor(28, 1);
            Console.WriteLine("______________________________________________");
            for (int i = 0; i < 6; i++)
            {
                Set_cursor(27, 2 + i);
                Console.WriteLine("|");
                Set_cursor(74, 2 + i);
                Console.WriteLine("|");
            }
            Set_cursor(28, 4);
            Console.WriteLine("_____________");
            Set_cursor(42, 4);
            Console.WriteLine("________________");
            Set_cursor(59, 4);
            Console.WriteLine("_______________");
            for (int i = 0; i < 3; i++)
            {
                Set_cursor(41, 5 + i);
                Console.WriteLine("|");
                Set_cursor(58, 5 + i);
                Console.WriteLine("|");
            }
            Set_cursor(28, 7);
            Console.WriteLine("_____________");
            Set_cursor(42, 7);
            Console.WriteLine("________________");
            Set_cursor(59, 7);
            Console.WriteLine("_______________");
            Set_cursor(49, 3);
            Console.WriteLine("Меню");
            Set_cursor(31, 6);
            Console.WriteLine("1 - Вход");
            Set_cursor(43, 6);
            Console.WriteLine("2 - Регистрация");
            Set_cursor(60, 6);
            Console.WriteLine("3 - Инструкция");
            Set_cursor(27, 9);
            Console.WriteLine("Ваш выбор:");
        }

        public void Input()
        {
            Console.Clear();
            Set_cursor(36, 0);
            Console.WriteLine("Вход в личное игровое пространство!");
            Set_cursor(36, 1);
            Console.WriteLine("___________________________________");
            for (int i = 0; i < 6; i++)
            {
                Set_cursor(35, 2 + i);
                Console.WriteLine("|");
                Set_cursor(45, 2 + i);
                Console.WriteLine("|");
                Set_cursor(71, 2 + i);
                Console.WriteLine("|");
            }
            int y = 0;
            for(int i = 0; i < 2; i++)
            {
                Set_cursor(36, 4 + y);
                Console.WriteLine("_________");
                Set_cursor(46, 4 + y);
                Console.WriteLine("_________________________");
                y += 3;
            }
            Set_cursor(38, 3);
            Console.WriteLine("Логин");
            Set_cursor(38, 6);
            Console.WriteLine("Пароль");
            Set_cursor(47, 37);
            Console.WriteLine("Примечание");
            Set_cursor(1, 38);
            Console.WriteLine("_______________________________________________________________________________________________________");
            Set_cursor(1, 42);
            Console.WriteLine("_______________________________________________________________________________________________________");
            for (int i = 0; i < 4; i++)
            {
                Set_cursor(0, 39 + i);
                Console.WriteLine("|");
                Set_cursor(104, 39 + i);
                Console.WriteLine("|");
            }
        }

        public void Registration()
        {
            Console.Clear();
            Set_cursor(33, 0);
            Console.WriteLine("Создание личного игрового пространства!");
            Set_cursor(28, 1);
            Console.WriteLine("_________________________________________________");
            for (int i = 0; i < 9; i++)
            {
                Set_cursor(27, 2 + i);
                Console.WriteLine("|");
                Set_cursor(40, 2 + i);
                Console.WriteLine("|");
                Set_cursor(77, 2 + i);
                Console.WriteLine("|");
            }
            int y = 0;
            for (int i = 0; i < 3; i++)
            {
                Set_cursor(28, 4 + y);
                Console.WriteLine("____________");
                Set_cursor(41, 4 + y);
                Console.WriteLine("____________________________________");
                y += 3;
            }
            Set_cursor(29, 3);
            Console.WriteLine("Имя игрока");
            Set_cursor(30, 6);
            Console.WriteLine("Логин");
            Set_cursor(30, 9);
            Console.WriteLine("Пароль");
            Set_cursor(47, 37);
            Console.WriteLine("Примечание");
            Set_cursor(1, 38);
            Console.WriteLine("_______________________________________________________________________________________________________");
            Set_cursor(1, 42);
            Console.WriteLine("_______________________________________________________________________________________________________");
            for (int i = 0; i < 4; i++)
            {
                Set_cursor(0, 39 + i);
                Console.WriteLine("|");
                Set_cursor(104, 39 + i);
                Console.WriteLine("|");
            }
        }

        public void AccountMenu(string nick)
        {
            Console.Clear();
            Set_cursor(38, 0);
            Console.WriteLine("Привет, " + nick + "!");
            Set_cursor(38, 1);
            Console.WriteLine("_____________________________");
            Set_cursor(47, 3);
            Console.WriteLine("1 - Играть");
            Set_cursor(46, 5);
            Console.WriteLine("2 - Настройки");
            Set_cursor(48, 7);
            Console.WriteLine("3 - Выход");
            Set_cursor(38, 8);
            Console.WriteLine("_____________________________");
            Set_cursor(38, 10);
            Console.WriteLine("Ваш выбор: ");
        }

        public void GamePlatform()
        {
            Console.Clear();
            Set_cursor(50, 0);
            Console.WriteLine("Битва");
            int count = 0;
            int x = 0;
            while (count != 2)
            {
                Set_cursor(4 + x, 4);
                Console.WriteLine("A");
                Set_cursor(8 + x, 4);
                Console.WriteLine("Б");
                Set_cursor(12 + x, 4);
                Console.WriteLine("В");
                Set_cursor(16 + x, 4);
                Console.WriteLine("Г");
                Set_cursor(20 + x, 4);
                Console.WriteLine("Д");
                Set_cursor(24 + x, 4);
                Console.WriteLine("Е");
                Set_cursor(28 + x, 4);
                Console.WriteLine("Ж");
                Set_cursor(32 + x, 4);
                Console.WriteLine("З");
                Set_cursor(36 + x, 4);
                Console.WriteLine("И");
                Set_cursor(40 + x, 4);
                Console.WriteLine("К");
                Set_cursor(3 + x, 5);
                Console.WriteLine("_______________________________________");
                for (int i = 0; i < 20; i++)
                {
                    Set_cursor(2 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(6 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(10 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(14 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(18 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(22 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(26 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(30 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(34 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(38 + x, 6 + i);
                    Console.WriteLine("|");
                    Set_cursor(42 + x, 6 + i);
                    Console.WriteLine("|");
                }
                int y = 0;
                for (int i = 1; i < 11; i++)
                {
                    if (i < 10)
                    {
                        Set_cursor(1 + x, 6 + y);
                        Console.WriteLine(i);
                    }
                    else
                    {
                        Set_cursor(0 + x, 6 + y);
                        Console.WriteLine(i);
                    }
                    y += 2;
                }
                y = 0;
                for (int i = 0; i < 10; i++)
                {
                    Set_cursor(3 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(7 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(11 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(15 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(19 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(23 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(27 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(31 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(35 + x, 7 + y);
                    Console.WriteLine("___");
                    Set_cursor(39 + x, 7 + y);
                    Console.WriteLine("___");
                    y += 2;
                }
                x += 60;
                count++;
            }
            Set_cursor(2, 2);
            Console.WriteLine("___________________");
            Set_cursor(63, 1);
            Console.WriteLine("Компьютер");
            Set_cursor(63, 2);
            Console.WriteLine("___________________");
            Set_cursor(43, 27);
            Console.WriteLine("Расстановка кораблей");
            Set_cursor(2, 28);
            Console.WriteLine("Введите размер корабля:");
            Set_cursor(2, 29);
            Console.WriteLine("Введите координату: ");
            Set_cursor(63, 28);
            Console.WriteLine("Готов!");
            Set_cursor(47, 37);
            Console.WriteLine("Примечание");
            Set_cursor(1, 38);
            Console.WriteLine("_______________________________________________________________________________________________________");
            Set_cursor(1, 42);
            Console.WriteLine("_______________________________________________________________________________________________________");
            for (int i = 0; i < 4; i++)
            {
                Set_cursor(0, 39 + i);
                Console.WriteLine("|");
                Set_cursor(104, 39 + i);
                Console.WriteLine("|");
            }
        }

        public void Fight()
        {
            Set_cursor(43, 27);
            Console.WriteLine("                    ");
            Set_cursor(47, 27);
            Console.WriteLine("Ход сражения");
            Set_cursor(2, 28);
            Console.WriteLine("Ваш выстрел:");
            Set_cursor(63, 28);
            Console.WriteLine("Выстрел компьютера:");
        }

        public void InstallationDeck(int letter, int number)
        {
            Set_cursor(letter, number);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("   ");
            Set_cursor(letter, number + 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("   ");
            Console.BackgroundColor = ConsoleColor.Cyan;
        }

        public void WriteWarningOrError(string text, string typeOfNotice)
        {
            if (typeOfNotice == "Error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (typeOfNotice == "Warning")
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void InstallShot(int letter, int number, string result)
        {
            if (result == "Попал")
            {
                Set_cursor(letter, number);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("   ");
                Set_cursor(letter, number + 1);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("   ");
            }
            else if (result == "Мимо")
            {
                Set_cursor(letter, number);
                Console.WriteLine("XXX");
            }
            Console.BackgroundColor = ConsoleColor.Cyan;
        }

        public void Set_cursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}