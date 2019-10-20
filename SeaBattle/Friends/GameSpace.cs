using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Threading;

namespace SeaBattle
{
    class GameSpace
    {
        private string login;
        private string password;
        private string nick;
        private string rank;
        private long numberGames;
        private long numberWins;
        private int percentOfWins;
        private long numberDefeatsConsecutive;
        private ConsoleInterface workConsole;
        private Logic logic;
        private string textMessage;
        private SoundPlayer shotSound;
        private SoundPlayer winSound;
        private SoundPlayer loseSound;

        public GameSpace()
        {
            login = "";
            password = "";
            workConsole = new ConsoleInterface();
            logic = new Logic();
            textMessage = "";
            shotSound = new SoundPlayer(Properties.Resources.Shot);
            winSound = new SoundPlayer(Properties.Resources.Win);
            loseSound = new SoundPlayer(Properties.Resources.Lose);
        }

        public void Get_start(int number_operation, ref int result)
        {
            switch (number_operation)
            {
                case 1:
                    {
                        workConsole.Input();
                        bool check = false;
                        do
                        {
                            workConsole.Set_cursor(49, 3);
                            login = Console.ReadLine();
                            workConsole.Set_cursor(49, 6);
                            password = Console.ReadLine();
                            int loginOrPassword;
                            check = logic.CheckingLoginAndPassword(login, password, out loginOrPassword);
                            if (check == false)
                            {
                                if (loginOrPassword == 0)
                                {
                                    workConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                ");
                                    workConsole.Set_cursor(1, 40); 
                                    textMessage = "Ошибка! Нет никаких данных!";
                                    workConsole.WriteWarningOrError(textMessage, "Error");
                                    for (int i = 0; i < login.Length; i++)
                                    {
                                        workConsole.Set_cursor(49 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    for (int i = 0; i < password.Length; i++)
                                    {
                                        workConsole.Set_cursor(49 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                }
                                else if (loginOrPassword == 1)
                                {
                                    workConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                ");
                                    workConsole.Set_cursor(1, 40);
                                    textMessage = "Ошибка! Неправильный логин или пароль!";
                                    workConsole.WriteWarningOrError(textMessage, "Error");
                                    for (int i = 0; i < login.Length; i++)
                                    {
                                        workConsole.Set_cursor(49 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    for (int i = 0; i < password.Length; i++)
                                    {
                                        workConsole.Set_cursor(49 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                }
                                else if (loginOrPassword == 2)
                                {
                                    workConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                ");
                                    workConsole.Set_cursor(1, 40);
                                    textMessage = "Ошибка! Неправильный логин или пароль!";
                                    workConsole.WriteWarningOrError(textMessage, "Error");
                                    for (int i = 0; i < login.Length; i++)
                                    {
                                        workConsole.Set_cursor(49 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    for (int i = 0; i < password.Length; i++)
                                    {
                                        workConsole.Set_cursor(49 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                }
                            }
                            else
                            {
                                workConsole.Set_cursor(1, 40);
                                Console.WriteLine("                                                                                ");
                                workConsole.Set_cursor(1, 40);
                                textMessage = "Успешная авторизация! Для продолжения нажмите любую клавишу!";
                                workConsole.WriteWarningOrError(textMessage, "Warning");
                                workConsole.Set_cursor(62, 40);
                                Console.ReadLine();
                            }
                        } while (check != true);
                        Console.Clear();
                        workConsole.Set_cursor(45, 19);
                        Console.WriteLine("...Ожидание...");
                        GetNickPlayer();
                        GetRankPlayer();
                        GetNumberGamesPlayer();
                        GetNumberWinsPlayer();
                        GetPercentOfWinsPlayer();
                        GetNumberDefeats();
                        Account();
                        result = 1;
                        break;
                    }
                case 2:
                    {
                        workConsole.Registration();
                        bool check = true;
                        int number_string_of_error = 0;
                        do
                        {
                            if (number_string_of_error == 0)
                            {
                                workConsole.Set_cursor(1, 40);
                                textMessage = "Предупреждение! Имя не должно превышать 12 символов!";
                                workConsole.WriteWarningOrError(textMessage, "Warning");
                                workConsole.Set_cursor(42, 3);
                                nick = Console.ReadLine();

                                workConsole.Set_cursor(1, 40);
                                Console.WriteLine("                                                                                      ");
                                workConsole.Set_cursor(1, 40);
                                textMessage = "Предупреждение! Логин не должен превышать 19 символов!";
                                workConsole.WriteWarningOrError(textMessage, "Warning");
                                workConsole.Set_cursor(42, 6);
                                login = Console.ReadLine();

                                workConsole.Set_cursor(1, 40);
                                Console.WriteLine("                                                                                      ");
                                workConsole.Set_cursor(1, 40);
                                textMessage = "Предупреждение! Пароль не должен превышать 19 символов!";
                                workConsole.WriteWarningOrError(textMessage, "Warning");
                                workConsole.Set_cursor(42, 9);
                                password = Console.ReadLine();
                            }
                            else if (number_string_of_error == 1)
                            {
                                workConsole.Set_cursor(42, 3);
                                nick = Console.ReadLine();
                            }
                            else if (number_string_of_error == 2)
                            {
                                workConsole.Set_cursor(42, 6);
                                login = Console.ReadLine();
                            }
                            else if (number_string_of_error == 3)
                            {
                                workConsole.Set_cursor(42, 9);
                                password = Console.ReadLine();
                            }
                            int numberErrorOrComplete;
                            check = logic.CheckingScan(nick, login, password, out numberErrorOrComplete);
                            workConsole.Set_cursor(1, 40);
                            if (check == false)
                            {
                                if (numberErrorOrComplete == 4)
                                {
                                    textMessage = "Ошибка! Такой логин уже зарегистрирован! Для продолжения нажмите любую клавишу!";
                                    workConsole.WriteWarningOrError(textMessage, "Error");
                                    workConsole.Set_cursor(81, 40);
                                    Console.ReadLine();
                                    workConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < login.Length; i++)
                                    {
                                        workConsole.Set_cursor(42 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 2;
                                }
                                else if (numberErrorOrComplete == 1)
                                {
                                    textMessage = "Ошибка! Имя не должно превышать 12 символов! Для продолжения нажмите любую клавишу!";
                                    workConsole.WriteWarningOrError(textMessage, "Error");
                                    workConsole.Set_cursor(86, 40);
                                    Console.ReadLine();
                                    workConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < nick.Length; i++)
                                    {
                                        workConsole.Set_cursor(42 + i, 3);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 1;
                                }
                                else if (numberErrorOrComplete == 2)
                                {
                                    textMessage = "Ошибка! Логин не должен превышать 19 символов! Для продолжения нажмите любую клавишу!";
                                    workConsole.WriteWarningOrError(textMessage, "Error");
                                    workConsole.Set_cursor(88, 40);
                                    Console.ReadLine();
                                    workConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < login.Length; i++)
                                    {
                                        workConsole.Set_cursor(42 + i, 6);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 2;
                                }
                                else
                                {
                                    textMessage = "Ошибка! Пароль не должен превышать 19 символов! Для продолжения нажмите любую клавишу!";
                                    workConsole.WriteWarningOrError(textMessage, "Error");
                                    workConsole.Set_cursor(89, 40);
                                    Console.ReadLine();
                                    workConsole.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                      ");
                                    for (int i = 0; i < password.Length; i++)
                                    {
                                        workConsole.Set_cursor(42 + i, 9);
                                        Console.WriteLine(" ");
                                    }
                                    number_string_of_error = 3;
                                }
                            }
                            else
                            {
                                textMessage = "Регистрация прошла успешна! Для продолжения нажмите любую клавишу!";
                                workConsole.WriteWarningOrError(textMessage, "Warning");
                                workConsole.Set_cursor(68, 40);
                                Console.ReadLine();
                            }
                        } while (check != true);
                        Console.Clear();
                        workConsole.Set_cursor(45, 19);
                        Console.WriteLine("...Ожидание...");
                        logic.SavingNewAccountData(nick, login, password);
                        GetRankPlayer();
                        GetNumberGamesPlayer();
                        GetNumberWinsPlayer();
                        GetPercentOfWinsPlayer();
                        GetNumberDefeats();
                        Account();
                        result = 1;
                        break;
                    }
                case 3:
                    {
                        workConsole.Instruction();
                        Console.ReadLine();
                        result = 0;
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
                workConsole.AccountMenu(nick);
                workConsole.Set_cursor(49, 10);
                change = Console.ReadLine();
                if (change != "1" && change != "2" && change != "3")
                {
                    workConsole.Set_cursor(1, 40);
                    workConsole.WriteWarningOrError("Ошибка ввода! Для повторения нажмите Enter", "Error");
                    workConsole.Set_cursor(1, 41);
                    Console.ReadLine();
                    workConsole.Set_cursor(1, 40);
                    Console.WriteLine("                                          ");                   
                    for (int i = 0; i < change.Length; i++)
                    {
                        workConsole.Set_cursor(49 + i, 10);
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
                                Data();
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
            workConsole.GamePlatform();
            workConsole.Set_cursor(2, 1);
            Console.WriteLine(nick);
            computer.AlignmentOfTheShips();
            player.AlignmentOfTheShips();
            workConsole.Fight();
            string shot = "";
            while (true)
            {
                int coordinate;
                int timeReflection;
                int resultOfShot;
                if (nameProgress == "Компьютер")
                {
                    shot = computer.MakeShot(out coordinate, out timeReflection);
                    workConsole.Set_cursor(1, 40);
                    Console.WriteLine("Ожидание компьютера...");
                    workConsole.Set_cursor(83, 31);
                    Thread.Sleep(timeReflection);
                    shotSound.Play();
                    workConsole.Set_cursor(83, 28);
                    Console.WriteLine("   ");
                    workConsole.Set_cursor(83, 28);
                    Console.WriteLine(shot);
                    workConsole.Set_cursor(1, 40);
                    Console.WriteLine("                      ");
                    player.CheckTheShips(shot, out resultOfShot);
                    if (resultOfShot == 0 || resultOfShot == 1 || resultOfShot == 2)
                    {
                        workConsole.InstallShot(coordinate % 10 * 4 + 3, 2 * (coordinate / 10) + 6, "Попал");
                        if(resultOfShot == 0)
                        {
                            workConsole.Set_cursor(63, 29);
                            Console.WriteLine("Говорит компьютер:");
                            for (int i = 0; i < 21; i++)
                            {
                                workConsole.Set_cursor(82 + i, 29);
                                Console.WriteLine(" ");
                            }
                            workConsole.Set_cursor(82, 29);
                            Thread.Sleep(1000);
                            textMessage = computer.GetMessage("Проиграл");
                            Console.WriteLine(textMessage);
                            Thread threadLoseGame = new Thread(new ThreadStart(workConsole.LoseGame));
                            threadLoseGame.Start();
                            loseSound.Play();
                            IncrementNumberGames();
                            NewPercentWins();
                            Thread.Sleep(24000);
                            workConsole.Set_cursor(1, 40);
                            Console.WriteLine("Для продолжения нажмите Enter");
                            Console.ReadLine();
                            threadLoseGame.Abort();
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            IncrementNumberDefeatsConsecutive();
                            break;
                        }
                    }
                    else
                    {
                        workConsole.InstallShot(coordinate % 10 * 4 + 3, 2 * (coordinate / 10) + 6, "Мимо");
                    }
                    computer.InformationAboutShot(resultOfShot);
                    if (resultOfShot == 3)
                    {
                        nameProgress = "Игрок";
                    }
                }
                else
                {
                    workConsole.Set_cursor(15, 28);
                    Console.WriteLine("     ");
                    shot = player.MakeShot(out coordinate, out timeReflection);
                    shotSound.Play();
                    computer.CheckTheShips(shot, out resultOfShot);
                    workConsole.Set_cursor(63, 29);
                    Console.WriteLine("Говорит компьютер:");
                    for (int i = 0; i < 21; i++)
                    {
                        workConsole.Set_cursor(82 + i, 29);
                        Console.WriteLine(" ");
                    }
                    if (resultOfShot == 1 || resultOfShot == 2 || resultOfShot == 3)
                    {
                        workConsole.InstallShot((coordinate % 10 * 4 + 3) + 60, 2 * (coordinate / 10) + 6, "Попал");
                        if (resultOfShot == 1)
                        {
                            textMessage = computer.GetMessage("Попал");
                            workConsole.Set_cursor(82, 29);
                            Console.WriteLine(textMessage);
                        }
                        else if (resultOfShot == 2)
                        {
                            textMessage = computer.GetMessage("Убил");
                            workConsole.Set_cursor(82, 29);
                            Console.WriteLine(textMessage);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            textMessage = computer.GetMessage("Победил");
                            workConsole.Set_cursor(82, 29);
                            Console.WriteLine(textMessage);
                            Thread threadWinGame = new Thread(new ThreadStart(workConsole.WinGame));
                            threadWinGame.Start();
                            winSound.Play();
                            IncrementNumberGames();
                            Thread.Sleep(24000);
                            workConsole.Set_cursor(1, 40);
                            Console.WriteLine("Для продолжения нажмите Enter");
                            Console.ReadLine();
                            threadWinGame.Abort();
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            IncrementNumberWins();
                            NewPercentWins();
                            break;
                        }
                    }
                    else
                    {
                        textMessage = computer.GetMessage("Мимо");
                        workConsole.Set_cursor(82, 29);
                        Console.WriteLine(textMessage);
                        nameProgress = "Компьютер";
                        workConsole.InstallShot((coordinate % 10 * 4 + 3) + 60, 2 * (coordinate / 10) + 6, "Мимо");
                    }
                }
            }
            logic.UpdateData();
        }

        public void Data()
        {
            workConsole.DataGraphicInterface(login, password, nick, rank, numberGames, numberWins, percentOfWins);
            workConsole.Set_cursor(12, 1);
            string choice = Console.ReadLine();
            workConsole.Set_cursor(1, 40);
            Console.WriteLine("                                                        ");
            workConsole.Set_cursor(1, 41);
            Console.WriteLine("                                                          ");
            if (choice == "1")
            {
                for (int i = 0; i < login.Length; i++)
                {
                    workConsole.Set_cursor(51 + i, 6);
                    Console.WriteLine(" ");
                }
                workConsole.Set_cursor(1, 40);
                workConsole.WriteWarningOrError("Введите новый логин!", "Warning");
                workConsole.Set_cursor(51, 6);
                login = Console.ReadLine();
                logic.SetNewLogin(login);
            }
            else if (choice == "2")
            {
                for (int i = 0; i < password.Length; i++)
                {
                    workConsole.Set_cursor(51 + i, 10);
                    Console.WriteLine(" ");
                }
                workConsole.Set_cursor(1, 40);
                workConsole.WriteWarningOrError("Введите новый пароль!", "Warning");
                workConsole.Set_cursor(51, 10);
                password = Console.ReadLine();
                logic.SetNewPassword(password);
            }
            else if (choice == "3")
            {
                for (int i = 0; i < nick.Length; i++)
                {
                    workConsole.Set_cursor(51 + i, 14);
                    Console.WriteLine(" ");
                }
                workConsole.Set_cursor(1, 40);
                workConsole.WriteWarningOrError("Введите новый ник!", "Warning");
                workConsole.Set_cursor(51, 14);
                nick = Console.ReadLine();
                logic.SetNewNickname(nick);
            }
            if (choice == "1" || choice == "2" || choice == "3")
            {
                workConsole.Set_cursor(1, 40);
                Console.WriteLine("                                                        ");
                workConsole.Set_cursor(1, 40);
                workConsole.WriteWarningOrError("Выполняется сохранение! Пожалуйста, подождите!", "Warning");
                Thread.Sleep(2000);
            }
        }

        public bool Exit()
        {
            workConsole.ExitInterface();
            logic.ExitDataBase();
            return true;
        }

        public string MiniGame(Player playerMiniGame, Computer computerMiniGame)
        {
            do
            {
                workConsole.InstructionsForTheMiniGame();
                Console.ReadLine();
                workConsole.MiniGamePlatform();
                string answerPlayer = playerMiniGame.AnswerToMiniGame();
                string answerComputer = computerMiniGame.AnswerToMiniGame();
                workConsole.Set_cursor(87, 7);
                Console.WriteLine(answerComputer);
                workConsole.Set_cursor(1, 40);
                if (answerPlayer == "Камень")
                {
                    if (answerComputer == "Ножницы")
                    {
                        workConsole.WriteWarningOrError("По результату игры " + nick + " ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Игрок";
                    }
                    else if (answerComputer == "Бумага")
                    {
                        workConsole.WriteWarningOrError("По результату игры Компьютер ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Компьютер";
                    }
                }
                else if (answerPlayer == "Ножницы")
                {
                    if (answerComputer == "Бумага")
                    {
                        workConsole.WriteWarningOrError("По результату игры " + nick + " ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Игрок";
                    }
                    else if (answerComputer == "Камень")
                    {
                        workConsole.WriteWarningOrError("По результату игры Компьютер ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Компьютер";
                    }
                }
                else
                {
                    if (answerComputer == "Камень")
                    {
                        workConsole.WriteWarningOrError("По результату игры " + nick + " ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Игрок";
                    }
                    else if (answerComputer == "Ножницы")
                    {
                        workConsole.WriteWarningOrError("По результату игры Компьютер ходит первым!", "Warning");
                        Thread.Sleep(1400);
                        return "Компьютер";
                    }
                }
                workConsole.WriteWarningOrError("Ничья - ожидайте повторения!", "Error");
                Thread.Sleep(1400);
            } while (true);
        }

        public void GetNickPlayer()
        {
            nick = logic.GetNick();
        }

        public void GetRankPlayer()
        {
            rank = logic.GetRank();
        }

        public void GetNumberGamesPlayer()
        {
            numberGames = logic.GetNumberGames();
        }

        public void GetNumberWinsPlayer()
        {
            numberWins = logic.GetNumberWins();
        }

        public void GetPercentOfWinsPlayer()
        {
            percentOfWins = logic.GetPercentOfWins();
        }

        public void GetNumberDefeats()
        {
            numberDefeatsConsecutive = logic.GetNumberDefeatsConsecutive();
        }

        public void IncrementNumberGames()
        {
            numberGames++;
            logic.SetNewNumberOfGames(numberGames);
        }

        public void IncrementNumberWins()
        {
            if (numberDefeatsConsecutive == 0 || numberDefeatsConsecutive == 1 || numberDefeatsConsecutive == 2)
            {
                numberWins++;
                logic.SetNewNumberOfWins(numberWins);
                if (numberDefeatsConsecutive > 0)
                {
                    numberDefeatsConsecutive--;
                    logic.SetNewNumberDefeatsConsecutive(numberDefeatsConsecutive);
                }
                IncreaseRank();
            }
            else
            {
                numberWins++;
                logic.SetNewNumberOfWins(numberWins);
                if ((numberDefeatsConsecutive - 1) % 3 == 0)
                {
                    IncreaseRank();
                }
                numberDefeatsConsecutive--;
                logic.SetNewNumberDefeatsConsecutive(numberDefeatsConsecutive);
            }
        }

        public void IncrementNumberDefeatsConsecutive()
        {
            numberDefeatsConsecutive++;
            if (numberDefeatsConsecutive % 3 == 0)
            {
                DecreaseRank();
            }
            logic.SetNewNumberDefeatsConsecutive(numberDefeatsConsecutive);
        }

        public void NewPercentWins()
        {
            double calculation = (double)numberWins / numberGames * 100;
            var beforeDot = Math.Truncate(calculation);
            double afterDot = calculation - beforeDot;
            if (afterDot >= 0.5)
            {
                percentOfWins = (int)calculation + 1;
            }
            else
            {
                percentOfWins = (int)calculation;
            }
            logic.SetNewPercentWins(percentOfWins);
        }

        public void IncreaseRank()
        {
            string potentialRank;
            if (numberWins < 12)
            {
                potentialRank = "Матрос";
            }
            else if (numberWins < 19 || (rank == "Матрос" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Старший матрос";
            }
            else if (numberWins < 28 || (rank == "Старший матрос" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Старшина";
            }
            else if (numberWins < 55 || (rank == "Старшина" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Мичман";
            }
            else if (numberWins < 67 || (rank == "Мичман" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Младший лейтенант";
            }
            else if (numberWins < 80 || (rank == "Маладший лейтенант" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Старший лейтенант";
            }
            else if (numberWins < 127 || (rank == "Старший лейтенант" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Капитан";
            }
            else if (numberWins < 167 || (rank == "Капитан" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Вице-адмирал";
            }
            else if (numberWins < 228 || (rank == "Вице-адмирал" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Адмирал";
            }
            else if (numberWins >= 228 || (rank == "Адмирал" && (numberDefeatsConsecutive - 1) % 3 == 0) && (numberDefeatsConsecutive - 1) != 0)
            {
                potentialRank = "Адмирал флота";
            }
            else
            {
                potentialRank = rank;
            }

            if (rank != potentialRank)
            {
                rank = potentialRank;
                if (rank == "Младший лейтенант")
                {
                    logic.SetNewRank(rank);
                    workConsole.IncreaseRankGui(nick, rank, 0);
                }
                else
                {
                    logic.SetNewRank(rank);
                    workConsole.IncreaseRankGui(nick, rank);
                }
                workConsole.Set_cursor(1, 41);
                Console.ReadLine();
            }
        }

        public void DecreaseRank()
        {
            if (this.rank != "Матрос")
            {
                if (this.rank == "Старший матрос")
                {
                    rank = "Матрос";
                }
                else if (this.rank == "Старшина")
                {
                    rank = "Старший матрос";
                }
                else if (this.rank == "Мичман")
                {
                    rank = "Старшина";
                }
                else if (this.rank == "Младший лейтенант")
                {
                    rank = "Мичман";
                }
                else if (this.rank == "Старший лейтенант")
                {
                    rank = "Младший лейтенант";
                }
                else if (this.rank == "Капитан")
                {
                    rank = "Старший лейтенант";
                }
                else if (this.rank == "Вице-адмирал")
                {
                    rank = "Капитан";
                }
                else if (this.rank == "Адмирал")
                {
                    rank = "Вице-адмирал";
                }
                else if (this.rank == "Адмирал флота")
                {
                    rank = "Адмирал";
                }
                logic.SetNewRank(rank);
                workConsole.DecreaseRankGui(nick, rank);
                workConsole.Set_cursor(1, 41);
                Console.ReadLine();
            }
        }
    }
}