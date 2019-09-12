using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading;

namespace SeaBattle
{
    class GameSpace
    {
        private string Login;
        private string Password;
        private string Nick;
        private string Rank;
        private long NumberGames;
        private long NumberWins;
        private double PercentOfWins;
        private ConsoleInterface WorkConsole;
        private Logic logic;
        private string textMessage;
        private SoundPlayer shotSound;
        private SoundPlayer winSound;

        public GameSpace()
        {
            Login = "";
            Password = "";
            WorkConsole = new ConsoleInterface();
            logic = new Logic();
            textMessage = "";
            shotSound = new SoundPlayer(Properties.Resources.Shot);
            winSound = new SoundPlayer(Properties.Resources.Win);
        }

        public void Get_start(int number_operation)
        {
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
                            int loginOrPassword;
                            check = logic.Checking_login_and_password(Login, Password, out loginOrPassword);
                            if (check == false)
                            {
                                if (loginOrPassword == 0)
                                {
                                    WorkConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                ");
                                    WorkConsole.Set_cursor(1, 40); 
                                    textMessage = "Ошибка! Нет никаких данных!";
                                    WorkConsole.WriteWarningOrError(textMessage, "Error");
                                    for (int i = 0; i < Login.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(49 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    for (int i = 0; i < Password.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(49 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                }
                                else if (loginOrPassword == 1)
                                {
                                    WorkConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                ");
                                    WorkConsole.Set_cursor(1, 40);
                                    textMessage = "Ошибка! Неправильный логин!";
                                    WorkConsole.WriteWarningOrError(textMessage, "Error");
                                    for (int i = 0; i < Login.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(49 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    for (int i = 0; i < Password.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(49 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                }
                                else if (loginOrPassword == 2)
                                {
                                    WorkConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                ");
                                    WorkConsole.Set_cursor(1, 40);
                                    textMessage = "Ошибка! Неправильный пароль!";
                                    WorkConsole.WriteWarningOrError(textMessage, "Error");
                                    for (int i = 0; i < Login.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(49 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    for (int i = 0; i < Password.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(49 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                }
                            }
                            else
                            {
                                WorkConsole.Set_cursor(1, 40);
                                Console.WriteLine("                                                                                ");
                                WorkConsole.Set_cursor(1, 40);
                                textMessage = "Успешная авторизация! Для продолжения нажмите любую клавишу!";
                                WorkConsole.WriteWarningOrError(textMessage, "Warning");
                                WorkConsole.Set_cursor(62, 40);
                                Console.ReadLine();
                            }
                        } while (check != true);
                        Console.Clear();
                        WorkConsole.Set_cursor(45, 19);
                        Console.WriteLine("...Ожидание...");
                        GetNickPlayer();
                        GetRankPlayer();
                        GetNumberGamesPlayer();
                        GetNumberWinsPlayer();
                        GetPercentOfWinsPlayer();
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
                                WorkConsole.Set_cursor(1, 40);
                                textMessage = "Предупреждение! Имя не должно превышать 12 символов!";
                                WorkConsole.WriteWarningOrError(textMessage, "Warning");
                                WorkConsole.Set_cursor(42, 3);
                                Nick = Console.ReadLine();

                                WorkConsole.Set_cursor(1, 40);
                                Console.WriteLine("                                                                                      ");
                                WorkConsole.Set_cursor(1, 40);
                                textMessage = "Предупреждение! Логин не должен превышать 19 символов!";
                                WorkConsole.WriteWarningOrError(textMessage, "Warning");
                                WorkConsole.Set_cursor(42, 6);
                                Login = Console.ReadLine();

                                WorkConsole.Set_cursor(1, 40);
                                Console.WriteLine("                                                                                      ");
                                WorkConsole.Set_cursor(1, 40);
                                textMessage = "Предупреждение! Пароль не должен превышать 19 символов!";
                                WorkConsole.WriteWarningOrError(textMessage, "Warning");
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
                            int numberErrorOrComplete;
                            check = logic.Checking_scan(Nick, Login, Password, out numberErrorOrComplete);
                            WorkConsole.Set_cursor(1, 40);
                            if (check == false)
                            {
                                if (numberErrorOrComplete == 4)
                                {
                                    textMessage = "Ошибка! Такой логин уже зарегистрирован! Для продолжения нажмите любую клавишу!";
                                    WorkConsole.WriteWarningOrError(textMessage, "Error");
                                    WorkConsole.Set_cursor(81, 40);
                                    Console.ReadLine();
                                    WorkConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < Login.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(42 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 2;
                                }
                                else if (numberErrorOrComplete == 1)
                                {
                                    textMessage = "Ошибка! Имя не должно превышать 12 символов! Для продолжения нажмите любую клавишу!";
                                    WorkConsole.WriteWarningOrError(textMessage, "Error");
                                    WorkConsole.Set_cursor(86, 40);
                                    Console.ReadLine();
                                    WorkConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < Nick.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(42 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 1;
                                }
                                else if (numberErrorOrComplete == 2)
                                {
                                    textMessage = "Ошибка! Логин не должен превышать 19 символов! Для продолжения нажмите любую клавишу!";
                                    WorkConsole.WriteWarningOrError(textMessage, "Error");
                                    WorkConsole.Set_cursor(88, 40);
                                    Console.ReadLine();
                                    WorkConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < Login.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(42 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 2;
                                }
                                else
                                {
                                    textMessage = "Ошибка! Пароль не должен превышать 19 символов! Для продолжения нажмите любую клавишу!";
                                    WorkConsole.WriteWarningOrError(textMessage, "Error");
                                    WorkConsole.Set_cursor(89, 40);
                                    Console.ReadLine();
                                    WorkConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < Password.Length; i++)
                                    {
                                        WorkConsole.Set_cursor(42 + i, 9);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 3;
                                }
                            }
                            else
                            {
                                textMessage = "Регистрация прошла успешна! Для продолжения нажмите любую клавишу!";
                                WorkConsole.WriteWarningOrError(textMessage, "Warning");
                                WorkConsole.Set_cursor(68, 40);
                                Console.ReadLine();
                            }
                        } while (check != true);
                        Console.Clear();
                        WorkConsole.Set_cursor(45, 19);
                        Console.WriteLine("...Ожидание...");
                        logic.SavingNewAccountData(Nick, Login, Password);
                        GetRankPlayer();
                        GetNumberGamesPlayer();
                        GetNumberWinsPlayer();
                        GetPercentOfWinsPlayer();
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
                    WorkConsole.Set_cursor(1, 40);
                    WorkConsole.WriteWarningOrError("Ошибка ввода! Для повторения нажмите Enter", "Error");
                    WorkConsole.Set_cursor(1, 41);
                    Console.ReadLine();
                    WorkConsole.Set_cursor(1, 40);
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
            Player player = new Player();
            Computer computer = new Computer();
            string nameProgress = MiniGame(player, computer);
            WorkConsole.GamePlatform();
            WorkConsole.Set_cursor(2, 1);
            Console.WriteLine(Nick);
            computer.AlignmentOfTheShips();
            player.AlignmentOfTheShips();
            WorkConsole.Fight();
            string shot = "";
            while (true)
            {
                int coordinate;
                int timeReflection;
                int resultOfShot;
                if (nameProgress == "Компьютер")
                {
                    shot = computer.MakeShot(out coordinate, out timeReflection);
                    WorkConsole.Set_cursor(1, 40);
                    Console.WriteLine("Ожидание компьютера...");
                    WorkConsole.Set_cursor(83, 31);
                    Thread.Sleep(timeReflection);
                    shotSound.Play();
                    WorkConsole.Set_cursor(83, 28);
                    Console.WriteLine("   ");
                    WorkConsole.Set_cursor(83, 28);
                    Console.WriteLine(shot);
                    WorkConsole.Set_cursor(1, 40);
                    Console.WriteLine("                      ");
                    player.CheckTheShips(shot, out resultOfShot);
                    if (resultOfShot == 0 || resultOfShot == 1 || resultOfShot == 2)
                    {
                        WorkConsole.InstallShot(coordinate % 10 * 4 + 3, 2 * (coordinate / 10) + 6, "Попал");
                        if(resultOfShot == 0)
                        {
                            WorkConsole.Set_cursor(63, 29);
                            Console.WriteLine("Говорит компьютер:");
                            for (int i = 0; i < 21; i++)
                            {
                                WorkConsole.Set_cursor(82 + i, 29);
                                Console.WriteLine(" ");
                            }
                            WorkConsole.Set_cursor(82, 29);
                            textMessage = computer.getMessage("Проиграл");
                            Console.WriteLine(textMessage);
                            WorkConsole.LoseGame();
                            WorkConsole.Set_cursor(1, 40);
                            Console.WriteLine("Для продолжения нажмите Enter");
                            WorkConsole.Set_cursor(31, 40);
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
                    {
                        WorkConsole.InstallShot(coordinate % 10 * 4 + 3, 2 * (coordinate / 10) + 6, "Мимо");
                    }
                    computer.InformationAboutShot(resultOfShot);
                    if (resultOfShot == 3)
                    {
                        nameProgress = "Игрок";
                    }
                }
                else
                {
                    WorkConsole.Set_cursor(15, 28);
                    Console.WriteLine("     ");
                    shot = player.MakeShot(out coordinate, out timeReflection);
                    shotSound.Play();
                    computer.CheckTheShips(shot, out resultOfShot);
                    WorkConsole.Set_cursor(63, 29);
                    Console.WriteLine("Говорит компьютер:");
                    for (int i =0; i < 21; i++)
                    {
                        WorkConsole.Set_cursor(82 + i, 29);
                        Console.WriteLine(" ");
                    }
                    WorkConsole.Set_cursor(82, 29);
                    if (resultOfShot == 1 || resultOfShot == 2 || resultOfShot == 3)
                    {
                        if (resultOfShot == 1)
                        {
                            textMessage = computer.getMessage("Попал");
                            Console.WriteLine(textMessage);
                        }
                        else if (resultOfShot == 2)
                        {
                            textMessage = computer.getMessage("Убил");
                            Console.WriteLine(textMessage);
                        }
                        else
                        {
                            textMessage = computer.getMessage("Победил");
                            Console.WriteLine(textMessage);
                            Thread threadWinGame = new Thread(new ThreadStart(WorkConsole.WinGame));
                            threadWinGame.Start();
                            winSound.Play();
                            WorkConsole.Set_cursor(1, 40);
                            Console.WriteLine("Для продолжения нажмите Enter");
                            WorkConsole.Set_cursor(31, 40);
                            Console.ReadLine();
                            break;
                        }
                        WorkConsole.InstallShot((coordinate % 10 * 4 + 3) + 60, 2 * (coordinate / 10) + 6, "Попал");
                    }
                    else
                    {
                        textMessage = computer.getMessage("Мимо");
                        Console.WriteLine(textMessage);
                        nameProgress = "Компьютер";
                        WorkConsole.InstallShot((coordinate % 10 * 4 + 3) + 60, 2 * (coordinate / 10) + 6, "Мимо");
                    }
                }
            }

        }

        public void Settings()
        {

        }

        public bool Exit()
        {
            return true;
        }

        public string MiniGame(Player playerMiniGame, Computer computerMiniGame)
        {
            do
            {
                WorkConsole.InstructionsForTheMiniGame();
                Console.ReadLine();
                WorkConsole.MiniGamePlatform();
                string answerPlayer = playerMiniGame.AnswerToMiniGame();
                string answerComputer = computerMiniGame.AnswerToMiniGame();
                WorkConsole.Set_cursor(87, 7);
                Console.WriteLine(answerComputer);
                WorkConsole.Set_cursor(1, 40);
                if (answerPlayer == "Камень")
                {
                    if (answerComputer == "Ножницы")
                    {
                        WorkConsole.WriteWarningOrError("По результату игры " + Nick + " ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Игрок";
                    }
                    else if (answerComputer == "Бумага")
                    {
                        WorkConsole.WriteWarningOrError("По результату игры Computer ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Компьютер";
                    }
                }
                else if (answerPlayer == "Ножницы")
                {
                    if (answerComputer == "Бумага")
                    {
                        WorkConsole.WriteWarningOrError("По результату игры " + Nick + " ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Игрок";
                    }
                    else if (answerComputer == "Камень")
                    {
                        WorkConsole.WriteWarningOrError("По результату игры Computer ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Компьютер";
                    }
                }
                else
                {
                    if (answerComputer == "Камень")
                    {
                        WorkConsole.WriteWarningOrError("По результату игры " + Nick + " ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Игрок";
                    }
                    else if (answerComputer == "Ножницы")
                    {
                        WorkConsole.WriteWarningOrError("По результату игры Computer ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Компьютер";
                    }
                }
                WorkConsole.WriteWarningOrError("Ничья - ожидайте повторения!", "Error");
                Thread.Sleep(1400);
            } while (true);
        }

        public void GetNickPlayer()
        {
            Nick = logic.GetNick();
        }

        public void GetRankPlayer()
        {
            Rank = logic.GetRank();
        }

        public void GetNumberGamesPlayer()
        {
            NumberGames = logic.GetNumberGames();
        }

        public void GetNumberWinsPlayer()
        {
            NumberWins = logic.GetNumberWins();
        }

        public void GetPercentOfWinsPlayer()
        {
            PercentOfWins = logic.GetPercentOfWins();
        }
    }
}