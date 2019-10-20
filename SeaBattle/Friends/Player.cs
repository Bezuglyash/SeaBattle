using System;
using System.Collections.Generic;

namespace SeaBattle
{
    class Player : GameSpace, IGame
    {
        private ConsoleInterface playerInterface;
        private List<string> playerMap; // Координаты игрока
        private List<int> playerNumberCoordinates; // Номера координат игрока
        private string[] coordinatesOfShipsPlayer; // 
        private int countPlayerShips;
        private int playerNumberCoordinate; // Координата игрока
        private int directionPlayerShip;
        private string noticeText;

        public Player()
        {
            playerInterface = new ConsoleInterface();
            playerMap = new List<string>
            {
                "А1", "Б1", "В1", "Г1", "Д1", "Е1", "Ж1", "З1", "И1", "К1",
                "А2", "Б2", "В2", "Г2", "Д2", "Е2", "Ж2", "З2", "И2", "К2",
                "А3", "Б3", "В3", "Г3", "Д3", "Е3", "Ж3", "З3", "И3", "К3",
                "А4", "Б4", "В4", "Г4", "Д4", "Е4", "Ж4", "З4", "И4", "К4",
                "А5", "Б5", "В5", "Г5", "Д5", "Е5", "Ж5", "З5", "И5", "К5",
                "А6", "Б6", "В6", "Г6", "Д6", "Е6", "Ж6", "З6", "И6", "К6",
                "А7", "Б7", "В7", "Г7", "Д7", "Е7", "Ж7", "З7", "И7", "К7",
                "А8", "Б8", "В8", "Г8", "Д8", "Е8", "Ж8", "З8", "И8", "К8",
                "А9", "Б9", "В9", "Г9", "Д9", "Е9", "Ж9", "З9", "И9", "К9",
                "А10", "Б10", "В10", "Г10", "Д10", "Е10", "Ж10", "З10", "И10", "К10"
            };
            playerNumberCoordinates = new List<int>
            {
                -1, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
                20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
                30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
                40, 41, 42, 43, 44, 45, 46, 47, 48, 49,
                50, 51, 52, 53, 54, 55, 56, 57, 58, 59,
                60, 61, 62, 63, 64, 65, 66, 67, 68, 69,
                70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
                80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
                90, 91, 92, 93, 94, 95, 96, 97, 98, 99,
            };
            coordinatesOfShipsPlayer = new string[10];
            countPlayerShips = 0;
            playerNumberCoordinate = -1;
            directionPlayerShip = 0;
            noticeText = "";
        }

        public Player (Player playerCopy)
        {
            playerInterface = playerCopy.playerInterface;
            playerMap = playerCopy.playerMap;
            playerNumberCoordinates = playerCopy.playerNumberCoordinates;
            coordinatesOfShipsPlayer = playerCopy.coordinatesOfShipsPlayer;
            countPlayerShips = playerCopy.countPlayerShips;
            playerNumberCoordinate = playerCopy.playerNumberCoordinate;
            directionPlayerShip = playerCopy.directionPlayerShip;
            noticeText = playerCopy.noticeText;
        }

        public string AnswerToMiniGame()
        {
            string variantInMiniGame = "";
            while (variantInMiniGame != "Камень" && variantInMiniGame != "Ножницы" && variantInMiniGame != "Бумага")
            {
                for (int i = 0; i < variantInMiniGame.Length; i++)
                {
                    if (i == 0)
                    {
                        playerInterface.Set_cursor(1, 40);
                        playerInterface.WriteWarningOrError("Ошибка! Неправильный ввод! Попробуйте ещё раз!", "Error");
                    }
                    playerInterface.Set_cursor(12 + i, 7);
                    Console.WriteLine(" ");
                }
                playerInterface.Set_cursor(1, 40);
                Console.WriteLine("                                                                ");
                playerInterface.Set_cursor(12, 7);
                variantInMiniGame = Console.ReadLine();
            }
            return variantInMiniGame;
        }

