using System;

namespace SeaBattle
{
    public class GameSpace
    {
        protected string Login;
        protected string Password;
        protected string Nick;
        ConsoleInterface WorkConsole = new ConsoleInterface();
        private Computer computer = new Computer();
        private Player player = new Player();
        public void Get_start(int number_operation)
        {
            GameLogic Logic = new GameLogic();
            switch (number_operation)
            {
                case 1:
                    {
                        WorkConsole.Input();
                        bool check = false;
                        do
                        {
                            WorkConsole.Set_cursor(49, 3);
                            Login = Console.ReadLine();
                            WorkConsole.Set_cursor(49, 6);
                            Password = Console.ReadLine();
                            check = Logic.Checking_login(Login);
                            if (check == false)
                            {
                                WorkConsole.Set_cursor(73, 3);
                                Console.WriteLine("Неправильный логин!");
                                for(int i = 0; i < Login.Length; i++)
                                {
                                    WorkConsole.Set_cursor(49 + i, 3);
                                    Console.WriteLine(" ");
                                }
                            }
                            else
                            {
                                check = Logic.Checking_password(Password);
                                if (check == false)
                                {
                                    WorkConsole.Set_cursor(73, 6);
                                    Console.WriteLine("Неправильный пароль!");
                                    for (int i = 0; i < Login.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(49 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                }
                            }
                        } while (check != true);
                        Console.Clear();
                        WorkConsole.Set_cursor(45, 24);
                        Console.WriteLine("...Ожидание...");
                        Nick = Logic.GetNick();
                        Account();
                        break;
                    }
                case 2:
                    {
                        WorkConsole.Registration();
                        bool check = true;
                        int number_string_of_error = 0;
                        do
                        {
                            if (number_string_of_error == 0)
                            {
                                WorkConsole.Set_cursor(42, 3);
                                Nick = Console.ReadLine();
                                WorkConsole.Set_cursor(42, 6);
                                Login = Console.ReadLine();
                                WorkConsole.Set_cursor(42, 9);
                                Password = Console.ReadLine();
                            }
                            else if (number_string_of_error == 1)
                            {
                                WorkConsole.Set_cursor(42, 3);
                                Nick = Console.ReadLine();
                            }
                            else if (number_string_of_error == 2)
                            {
                                WorkConsole.Set_cursor(42, 6);
                                Login = Console.ReadLine();
                            }
                            else if (number_string_of_error == 3)
                            {
                                WorkConsole.Set_cursor(42, 9);
                                Password = Console.ReadLine();
                            }
                            check = Logic.Checking_scan(12, Nick);
                            if (check == false)
                            {
                                WorkConsole.Set_cursor(27, 12);
                                Console.WriteLine("Ошибка! Имя не должно быть больше 12 символов!");
                                WorkConsole.Set_cursor(27, 13);
                                Console.WriteLine("Для новой попытки нажмите Enter!");
                                Console.ReadLine();
                                number_string_of_error = 1;
                                WorkConsole.Set_cursor(42, 3);
                                for (int i = 0; i < Nick.Length; i++)
                                {
                                    WorkConsole.Set_cursor(42 + i, 3);
                                    Console.WriteLine(" ");
                                }
                                WorkConsole.Set_cursor(27, 12);
                                Console.WriteLine("                                              ");
                                WorkConsole.Set_cursor(27, 13);
                                Console.WriteLine("                                ");
                            }
                            else
                            {
                                check = Logic.Checking_scan(19, Login);
                                if (check == false)
                                {
                                    WorkConsole.Set_cursor(27, 12);
                                    Console.WriteLine("Ошибка! Логин не должен быть больше 19 символов!");
                                    WorkConsole.Set_cursor(27, 13);
                                    Console.WriteLine("Для новой попытки нажмите Enter!");
                                    Console.ReadLine();
                                    number_string_of_error = 2;
                                    WorkConsole.Set_cursor(42, 6);
                                    for (int i = 0; i < Login.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(42 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                    WorkConsole.Set_cursor(27, 12);
                                    Console.WriteLine("                                                ");
                                    WorkConsole.Set_cursor(27, 13);
                                    Console.WriteLine("                                ");
                                }
                                else
                                {
                                    check = Logic.Checking_scan(19, Password);
                                    if (check == false)
                                    {
                                        WorkConsole.Set_cursor(27, 12);
                                        Console.WriteLine("Ошибка! Пароль не должен быть больше 19 символов!");
                                        WorkConsole.Set_cursor(27, 13);
                                        Console.WriteLine("Для новой попытки нажмите Enter!");
                                        Console.ReadLine();
                                        number_string_of_error = 3;
                                        WorkConsole.Set_cursor(42, 9);
                                        for (int i = 0; i < Password.Length; i++)
                                        {
                                            WorkConsole.Set_cursor(42 + i, 9);
                                            Console.WriteLine(" ");
                                        }
                                        WorkConsole.Set_cursor(27, 12);
                                        Console.WriteLine("                                                 ");
                                        WorkConsole.Set_cursor(27, 13);
                                        Console.WriteLine("                                ");
                                    }
                                    else
                                    {
                                        WorkConsole.Set_cursor(26, 12);
                                        Console.WriteLine("Подтверждаете операцию?(Для сохранения ответьте Да, для изменения данных - Нет)");
                                        WorkConsole.Set_cursor(26, 13);
                                        Console.WriteLine("Ответ:");
                                        WorkConsole.Set_cursor(33, 13);
                                        string answer = Console.ReadLine();
                                        if (answer == "Да")
                                        {
                                            check = true;
                                        }
                                        else if (answer == "Нет")
                                        {
                                            check = false;
                                            WorkConsole.Set_cursor(42, 3);
                                            for (int i = 0; i < Nick.Length; i++)
                                            {
                                                WorkConsole.Set_cursor(42 + i, 3);
                                                Console.WriteLine(" ");
                                            }
                                            WorkConsole.Set_cursor(42, 6);
                                            for (int i = 0; i < Login.Length; i++)
                                            {
                                                WorkConsole.Set_cursor(42 + i, 6);
                                                Console.WriteLine(" ");
                                            }
                                            WorkConsole.Set_cursor(42, 9);
                                            for (int i = 0; i < Password.Length; i++)
                                            {
                                                WorkConsole.Set_cursor(42 + i, 9);
                                                Console.WriteLine(" ");
                                            }
                                            number_string_of_error = 0;
                                            WorkConsole.Set_cursor(27, 20);
                                            for (int i = 0; i < Password.Length; i++)
                                            {
                                                WorkConsole.Set_cursor(27 + i, 20);
                                                Console.WriteLine(" ");
                                            }
                                            WorkConsole.Set_cursor(26, 12);
                                            Console.WriteLine("                                                                                   ");
                                            WorkConsole.Set_cursor(26, 13);
                                            Console.WriteLine("        ");
                                            WorkConsole.Set_cursor(33, 13);
                                            for (int i = 0; i < answer.Length; i++)
                                            {
                                                WorkConsole.Set_cursor(33 + i, 13);
                                                Console.WriteLine(" ");
                                            }
                                        }
                                        else
                                        {
                                            WorkConsole.Set_cursor(26, 14);
                                            Console.WriteLine("Ошибка ввода!");
                                            WorkConsole.Set_cursor(26, 15);
                                            Console.WriteLine("Для новой попытки нажмите Enter!");
                                            Console.ReadLine();
                                            WorkConsole.Set_cursor(26, 12);
                                            Console.WriteLine("                                                                                  ");
                                            WorkConsole.Set_cursor(33, 13);
                                            for (int i = 0; i < answer.Length; i++)
                                            {
                                                WorkConsole.Set_cursor(33 + i, 13);
                                                Console.WriteLine(" ");
                                            }
                                            WorkConsole.Set_cursor(26, 14);
                                            Console.WriteLine("             ");
                                            WorkConsole.Set_cursor(26, 15);
                                            Console.WriteLine("                                ");
                                            number_string_of_error = 4;
                                            check = false;
                                        }
                                    }
                                }
                            }
                        } while (check != true);
                        Console.Clear();
                        WorkConsole.Set_cursor(45, 24);
                        Console.WriteLine("...Ожидание...");
                        Logic.SavingData(Nick, Login, Password);
                        Account();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }
        }
        public void Account()
        {
            bool check = false;
            string change;
            do
            {
                WorkConsole.AccountMenu(Nick);
                WorkConsole.Set_cursor(49, 10);
                change = Console.ReadLine();
                if (change != "1" && change != "2" && change != "3")
                {
                    WorkConsole.Set_cursor(38, 11);
                    Console.WriteLine("Ошибка ввода! Для повторения нажмите Enter");
                    Console.ReadLine();
                    WorkConsole.Set_cursor(38, 11);
                    Console.WriteLine("                                          ");                   
                    for (int i = 0; i < change.Length; i++)
                    {
                        WorkConsole.Set_cursor(49 + i, 10);
                        Console.WriteLine(" ");
                    }
                }
                else
                {
                    switch(Convert.ToInt32(change))
                    {
                        case 1:
                            {
                                Game();
                                break;
                            }
                        case 2:
                            {
                                Settings();
                                break;
                            }
                        case 3:
                            {
                                check = Exit();
                                break;
                            }
                    }
                }
            } while (check != true);
        }
        public void Game()
        {
            WorkConsole.GamePlatform();
            //computer.alignment_of_the_ships();
        }
        public void Settings()
        {

        }
        public bool Exit()
        {
            return true;
        }
    }
}