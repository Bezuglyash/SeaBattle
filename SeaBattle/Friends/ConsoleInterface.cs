using System;
using System.Media;
using System.Threading;

namespace SeaBattle
{
    public class ConsoleInterface
    {
        public void Get_start()
        {
            Console.Clear();
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
            Console.WriteLine("______________________________________________");
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

        public void Instruction()
        {
            Console.Clear();
            Set_cursor(48, 0);
            Console.WriteLine("Инструкция");
            Set_cursor(1, 1);
            Console.WriteLine("Добро пожаловать в приложение \"Морской бой\"! Здесь Вы увидите основное руководтсво по приложению:");
            Set_cursor(1, 2);
            Console.WriteLine("1) При работе с меню нужно всегда писать цифру соответствующую пункту, который вам нужен.");
            Set_cursor(1, 3);
            Console.WriteLine("2) В окне \"Примечание\" выводятся подсказки, предупреждения, ошибки и ход выполнения программы.");
            Set_cursor(1, 4);
            Console.WriteLine("3) Для того, чтобы играть в игру, нужно создать аккаунт или, если таковой уже есть, войти в него.");
            Set_cursor(1, 5);
            Console.WriteLine("4) Для того, чтобы определить, кто первым сделает ход, нужно сыграть в мини-игру \"Цу-е-фа\".");
            Set_cursor(4, 6);
            Console.WriteLine("Компьютер Ваш ход НЕ ВИДИТ!");
            Set_cursor(1, 7);
            Console.WriteLine("5) Компьютер автоматически расставляет свои корабли с учётом всех правил, игрок - самостоятельно!");
            Set_cursor(4, 8);
            Console.WriteLine("Сначала игрок должен выбрать размер корабля, а потом написать координату.");
            Set_cursor(4, 9);
            Console.WriteLine("Если размер корабля больше 1, то игрок должен выбрать, в какую сторону продолжить корабль.");
            Set_cursor(4, 10);
            Console.WriteLine("Дальше программа самостоятельно расставляет корабль на поле! КОРАБЛЬ НЕ ВИДИТ РАССТАНОВКИ ИГРОКА!");
            Set_cursor(1, 11);
            Console.WriteLine("6) Компьютер ходит самостоятельно, игрок должен ввести координату поля.");
            Set_cursor(4, 12);
            Console.WriteLine("\"***\" - промах. Действующие корабли отмечены черными квадратами, потопленные корабли - красным.");
            Set_cursor(4, 13);
            Console.WriteLine("При ходе игрока компьютер отвечает сообщением, чтобы игрок понимал - попал ли он.");
            Set_cursor(1, 14);
            Console.WriteLine("7) В конце игры нужно подождать несколько секунд, а потом будет предложено продолжить действия!");
            Set_cursor(4, 15);
            Console.WriteLine("Работает рейтинговая система, а потому, при новом рейтинге, будет выведено соответствующее сообщение!");
            Set_cursor(1, 16);
            Console.WriteLine("8) Можно посмотреть свои данные по играм, а также изменить свой ник, логин или пароль.");
            Set_cursor(1, 17);
            WriteWarningOrError("9) Заходите! Играйте! Кайфуйте!", "Warning");
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
            Set_cursor(1, 40);
            Console.WriteLine("Для продолжения нажмите Enter!");
            Set_cursor(1, 41);
        }

        public void AccountMenu(string nick)
        {
            Console.Clear();
            Set_cursor(38, 0);
            Console.WriteLine("Привет, " + nick + "!");
            Set_cursor(38, 1);
            Console.WriteLine("_____________________________");
            Set_cursor(47, 3);
            Console.WriteLine("1 - Игра");
            Set_cursor(47, 5);
            Console.WriteLine("2 - Данные");
            Set_cursor(47, 7);
            Console.WriteLine("3 - Выход");
            Set_cursor(38, 8);
            Console.WriteLine("_____________________________");
            Set_cursor(38, 10);
            Console.WriteLine("Ваш выбор: ");
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

        public void DataGraphicInterface(string login, string pin, string name, string rank, long numberGames, long numberWins, float percent)
        {
            Console.Clear();
            int y = 0;
            for(int i = 0; i < 2; i++)
            {
                Set_cursor(34, 0 + y);
                Console.WriteLine("____________________________________");
                y += 4;
            }
            Set_cursor(34, 20);
            Console.WriteLine("____________________________________");
            for (int i = 0; i < 36; i++)
            {
                Set_cursor(33, 1 + i);
                Console.WriteLine("|");
                Set_cursor(70, 1 + i);
                Console.WriteLine("|");
            }

            for (int i = 0; i < 12; i++)
            {
                Set_cursor(49, 5 + i);
                Console.WriteLine("|");
            }
            for (int i = 0; i < 16; i++)
            {
                Set_cursor(49, 21 + i);
                Console.WriteLine("|");
            }
            y = 0;
            for (int i = 0; i < 3; i++)
            {
                Set_cursor(34, 8 + y);
                Console.WriteLine("_______________");
                Set_cursor(50, 8 + y);
                Console.WriteLine("____________________");
                y += 4;
            }
            y = 0;
            for (int i = 0; i < 4; i++)
            {
                Set_cursor(34, 24 + y);
                Console.WriteLine("_______________");
                Set_cursor(50, 24 + y);
                Console.WriteLine("____________________");
                y += 4;
            }
            Set_cursor(44, 2);
            Console.WriteLine("ДАННЫЕ АККАУНТА");
            Set_cursor(46, 18);
            Console.WriteLine("ДАННЫЕ ИГРЫ");
            Set_cursor(35, 6);
            Console.WriteLine("Логин");
            Set_cursor(35, 10);
            Console.WriteLine("Пароль");
            Set_cursor(35, 14);
            Console.WriteLine("Ник");
            Set_cursor(35, 22);
            Console.WriteLine("Звание");
            Set_cursor(35, 26);
            Console.WriteLine("Кол-во игр");
            Set_cursor(35, 30);
            Console.WriteLine("Кол-во побед");
            Set_cursor(35, 34);
            Console.WriteLine("Процент побед");
            Set_cursor(51, 6);
            Console.WriteLine(login);
            Set_cursor(51, 10);
            Console.WriteLine(pin);
            Set_cursor(51, 14);
            Console.WriteLine(name);
            Set_cursor(51, 22);
            Console.WriteLine(rank);
            Set_cursor(51, 26);
            Console.WriteLine(numberGames);
            Set_cursor(51, 30);
            Console.WriteLine(numberWins);
            Set_cursor(51, 34);
            Console.WriteLine(percent);

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
            Set_cursor(1, 40);
            WriteWarningOrError("Можно изменить данные аккаунта нажав 1, 2 или 3", "Warning");
            Set_cursor(1, 41);
            WriteWarningOrError("1 - логин, 2 - пароль, 3 - ник, остальное - переход к меню", "Warning");
            Set_cursor(1, 1);
            Console.WriteLine("Ваш выбор:");
        }

        public void ExitInterface()
        {
            Console.Clear();
            Set_cursor(44, 22);
            Console.WriteLine("Выполняется выход!");
            Thread.Sleep(3000);
        }

        public void InstructionsForTheMiniGame()
        {
            Console.Clear();
            Set_cursor(48, 0);
            Console.WriteLine("Мини-игра");
            Set_cursor(1, 1);
            Console.WriteLine("Результат мини-игры решает, чей ход будет первым. Сама игра называется \"Цу-е-фа\".");
            Set_cursor(1, 2);
            Console.WriteLine("Напоминаем правила:");
            Set_cursor(2, 3);
            Console.WriteLine("1) Похоже на игру в реальности, но здесь нужно просто написать один из 3 вариантов хода.");
            Set_cursor(1, 4);
            Console.WriteLine("Варианты: камень, ножницы, бумага.");
            Set_cursor(2, 5);
            Console.WriteLine("2) Компьютер НЕ ВИДИТ Вашего хода, а так же записывает свой вариант.");
            Set_cursor(1, 6);
            Console.WriteLine("По сути, это аналог записок, которые потом раскрываются, и выводится результат.");
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
            Set_cursor(1, 40);
            WriteWarningOrError("Если ознакомились, нажмите Enter", "Warning");
            Set_cursor(1, 41);
        }

        public void MiniGamePlatform()
        {
            Console.Clear();
            Set_cursor(48, 0);
            Console.WriteLine("Мини-игра");
            Set_cursor(1, 7);
            Console.WriteLine("Ваш ответ:");
            Set_cursor(69, 7);
            Console.WriteLine("Ответ компьютера:");
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
            Set_cursor(51, 1);
            Thread.Sleep(500);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("ЦУ");
            Set_cursor(51, 3);
            Thread.Sleep(500);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Е");
            Set_cursor(51, 5);
            Thread.Sleep(500);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("ФА");
            Console.BackgroundColor = ConsoleColor.Cyan;
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

        public void WinGame()
        {
            Set_cursor(43, 27);
            Console.WriteLine("                       ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Set_cursor(45, 19);
            Console.WriteLine("ВЫ ПОБЕДИЛИ!");
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < 103; i++)
                {
                    Set_cursor(1 + i, 31);
                    Console.WriteLine(" ");
                    Set_cursor(1 + i, 32);
                    Console.WriteLine(".");
                    Set_cursor(1 + i, 33);
                    Console.WriteLine(" ");
                }
                int x = 0;
                for (int i = 0; i < 11; i++)
                {
                    Set_cursor(1 + x, 32);
                    Console.WriteLine("ПОБЕДА!!!");
                    Thread.Sleep(1200);
                    Set_cursor(1 + x, 32);
                    Console.WriteLine(".........");
                    x += 9;
                }
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public void LoseGame()
        {
            Set_cursor(43, 27);
            Console.WriteLine("                       ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Set_cursor(45, 19);
            Console.WriteLine("ВЫ ПРОИГРАЛИ!");
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 0; i < 103; i++)
                {
                    Set_cursor(1 + i, 31);
                    Console.WriteLine(" ");
                    Set_cursor(1 + i, 32);
                    Console.WriteLine(".");
                    Set_cursor(1 + i, 33);
                    Console.WriteLine(" ");
                }
                int x = 0;
                for (int i = 0; i < 11; i++)
                {
                    Set_cursor(1 + x, 32);
                    Console.WriteLine("ПОРАЖЕНИЕ");
                    Thread.Sleep(1200);
                    Set_cursor(1 + x, 32);
                    Console.WriteLine(".........");
                    x += 9;
                }
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        public void IncreaseRankGui(string nickname, string rankThis, int musicOnOrOff = 1)
        {
            Console.Clear();
            Set_cursor(36, 14);
            Console.WriteLine("__________________________________");
            Console.BackgroundColor = ConsoleColor.White;
            Set_cursor(36, 19);
            Console.WriteLine("__________________________________");
            Console.BackgroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 5; i++)
            {
                Set_cursor(35, 15 + i);
                Console.WriteLine("|");
                Set_cursor(70, 15 + i);
                Console.WriteLine("|");
            }
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < 34; i++)
            {
                Set_cursor(36 + i, 15);
                Console.WriteLine(" ");
                Set_cursor(36 + i, 16);
                Console.WriteLine(" ");
                Set_cursor(36 + i, 17);
                Console.WriteLine(" ");
                Set_cursor(36 + i, 18);
                Console.WriteLine(" ");
            }
            Set_cursor(36, 15);
            Console.WriteLine("Добрый день, " + nickname + "!");
            Set_cursor(36, 16);
            Console.WriteLine("Поздравляем Вас с повышением!");
            Set_cursor(36, 17);
            Console.WriteLine("Вам присвоено следующее звание:");
            Set_cursor(36, 18);
            Console.WriteLine(rankThis + "!");
            Console.BackgroundColor = ConsoleColor.Cyan;
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
            if (musicOnOrOff == 0)
            {
                SoundPlayer youngLSound = new SoundPlayer(Properties.Resources.YoungL);
                youngLSound.Play();
            }
            Set_cursor(1, 40);
            WriteWarningOrError("Для продолжения нажмите Enter", "Warning");
        }

        public void DecreaseRankGui(string nickname, string rankThis)
        {
            Console.Clear();
            Set_cursor(36, 14);
            Console.WriteLine("__________________________________");
            Console.BackgroundColor = ConsoleColor.White;
            Set_cursor(36, 19);
            Console.WriteLine("__________________________________");
            Console.BackgroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 5; i++)
            {
                Set_cursor(35, 15 + i);
                Console.WriteLine("|");
                Set_cursor(70, 15 + i);
                Console.WriteLine("|");
            }
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < 34; i++)
            {
                Set_cursor(36 + i, 15);
                Console.WriteLine(" ");
                Set_cursor(36 + i, 16);
                Console.WriteLine(" ");
                Set_cursor(36 + i, 17);
                Console.WriteLine(" ");
                Set_cursor(36 + i, 18);
                Console.WriteLine(" ");
            }
            Set_cursor(36, 15);
            Console.WriteLine("Добрый день, " + nickname + "!");
            Set_cursor(36, 16);
            Console.WriteLine("Увы, но Вас понизили в должности.");
            Set_cursor(36, 17);
            Console.WriteLine("Вам присвоено следующее звание:");
            Set_cursor(36, 18);
            Console.WriteLine(rankThis + "!");
            Console.BackgroundColor = ConsoleColor.Cyan;
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
            Set_cursor(1, 40);
            WriteWarningOrError("Для продолжения нажмите Enter", "Warning");
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