        public void AlignmentOfTheShips()
        {
            int NumberDecksInShip;
            int CountOneShips = 0;
            int CountTwoShips = 0;
            int CountThreeShips = 0;
            int CountFourShips = 0;
            string Input = "";
            while (countPlayerShips < 10)
            {
                int CountErrorInt = 0;
                int CountErrorString;
                do
                {
                    for (int i = 0; i < Input.Length; i++)
                    {
                        playerInterface.Set_cursor(26 + i, 28);
                        Console.WriteLine(" ");
                    }
                    playerInterface.Set_cursor(22, 29);
                    Console.WriteLine("                                                  ");
                    CountErrorString = 0;
                    if (CountErrorInt > 0)
                    {
                        playerInterface.Set_cursor(1, 40);
                        Console.WriteLine("                                                                                ");
                        playerInterface.Set_cursor(1, 40);
                        noticeText = "Ошибка! Корабли могут иметь только от 1 до 4 палуб! Попробуйте ещё раз!";
                        playerInterface.WriteWarningOrError(noticeText, "Error");
                        for (int i = 0; i < Input.Length; i++)
                        {
                            playerInterface.Set_cursor(26 + i, 28);
                            Console.WriteLine(" ");
                        }
                    }
                    do
                    {
                        if (CountErrorString > 0)
                        {
                            for (int i = 0; i < Input.Length; i++)
                            {
                                playerInterface.Set_cursor(26 + i, 28);
                                Console.WriteLine(" ");
                            }
                            playerInterface.Set_cursor(1, 40);
                            Console.WriteLine("                                                                                ");
                            playerInterface.Set_cursor(1, 40);
                            noticeText = "Ошибка! Нужно вести число от 1 до 4 (включительно)! Попробуйте ещё раз!";
                            playerInterface.WriteWarningOrError(noticeText, "Error");
                        }
                        playerInterface.Set_cursor(26, 28);
                        Input = Console.ReadLine();
                        CountErrorString++;
                    } while (int.TryParse(Input, out NumberDecksInShip) == false);
                    CountErrorInt++;
                } while (NumberDecksInShip < 1 || NumberDecksInShip > 4);
                string coordinate;
                bool isEverythingTrue = false;
                switch (NumberDecksInShip)
                {
                    case 1:
                        {
                            if (CountOneShips < 4)
                            {
                                do
                                {
                                    playerInterface.Set_cursor(22, 29);
                                    Console.WriteLine("                                                  ");
                                    playerInterface.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                                       ");
                                    playerInterface.Set_cursor(1, 40);
                                    noticeText = "Предупреждение! Нужно ввести одну координату от А1 до  К10!";
                                    playerInterface.WriteWarningOrError(noticeText, "Warning");
                                    playerInterface.Set_cursor(22, 29);
                                    coordinate = Console.ReadLine();
                                    int count = 0;
                                    foreach (var checkCoordinate in playerMap)
                                    {
                                        if (checkCoordinate == coordinate)
                                        {
                                            isEverythingTrue = true;
                                            break;
                                        }
                                        count++;
                                    }
                                    if (isEverythingTrue == true)
                                    {
                                        playerNumberCoordinate = count;
                                        if (playerNumberCoordinates[playerNumberCoordinate] != 0 && playerNumberCoordinates[playerNumberCoordinate] != 100)
                                        {
                                            playerNumberCoordinates[playerNumberCoordinate] = 100;
                                            coordinatesOfShipsPlayer[countPlayerShips] = coordinate;
                                            playerInterface.InstallationDeck(playerNumberCoordinate % 10 * 4 + 3, 2 * (playerNumberCoordinate / 10) + 6);
                                            NullCoordinate(1);
                                            CountOneShips++;
                                            countPlayerShips++;
                                        }
                                        else
                                        {
                                            playerInterface.Set_cursor(1, 40);
                                            Console.WriteLine("                                                                                       ");
                                            playerInterface.Set_cursor(1, 40);
                                            noticeText = "Ошибка! Сюда нельзя ставить корабль! Для продолжения нажмите Enter!";
                                            playerInterface.WriteWarningOrError(noticeText, "Error");
                                            isEverythingTrue = false;
                                            playerInterface.Set_cursor(2, 30);
                                            Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        playerInterface.Set_cursor(1, 40);
                                        Console.WriteLine("                                                                                         ");
                                        playerInterface.Set_cursor(1, 40);
                                        noticeText = "Ошибка! Вводить можно только координаты от А1 до К10! Для продолжения нажмите Enter!";
                                        playerInterface.WriteWarningOrError(noticeText, "Error");
                                        playerInterface.Set_cursor(2, 30);
                                        Console.ReadLine();
                                    }
                                } while (isEverythingTrue != true);
                            }
                            else
                            {
                                playerInterface.Set_cursor(1, 40);
                                Console.WriteLine("                                                                                                 ");
                                playerInterface.Set_cursor(1, 40);
                                noticeText = "Ошибка! Вы уже использовали все однопалубные корабли! Попробуйте ещё раз!";
                                playerInterface.WriteWarningOrError(noticeText, "Error");
                            }
                            break;
                        }
                        case 2:
                            {
                                if (CountTwoShips < 3)
                                {
                                    do
                                    {
                                        playerInterface.Set_cursor(22, 29);
                                        Console.WriteLine("                                                               ");
                                        playerInterface.Set_cursor(1, 40);
                                        Console.WriteLine("                                                                                         ");
                                        playerInterface.Set_cursor(1, 40);
                                        noticeText = "Предупреждение! Нужно ввести одну координату от А1 до  К10!";
                                        playerInterface.WriteWarningOrError(noticeText, "Warning");
                                        playerInterface.Set_cursor(22, 29);
                                        coordinate = Console.ReadLine();
                                        int count = 0;
                                        foreach (var checkCoordinate in playerMap)
                                        {
                                            if (checkCoordinate == coordinate)
                                            {
                                                isEverythingTrue = true;
                                                break;
                                            }
                                            count++;
                                        }
                                        if (isEverythingTrue == true)
                                        {
                                            playerNumberCoordinate = count;
                                            if (playerNumberCoordinates[playerNumberCoordinate] != 0 && playerNumberCoordinates[playerNumberCoordinate] != 100)
                                            {
                                                playerInterface.Set_cursor(2, 30);
                                                Console.WriteLine("Введите направление продолжения корабля:");
                                                isEverythingTrue = ComplementTheDeck(NumberDecksInShip);
                                                if (isEverythingTrue == true)
                                                {
                                                    playerNumberCoordinates[playerNumberCoordinate] = 100;
                                                    coordinatesOfShipsPlayer[countPlayerShips] += coordinate;
                                                    playerInterface.InstallationDeck(playerNumberCoordinate % 10 * 4 + 3, 2 * (playerNumberCoordinate / 10) + 6);
                                                    NullCoordinate(2);
                                                    CountTwoShips++;
                                                    countPlayerShips++;
                                                }
                                                else
                                                {
                                                    playerInterface.Set_cursor(1, 40);
                                                    Console.WriteLine("                                                                                       ");
                                                    playerInterface.Set_cursor(1, 40);
                                                    noticeText = "Ошибка! Нельзя в данном месте поставить корабль такой длины! Для продолжения нажмите Enter!";
                                                    playerInterface.WriteWarningOrError(noticeText, "Error");
                                                    playerInterface.Set_cursor(2, 30);
                                                    Console.ReadLine();
                                                }
                                            }
                                            else
                                            {
                                                playerInterface.Set_cursor(1, 40);
                                                Console.WriteLine("                                                                                       ");
                                                playerInterface.Set_cursor(1, 40);
                                                noticeText = "Ошибка! Сюда нельзя ставить корабль! Для продолжения нажмите Enter!";
                                                playerInterface.WriteWarningOrError(noticeText, "Error");
                                                isEverythingTrue = false;
                                                playerInterface.Set_cursor(2, 30);
                                                Console.ReadLine();
                                            }
                                        }
                                        else
                                        {
                                            playerInterface.Set_cursor(1, 40);
                                            Console.WriteLine("                                                                                         ");
                                            playerInterface.Set_cursor(1, 40);
                                            noticeText = "Ошибка! Вводить можно только координаты от А1 до К10! Для продолжения нажмите Enter!";
                                            playerInterface.WriteWarningOrError(noticeText, "Error");
                                            playerInterface.Set_cursor(2, 30);
                                            Console.ReadLine();
                                        }
                                    } while (isEverythingTrue != true);
                                }
                                else
                                {
                                    playerInterface.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                                 ");
                                    playerInterface.Set_cursor(1, 40);
                                    noticeText = "Ошибка! Вы уже использовали все двухпалубные корабли! Попробуйте ещё раз!";
                                    playerInterface.WriteWarningOrError(noticeText, "Error");
                                }
                                playerInterface.Set_cursor(2, 30);
                                Console.WriteLine("                                                            ");
                                break;
                            }
                        case 3:
                            {
                                if (CountThreeShips < 2)
                                {
                                    do
                                    {
                                        playerInterface.Set_cursor(22, 29);
                                        Console.WriteLine("                                                               ");
                                        playerInterface.Set_cursor(1, 40);
                                        Console.WriteLine("                                                                                ");
                                        playerInterface.Set_cursor(1, 40);
                                        noticeText = "Предупреждение! Нужно ввести одну координату от А1 до  К10!";
                                        playerInterface.WriteWarningOrError(noticeText, "Warning");
                                        playerInterface.Set_cursor(22, 29);
                                        coordinate = Console.ReadLine();
                                        int count = 0;
                                        foreach (var checkCoordinate in playerMap)
                                        {
                                            if (checkCoordinate == coordinate)
                                            {
                                                isEverythingTrue = true;
                                                break;
                                            }
                                            count++;
                                        }
                                        if (isEverythingTrue == true)
                                        {
                                            playerNumberCoordinate = count;
                                            if (playerNumberCoordinates[playerNumberCoordinate] != 0 && playerNumberCoordinates[playerNumberCoordinate] != 100)
                                            {
                                                playerInterface.Set_cursor(2, 30);
                                                Console.WriteLine("Введите направление продолжения корабля:");
                                                isEverythingTrue = ComplementTheDeck(NumberDecksInShip);
                                                if (isEverythingTrue == true)
                                                {
                                                    playerNumberCoordinates[playerNumberCoordinate] = 100;
                                                    coordinatesOfShipsPlayer[countPlayerShips] += coordinate;
                                                    playerInterface.InstallationDeck(playerNumberCoordinate % 10 * 4 + 3, 2 * (playerNumberCoordinate / 10) + 6);
                                                    NullCoordinate(3);
                                                    CountThreeShips++;
                                                    countPlayerShips++;
                                                }
                                                else
                                                {
                                                    playerInterface.Set_cursor(1, 40);
                                                    Console.WriteLine("                                                                                       ");
                                                    playerInterface.Set_cursor(1, 40);
                                                    noticeText = "Ошибка! Нельзя в данном месте поставить корабль такой длины! Для продолжения нажмите Enter!";
                                                    playerInterface.WriteWarningOrError(noticeText, "Error");
                                                    playerInterface.Set_cursor(2, 30);
                                                    Console.ReadLine();
                                                }
                                            }
                                            else
                                            {
                                                playerInterface.Set_cursor(1, 40);
                                                Console.WriteLine("                                                                                       ");
                                                playerInterface.Set_cursor(1, 40);
                                                noticeText = "Ошибка! Сюда нельзя ставить корабль! Для продолжения нажмите Enter!";
                                                playerInterface.WriteWarningOrError(noticeText, "Error");
                                                isEverythingTrue = false;
                                                playerInterface.Set_cursor(2, 30);
                                                Console.ReadLine();
                                            }
                                        }
                                    } while (isEverythingTrue != true);
                                }
                                else
                                {
                                    playerInterface.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                                 ");
                                    playerInterface.Set_cursor(1, 40);
                                    noticeText = "Ошибка! Вы уже использовали все трёхпалубные корабли! Попробуйте ещё раз!";
                                    playerInterface.WriteWarningOrError(noticeText, "Error");
                                }
                                playerInterface.Set_cursor(2, 30);
                                Console.WriteLine("                                                            ");
                                break;
                            }
                        case 4:
                            {
                                if (CountFourShips == 0)
                                {
                                    do
                                    {
                                        playerInterface.Set_cursor(22, 29);
                                        Console.WriteLine("                                                               ");
                                        playerInterface.Set_cursor(1, 40);
                                        Console.WriteLine("                                                                                ");
                                        playerInterface.Set_cursor(1, 40);
                                        noticeText = "Предупреждение! Нужно ввести одну координату от А1 до  К10!";
                                        playerInterface.WriteWarningOrError(noticeText, "Warning");
                                        playerInterface.Set_cursor(22, 29);
                                        coordinate = Console.ReadLine();
                                        int count = 0;
                                        foreach (var checkCoordinate in playerMap)
                                        {
                                            if (checkCoordinate == coordinate)
                                            {
                                                isEverythingTrue = true;
                                                break;
                                            }
                                            count++;
                                        }
                                        if (isEverythingTrue == true)
                                        {
                                            playerNumberCoordinate = count;
                                            if (playerNumberCoordinates[playerNumberCoordinate] != 0 && playerNumberCoordinates[playerNumberCoordinate] != 100)
                                            {
                                                playerInterface.Set_cursor(2, 30);
                                                Console.WriteLine("Введите направление продолжения корабля:");
                                                isEverythingTrue = ComplementTheDeck(NumberDecksInShip);
                                                if (isEverythingTrue == true)
                                                {
                                                    playerNumberCoordinates[playerNumberCoordinate] = 100;
                                                    coordinatesOfShipsPlayer[countPlayerShips] += coordinate;
                                                    playerInterface.InstallationDeck(playerNumberCoordinate % 10 * 4 + 3, 2 * (playerNumberCoordinate / 10) + 6);
                                                    NullCoordinate(4);
                                                    CountFourShips++;
                                                    countPlayerShips++;
                                                }
                                                else
                                                {
                                                    playerInterface.Set_cursor(1, 40);
                                                    Console.WriteLine("                                                                                       ");
                                                    playerInterface.Set_cursor(1, 40);
                                                    noticeText = "Ошибка! Нельзя в данном месте поставить корабль такой длины! Для продолжения нажмите Enter!";
                                                    playerInterface.WriteWarningOrError(noticeText, "Error");
                                                    playerInterface.Set_cursor(2, 30);
                                                    Console.ReadLine();
                                                }
                                            }
                                            else
                                            {
                                                playerInterface.Set_cursor(1, 40);
                                                Console.WriteLine("                                                                                       ");
                                                playerInterface.Set_cursor(1, 40);
                                                noticeText = "Ошибка! Сюда нельзя ставить корабль! Для продолжения нажмите Enter!";
                                                playerInterface.WriteWarningOrError(noticeText, "Error");
                                                isEverythingTrue = false;
                                                playerInterface.Set_cursor(2, 30);
                                                Console.ReadLine();
                                            }
                                        }
                                    } while (isEverythingTrue != true);
                                }
                                else
                                {
                                    playerInterface.Set_cursor(1, 40);
                                    Console.WriteLine("                                                                                                 ");
                                    playerInterface.Set_cursor(1, 40);
                                    noticeText = "Ошибка! Вы уже использовали все четырёхпалубные корабли! Попробуйте ещё раз!";
                                    playerInterface.WriteWarningOrError(noticeText, "Error");
                                }
                                playerInterface.Set_cursor(2, 30);
                                Console.WriteLine("                                                            ");
                                break;
                            }
                }
            }
            playerInterface.Set_cursor(2, 28);
            Console.WriteLine("                                                                                   ");
            playerInterface.Set_cursor(2, 29);
            Console.WriteLine("                                                                                   ");
            playerInterface.Set_cursor(2, 30);
            Console.WriteLine("                                                                                   ");
            playerInterface.Set_cursor(1, 40);
            Console.WriteLine("                                                                                                 ");
        }

        public bool ComplementTheDeck(int length)
        {
            int SideOfTheRoad;
            bool CheckNull = false;
            int NumberOfAttempts = 0;
            int i;
            string CheckSideOfTheRoad;
            do
            {
                i = 1;
                playerInterface.Set_cursor(1, 40);
                Console.WriteLine("                                                                                                   ");
                playerInterface.Set_cursor(1, 40);
                noticeText = "Предупреждение! Введите число от 1 до 4, чтобы компьютер сам расставил оставшиеся палубы!";
                playerInterface.WriteWarningOrError(noticeText, "Warning");
                playerInterface.Set_cursor(1, 41);
                Console.WriteLine("                                                                                         ");
                playerInterface.Set_cursor(1, 41);
                noticeText = "1 - вверх, 2 - вправо, 3 - вниз, 4 - влево";
                playerInterface.WriteWarningOrError(noticeText, "Warning");
                do
                {
                    playerInterface.Set_cursor(43, 30);
                    CheckSideOfTheRoad = Console.ReadLine();
                    if (int.TryParse(CheckSideOfTheRoad, out SideOfTheRoad) == false)
                    {
                        playerInterface.Set_cursor(1, 40);
                        Console.WriteLine("                                                                                         ");
                        playerInterface.Set_cursor(1, 40);
                        noticeText = "Ошибка! Нужно вести число от 1 до 4! Для продолжения нажмите Enter!";
                        playerInterface.WriteWarningOrError(noticeText, "Error");
                        playerInterface.Set_cursor(2, 31);
                        Console.ReadLine();
                        playerInterface.Set_cursor(43, 30);
                        Console.WriteLine("                             ");
                    }
                    else
                    {
                        if (SideOfTheRoad < 1 || SideOfTheRoad > 4)
                        {
                            playerInterface.Set_cursor(1, 40);
                            Console.WriteLine("                                                                                         ");
                            playerInterface.Set_cursor(1, 40);
                            noticeText = "Ошибка! Нужно вести из диапазона от 1 до 4! Для продолжения нажмите Enter!";
                            playerInterface.WriteWarningOrError(noticeText, "Error");
                            playerInterface.Set_cursor(2, 31);
                            Console.ReadLine();
                            playerInterface.Set_cursor(43, 30);
                            Console.WriteLine("                             ");
                        }
                    }
                } while (SideOfTheRoad < 1 || SideOfTheRoad > 4);
                if (SideOfTheRoad == 1)
                {
                    directionPlayerShip = -10;
                }
                else if (SideOfTheRoad == 2)
                {
                    directionPlayerShip = 1;
                }
                else if (SideOfTheRoad == 3)
                {
                    directionPlayerShip = 10;
                }
                else if (SideOfTheRoad == 4)
                {
                    directionPlayerShip = -1;
                }
                while (i < length)
                {
                    if (playerNumberCoordinate + directionPlayerShip * i >= 0 && playerNumberCoordinate + directionPlayerShip * i <= 99)
                    {
                        if (playerNumberCoordinates[playerNumberCoordinate + directionPlayerShip * i] != 0 && playerNumberCoordinates[playerNumberCoordinate + directionPlayerShip * i] != 100)
                        {
                            if (directionPlayerShip == -1 || directionPlayerShip == 1)
                            {
                                if ((playerNumberCoordinate + directionPlayerShip * (i - 1)) / 10 == (playerNumberCoordinate + directionPlayerShip * i) / 10)
                                {
                                    CheckNull = true;
                                }
                                else
                                {
                                    CheckNull = false;
                                    i = length;
                                }
                            }
                            else
                            {
                                CheckNull = true;
                            }
                        }
                        else
                        {
                            CheckNull = false;
                            i = length;
                        }
                    }
                    else
                    {
                        CheckNull = false;
                        i = length;
                    }
                    i++;
                }
                if (CheckNull == true)
                {
                    i = 1;
                    while(i < length)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + directionPlayerShip * i] = 100;
                        coordinatesOfShipsPlayer[countPlayerShips] = coordinatesOfShipsPlayer[countPlayerShips] + playerMap[playerNumberCoordinate + directionPlayerShip * i];
                        playerInterface.InstallationDeck((playerNumberCoordinate + directionPlayerShip * i) % 10 * 4 + 3, 2 * ((playerNumberCoordinate + directionPlayerShip * i) / 10) + 6);
                        i++;
                    }
                }
                else
                {
                    playerInterface.Set_cursor(1, 40);
                    Console.WriteLine("                                                                                         ");
                    playerInterface.Set_cursor(1, 40);
                    noticeText = "Ошибка! В эту сторону нельзя расставить такое количество палуб! Для продолжения нажмите Enter!";
                    playerInterface.WriteWarningOrError(noticeText, "Error");
                    playerInterface.Set_cursor(2, 31);
                    Console.ReadLine();
                    playerInterface.Set_cursor(43, 30);
                    Console.WriteLine("                             ");
                }
                NumberOfAttempts++;
            } while (CheckNull != true && NumberOfAttempts != 5);
            playerInterface.Set_cursor(1, 40);
            Console.WriteLine("                                                                                                   ");
            playerInterface.Set_cursor(1, 41);
            Console.WriteLine("                                                                                         ");
            if (NumberOfAttempts == 5 && CheckNull == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void NullCoordinate(int CountDeck)
        {
            int i = 0;
            while (i < CountDeck)
            {
                if ((playerNumberCoordinate + directionPlayerShip * i) % 10 == 0 && playerNumberCoordinate + directionPlayerShip * i != 0 && playerNumberCoordinate + directionPlayerShip * i != 90)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] = 0;
                    }
                }
                else if (playerNumberCoordinate + directionPlayerShip * i == 0)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] = 0;
                    }
                }
                else if ((playerNumberCoordinate + directionPlayerShip * i) / 10 == 0 && playerNumberCoordinate + directionPlayerShip * i != 9)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] = 0;
                    }
                }
                else if ((playerNumberCoordinate + directionPlayerShip * i) % 10 == 9 && playerNumberCoordinate + directionPlayerShip * i != 9 && playerNumberCoordinate + directionPlayerShip * i != 99)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] = 0;
                    }
                }
                else if (playerNumberCoordinate + directionPlayerShip * i == 9)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] = 0;
                    }
                }
                else if (playerNumberCoordinate + directionPlayerShip * i == 90)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] = 0;
                    }
                }
                else if ((playerNumberCoordinate + directionPlayerShip * i) / 10 == 9 && playerNumberCoordinate + directionPlayerShip * i != 99)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] = 0;
                    }
                }
                else if (playerNumberCoordinate + directionPlayerShip * i == 99)
                {
                    if (playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] = 0;
                    }
                }
                else
                {
                    if (playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 10 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 1 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 11 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 9 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate - 9 + directionPlayerShip * i] = 0;
                    }

                    if (playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] != 100)
                    {
                        playerNumberCoordinates[playerNumberCoordinate + 11 + directionPlayerShip * i] = 0;
                    }
                }
                i++;
            }
        }

        public string MakeShot(out int numberCoordinateShot, out int time)
        {
            string coordinateShotPlayer;
            int indexThisCoordinate;
            do
            {
                playerInterface.Set_cursor(15, 28);
                coordinateShotPlayer = Console.ReadLine();
                indexThisCoordinate = -1;
                int count = 0;
                foreach (var oneCoordinatePlayerMap in playerMap)
                {
                    if (coordinateShotPlayer == oneCoordinatePlayerMap)
                    {
                        indexThisCoordinate = count;
                        break;
                    }
                    count++;
                }
                if (indexThisCoordinate == -1)
                {
                    playerInterface.Set_cursor(1, 40);
                    noticeText = "Ошибка! Такой координаты не сущестует или по ней уже был проведен выстрел! Внимательнее";
                    playerInterface.WriteWarningOrError(noticeText, "Error");
                    for (int i = 0; i < coordinateShotPlayer.Length; i++)
                    {
                        playerInterface.Set_cursor(15 + i, 28);
                        Console.WriteLine(" ");
                    }
                }
            } while (indexThisCoordinate == -1);
            numberCoordinateShot = indexThisCoordinate;
            playerMap[indexThisCoordinate] = "SB";
            for (int i = 0; i < noticeText.Length; i++)
            {
                playerInterface.Set_cursor(1 + i, 40);
                Console.WriteLine(" ");
            }
            time = 0;
            return coordinateShotPlayer;
        }

        public bool CheckTheShips(string coordinate, out int resultGameOfThisShot)
        {
            int lengthShip = 0;
            int lengthDeck = coordinate.Length;
            int index = -1;
            int count = 0;
            foreach(var oneShip in coordinatesOfShipsPlayer)
            {
                index = oneShip.IndexOf(coordinate);
                if (index != -1)
                {
                    if (coordinate.Length == 2 && coordinate[1] == '1' && oneShip.Length > index + 2)
                    {
                        if (oneShip[index + 2] != '0')
                        {
                            lengthShip = oneShip.Length;
                            break;
                        }
                        else
                        {
                            index = -1;
                        }
                    }
                    else
                    {
                        lengthShip = oneShip.Length;
                        break;
                    }
                }
                count++;
            }
            if (index == -1)
            {
                resultGameOfThisShot = 3;
                return false;
            }
            else
            {
                if (coordinatesOfShipsPlayer[count] == coordinate)
                {
                    coordinatesOfShipsPlayer[count] = "";
                    int countZeroString = 0;
                    foreach (var oneShip in coordinatesOfShipsPlayer)
                    {
                        if (oneShip.Length == 0)
                        {
                            countZeroString++;
                        }
                    }
                    if (countZeroString == 10)
                    {
                        resultGameOfThisShot = 0;
                        return true;
                    }
                    else
                    {
                        resultGameOfThisShot = 1;
                        return true;
                    }
                }
                else
                {
                    string checkString = coordinatesOfShipsPlayer[count];
                    coordinatesOfShipsPlayer[count] = "";
                    for (int i = 0; i < index; i++)
                    {
                        coordinatesOfShipsPlayer[count] += Convert.ToString(checkString[i]);
                    }
                    for (int i = lengthDeck + index; i < lengthShip; i++)
                    {
                        coordinatesOfShipsPlayer[count] += Convert.ToString(checkString[i]);
                    }
                    resultGameOfThisShot = 2;
                    return true;
                }
            }
        }
    }
}