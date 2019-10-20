using System;
using System.Collections;
using System.Collections.Generic;

namespace SeaBattle
{
    class Computer : IGame
    {
        private string[] coordinatesOfShips; // Расстановка всех кораблей
        private List<string> computerMap; // Координаты компьютера
        private List<int> numberCoordinates; // Соответствующие им номера
        private Random randomize;
        private int numberCoordinate; // Координата компьютера
        private int countShips;
        private int direction;
        private string completeDestructionOfTheShip;
        private int numberCoordinateFirstShot;
        private bool isHitTheTarget;
        private List<int> numberDirection;
        private int countShotForOneShip;
        private List<int> coordinatesKillShips;
        private Hashtable computerMessages;
        private int[] countPlayerShipWhichItNotKill;
        private List<int[]> numbersCoordinatesWhichWarning;

        public Computer()
        {
            coordinatesOfShips = new string [10];
            computerMap = new List<string>
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
            numberCoordinates = new List<int>
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
            randomize = new Random();
            numberCoordinate = 0;
            countShips = 0;
            direction = 0;
            completeDestructionOfTheShip = "off";
            numberCoordinateFirstShot = -1;
            isHitTheTarget = false;
            countShotForOneShip = 0;
            coordinatesKillShips = new List<int>();
            computerMessages = new Hashtable
            {
                { "Я победил!!!", "Проиграл" },
                { "Да-да, я лучший!", "Проиграл" },
                { "Это было легко!", "Проиграл" },
                { "Иди учись, салага!", "Проиграл" },
                { "Историческая победа!", "Проиграл" },
                { "Ха, мимо!", "Мимо" },
                { "Не попал!", "Мимо" },
                { "Так меня не одолеть!", "Мимо" },
                { "А теперь учись!", "Мимо" },
                { "Такому я только рад!", "Мимо" },
                { "Хм... Попал!", "Попал" },
                { "Ранил!", "Попал" },
                { "Повредил одну палубу!", "Попал" },
                { "Ай, ранил!", "Попал" },
                { "Попал!", "Попал" },
                { "Флот терпит потери...", "Убил" },
                { "Убил!", "Убил" },
                { "Минус корабль...", "Убил" },
                { "Корабль повержен!", "Убил" },
                { "Корабль потанул!", "Убил" },
                { "С победой!", "Победил" },
                { "Это только один бой!", "Победил" },
                { "Ещё увидимся...", "Победил" },
                { "Я был близок...", "Победил" },
                { "Буду ждать реванша!", "Победил" }
            };
            countPlayerShipWhichItNotKill = new int[4] { 4, 3, 2, 1 };

            numbersCoordinatesWhichWarning = new List<int[]>
            {
                new int [1] {0},
                new int [1] {9},
                new int [1] {90},
                new int [1] {99}
            };
            int[] massiveOneForEight = new int[8];
            for (int i = 1; i < 9; i++)
            {
                massiveOneForEight[i - 1] = i;
            }
            numbersCoordinatesWhichWarning.Add(massiveOneForEight);
            int[] massiveNineteenForEightyNine = new int[8];
            for (int i = 19; i < 99; i += 10)
            {
                massiveNineteenForEightyNine[(i - 9) / 10 - 1] = i;
            }
            numbersCoordinatesWhichWarning.Add(massiveNineteenForEightyNine);
            int[] massiveNinetyOneForNinetyEight = new int[8];
            for (int i = 91; i < 99; i++)
            {
                massiveNinetyOneForNinetyEight[i - 91] = i;
            }
            numbersCoordinatesWhichWarning.Add(massiveNinetyOneForNinetyEight);
            int[] massiveTenForEighty = new int[8];
            for (int i = 10; i < 90; i += 10)
            {
                massiveTenForEighty[i / 10 - 1] = i;
            }
            numbersCoordinatesWhichWarning.Add(massiveTenForEighty);
        }

        public Computer (Computer computerCopy)
        {
            coordinatesOfShips = computerCopy.coordinatesOfShips;
            computerMap = computerCopy.computerMap;
            numberCoordinates = computerCopy.numberCoordinates;
            randomize = computerCopy.randomize;
            numberCoordinate = computerCopy.numberCoordinate;
            countShips = computerCopy.countShips;
            direction = computerCopy.direction;
            completeDestructionOfTheShip = computerCopy.completeDestructionOfTheShip;
            numberCoordinateFirstShot = computerCopy.numberCoordinateFirstShot;
            isHitTheTarget = computerCopy.isHitTheTarget;
            countShotForOneShip = computerCopy.countShotForOneShip;
            coordinatesKillShips = computerCopy.coordinatesKillShips;
            computerMessages = computerCopy.computerMessages;
        }

        public string AnswerToMiniGame()
        {
            string[] variantsInMiniGame = new string[]
            {
                "Камень",
                "Ножницы",
                "Бумага"
            };
            int index = randomize.Next(0, 3);
            return variantsInMiniGame[index];
        }

        public void AlignmentOfTheShips()
        {
            int SizeShip;
            int CountOneShips = 0;
            int CountTwoShips = 0;
            int CountThreeShips = 0;
            int CountFourShips = 0;
            bool IsCorrectCoordinate;
            while (countShips != 10)
            {
                SizeShip = randomize.Next(1, 5);
                switch (SizeShip)
                {
                    case 1:
                        {
                            if (CountOneShips < 4)
                            {
                                do
                                {
                                    numberCoordinate = randomize.Next(0, numberCoordinates.Count);
                                    if (numberCoordinates[numberCoordinate] != 0 && numberCoordinates[numberCoordinate] != 100)
                                    {
                                        numberCoordinates[numberCoordinate] = 100;
                                        coordinatesOfShips[countShips] = computerMap[numberCoordinate];
                                        NullCoordinate(1);
                                        countShips++;
                                        CountOneShips++;
                                        IsCorrectCoordinate = true;
                                    }
                                    else
                                    {
                                        IsCorrectCoordinate = false;
                                    }
                                } while (IsCorrectCoordinate != true);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (CountTwoShips < 3)
                            {
                                do
                                {

                                    numberCoordinate = randomize.Next(0, numberCoordinates.Count);
                                    if (numberCoordinates[numberCoordinate] != 0 && numberCoordinates[numberCoordinate] != 100)
                                    {
                                        IsCorrectCoordinate = ComplementTheDeck(2);
                                    }
                                    else
                                    {
                                        IsCorrectCoordinate = false;
                                    }
                                } while (IsCorrectCoordinate != true);
                                numberCoordinates[numberCoordinate] = 100;
                                coordinatesOfShips[countShips] += computerMap[numberCoordinate];
                                NullCoordinate(2);
                                countShips++;
                                CountTwoShips++;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (CountThreeShips < 2)
                            {
                                do
                                {
                                    numberCoordinate = randomize.Next(0, numberCoordinates.Count);
                                    if (numberCoordinates[numberCoordinate] != 0 && numberCoordinates[numberCoordinate] != 100)
                                    {
                                        IsCorrectCoordinate = ComplementTheDeck(3);
                                    }
                                    else
                                    {
                                        IsCorrectCoordinate = false;
                                    }
                                } while (IsCorrectCoordinate != true);
                                numberCoordinates[numberCoordinate] = 100;
                                coordinatesOfShips[countShips] += computerMap[numberCoordinate];
                                NullCoordinate(3);
                                countShips++;
                                CountThreeShips++;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (CountFourShips == 0)
                            {
                                do
                                {
                                    numberCoordinate = randomize.Next(0, numberCoordinates.Count);
                                    if (numberCoordinates[numberCoordinate] != 0 && numberCoordinates[numberCoordinate] != 100)
                                    {
                                        IsCorrectCoordinate = ComplementTheDeck(4);
                                    }
                                    else
                                    {
                                        IsCorrectCoordinate = false;
                                    }
                                } while (IsCorrectCoordinate != true);
                                numberCoordinates[numberCoordinate] = 100;
                                coordinatesOfShips[countShips] += computerMap[numberCoordinate];
                                NullCoordinate(4);
                                countShips++;
                                CountFourShips++;
                            }
                            break;
                        }
                }
            }
            direction = 0;
        }

        public bool ComplementTheDeck(int length)
        {
            int SideOfTheRoad;
            bool CheckNull = false;
            int NumberOfAttempts = 0;
            int i;
            do
            {
                i = 1;
                if (numberCoordinate / 10 != 9 && numberCoordinate / 10 != 0 && numberCoordinate % 10 != 0 && numberCoordinate % 10 != 9)
                {
                    SideOfTheRoad = randomize.Next(1, 5);
                }
                else if (numberCoordinate == 0)
                {
                    SideOfTheRoad = randomize.Next(2, 4);
                }
                else if (numberCoordinate == 9)
                {
                    SideOfTheRoad = randomize.Next(3, 5);
                }
                else if (numberCoordinate == 99)
                {
                    SideOfTheRoad = randomize.Next(0, 2);
                    if (SideOfTheRoad == 0)
                    {
                        SideOfTheRoad = 4;
                    }
                }
                else if (numberCoordinate == 90)
                {
                    SideOfTheRoad = randomize.Next(1, 3);
                }
                else if (numberCoordinate / 10 == 0)
                {
                    SideOfTheRoad = randomize.Next(2, 5);
                }
                else if (numberCoordinate % 10 == 9)
                {
                    SideOfTheRoad = randomize.Next(1, 4);
                    if (SideOfTheRoad > 1)
                    {
                        SideOfTheRoad += 1;
                    }
                }
                else if (numberCoordinate / 10 == 9)
                {
                    SideOfTheRoad = randomize.Next(0, 3);
                    if (SideOfTheRoad == 0)
                    {
                        SideOfTheRoad = 4;
                    }
                }
                else
                {
                    SideOfTheRoad = randomize.Next(1, 4);
                }
                if (SideOfTheRoad == 1)
                {
                    direction = -10;
                }
                else if (SideOfTheRoad == 2)
                {
                    direction = 1;
                }
                else if (SideOfTheRoad == 3)
                {
                    direction = 10;
                }
                else if (SideOfTheRoad == 4)
                {
                    direction = -1;
                }
                while (i < length)
                {
                    if (numberCoordinate + direction * i >= 0 && numberCoordinate + direction * i <= 99)
                    {
                        if (numberCoordinates[numberCoordinate + direction * i] != 0 && numberCoordinates[numberCoordinate + direction * i] != 100)
                        {
                            if (direction == -1 || direction == 1)
                            {
                                if ((numberCoordinate + direction * (i - 1)) / 10 == (numberCoordinate + direction * i) / 10)
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
                    while (i < length)
                    {
                        numberCoordinates[numberCoordinate + direction * i] = 100;
                        coordinatesOfShips[countShips] = coordinatesOfShips[countShips] + computerMap[numberCoordinate + direction * i];
                        i++;
                    }
                }
                NumberOfAttempts++;
            } while (CheckNull != true && NumberOfAttempts != 9);
            if (NumberOfAttempts == 9 && CheckNull == false)
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
                if ((numberCoordinate + direction * i) % 10 == 0 && numberCoordinate + direction * i != 0 && numberCoordinate + direction * i != 90)
                {
                    if (numberCoordinates[numberCoordinate - 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 9 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 11 + direction * i] = 0;
                    }
                }
                else if (numberCoordinate + direction * i == 0)
                {
                    if (numberCoordinates[numberCoordinate + 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 11 + direction * i] = 0;
                    }
                }
                else if ((numberCoordinate + direction * i) / 10 == 0 && numberCoordinate + direction * i != 9)
                {
                    if (numberCoordinates[numberCoordinate + 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 11 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 9 + direction * i] = 0;
                    }
                }
                else if ((numberCoordinate + direction * i) % 10 == 9 && numberCoordinate + direction * i != 9 && numberCoordinate + direction * i != 99)
                {
                    if (numberCoordinates[numberCoordinate - 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 11 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 9 + direction * i] = 0;
                    }
                }
                else if (numberCoordinate + direction * i == 9)
                {
                    if (numberCoordinates[numberCoordinate - 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 9 + direction * i] = 0;
                    }
                }
                else if (numberCoordinate + direction * i == 90)
                {
                    if (numberCoordinates[numberCoordinate - 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 9 + direction * i] = 0;
                    }
                }
                else if ((numberCoordinate + direction * i) / 10 == 9 && numberCoordinate + direction * i != 99)
                {
                    if (numberCoordinates[numberCoordinate - 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 9 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 11 + direction * i] = 0;
                    }
                }
                else if (numberCoordinate + direction * i == 99)
                {
                    if (numberCoordinates[numberCoordinate - 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 11 + direction * i] = 0;
                    }
                }
                else
                {
                    if (numberCoordinates[numberCoordinate - 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 10 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 10 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 1 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 1 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 11 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 9 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate - 9 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate - 9 + direction * i] = 0;
                    }

                    if (numberCoordinates[numberCoordinate + 11 + direction * i] != 100)
                    {
                        numberCoordinates[numberCoordinate + 11 + direction * i] = 0;
                    }
                }
                i++;
            }
        }

        public string MakeShot(out int numberCoordinateShot, out int time)
        {
            if (completeDestructionOfTheShip == "off")
            {
                while (true)
                {
                    numberCoordinate = randomize.Next(0, computerMap.Count);
                    if (computerMap[numberCoordinate] != "SB")
                    {
                        if (IsThisLogicalMove() == true)
                        {
                            direction = 0;
                            numberDirection = new List<int> { 1, 2, 3, 4 };
                            numberCoordinateShot = numberCoordinate;
                            time = 3000;
                            return computerMap[numberCoordinate];
                        }
                    }
                }
            }
            else
            {
                numberCoordinateShot =  ShootToKill(out time);
                return computerMap[numberCoordinate];
            }
        }

        public bool CheckTheShips(string coordinate, out int resultGameOfThisShot)
        {
            int lengthShip = 0;
            int lengthDeck = coordinate.Length;
            int index = -1;
            int count = 0;
            foreach (var oneShip in coordinatesOfShips)
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
                resultGameOfThisShot = 0;
                return false;
            }
            else
            {
                if (coordinatesOfShips[count] == coordinate)
                {
                    coordinatesOfShips[count] = "";
                    int countZeroString = 0;
                    foreach (var oneShip in coordinatesOfShips)
                    {
                        if (oneShip.Length == 0)
                        {
                            countZeroString++;
                        }
                    }
                    if (countZeroString == 10)
                    {
                        resultGameOfThisShot = 3;
                        return true;
                    }
                    else
                    {
                        resultGameOfThisShot = 2;
                        return true;
                    }
                }
                else
                {
                    string checkString = coordinatesOfShips[count];
                    coordinatesOfShips[count] = "";
                    for (int i = 0; i < index; i++)
                    {
                        coordinatesOfShips[count] += Convert.ToString(checkString[i]);
                    }
                    for (int i = lengthDeck + index; i < lengthShip; i++)
                    {
                        coordinatesOfShips[count] += Convert.ToString(checkString[i]);
                    }
                    resultGameOfThisShot = 1;
                    return true;
                }
            }
        }

        public void InformationAboutShot(int result)
        {
            if (result == 0 || result == 1)
            {
                completeDestructionOfTheShip = "off";
                computerMap[numberCoordinate] = "SB";
                coordinatesKillShips.Add(numberCoordinate);
                StopKill();
                for (int i = 0; i < coordinatesKillShips.Count; i++)
                {
                    coordinatesKillShips.RemoveAt(i);
                }
                countPlayerShipWhichItNotKill[countShotForOneShip]--;
                countShotForOneShip = 0;
            }
            else if (result == 2)
            {
                completeDestructionOfTheShip = "on";
                if (countShotForOneShip == 0)
                {
                    numberCoordinateFirstShot = numberCoordinate;
                }
                coordinatesKillShips.Add(numberCoordinate);
                if (direction == -10 || direction == 10)
                {
                    for (int i = 0; i < numberDirection.Count; i++)
                    {
                        if (numberDirection[i] == 4 || numberDirection[i] == 2)
                        {
                            numberDirection.RemoveAt(i);
                            i -= 1;
                        }
                    }
                }
                else if (direction == -1 || direction == 1)
                {
                    for (int i = 0; i < numberDirection.Count; i++)
                    {
                        if (numberDirection[i] == 1 || numberDirection[i] == 3)
                        {
                            numberDirection.RemoveAt(i);
                            i -= 1;
                        }
                    }
                }
                computerMap[numberCoordinate] = "SB";
                countShotForOneShip++;
            }
            else
            {
                isHitTheTarget = false;
                computerMap[numberCoordinate] = "SB";
                numberCoordinate = numberCoordinateFirstShot;
            }
        }

        public int ShootToKill(out int time)
        {
            int lastDirection = direction;
            int answerRandom = 0;
            int numberOfRoad;
            bool isTrueRandom = false;
            while (isTrueRandom != true)
            {
                if (isHitTheTarget == false)
                {
                    answerRandom = randomize.Next(0, numberDirection.Count);
                    numberOfRoad = numberDirection[answerRandom];
                    if (numberOfRoad == 1)
                    {
                        direction = -10;
                    }
                    else if (numberOfRoad == 2)
                    {
                        direction = 1;
                    }
                    else if (numberOfRoad == 3)
                    {
                        direction = 10;
                    }
                    else
                    {
                        direction = -1;
                    }
                }
                if ((direction != lastDirection || isHitTheTarget != false) && numberCoordinate + direction >= 0 && numberCoordinate + direction <= 99)
                {
                    if (computerMap[numberCoordinate + direction] != "SB")
                    {
                        if (direction == -1 || direction == 1)
                        {
                            if ((numberCoordinate + direction) / 10 == numberCoordinate / 10)
                            {
                                if (isHitTheTarget == false)
                                {
                                    numberDirection.RemoveAt(answerRandom);
                                }
                                isTrueRandom = true;
                                isHitTheTarget = true;
                                numberCoordinate += direction;
                            }
                            else
                            {
                                isTrueRandom = false;
                                isHitTheTarget = false;
                                numberCoordinate = numberCoordinateFirstShot;
                            }
                        }
                        else
                        {
                            if (isHitTheTarget == false)
                            {
                                numberDirection.RemoveAt(answerRandom);
                            }
                            isTrueRandom = true;
                            isHitTheTarget = true;
                            numberCoordinate += direction;
                        }
                    }
                    else
                    {
                        isTrueRandom = false;
                        isHitTheTarget = false;
                        numberCoordinate = numberCoordinateFirstShot;
                    }
                }
                else
                {
                    isTrueRandom = false;
                    isHitTheTarget = false;
                    numberCoordinate = numberCoordinateFirstShot;
                }
            }
            time = 1500;
            return numberCoordinate;
        }

        public bool IsThisLogicalMove()
        {
            int counter = 0;
            int saveNumberCoordinate = numberCoordinate;
            List <int> directions = new List <int> ();
            if (countPlayerShipWhichItNotKill[0] == 0 && countPlayerShipWhichItNotKill[1] == 0 && countPlayerShipWhichItNotKill[2] == 0)
            {
                counter = 3;
            }
            else if (countPlayerShipWhichItNotKill[0] == 0 && countPlayerShipWhichItNotKill[1] == 0)
            {
                counter = 2;
            }
            else if (countPlayerShipWhichItNotKill[0] == 0)
            {
                counter = 1;
            }
            else
            {
                return true;
            }
            int numberCoordinatesWhichWarning = GetNumberCoordinatesWhichWarning();
            if (numberCoordinatesWhichWarning == 9)
            {
                if (computerMap[numberCoordinate + 1] == "SB" && computerMap[numberCoordinate - 1] == "SB" && computerMap[numberCoordinate + 10] == "SB" && computerMap[numberCoordinate - 10] == "SB")
                {
                    return false;
                }
                else
                {
                    if (counter == 1)
                    {
                        return true;
                    }
                    if (computerMap[numberCoordinate + 1] != "SB")
                    {
                        directions.Add(1);
                    }
                    if (computerMap[numberCoordinate - 1] != "SB")
                    {
                        directions.Add(-1);
                    }
                    if (computerMap[numberCoordinate + 10] != "SB")
                    {
                        directions.Add(10);
                    }
                    if (computerMap[numberCoordinate - 10] != "SB")
                    {
                        directions.Add(-10);
                    }
                }
            }
            else
            {
                int countNoShoot = 0;
                if (IsTrueShoot(numberCoordinatesWhichWarning, 1, 1) == false)
                {
                    countNoShoot++;
                }
                else
                {
                    directions.Add(1);
                }
                if (IsTrueShoot(numberCoordinatesWhichWarning, 1, 10) == false)
                {
                    countNoShoot++;
                }
                else
                {
                    directions.Add(10);
                }
                if (IsTrueShoot(numberCoordinatesWhichWarning, 1, -10) == false)
                {
                    countNoShoot++;
                }
                else
                {
                    directions.Add(-10);
                }
                if (IsTrueShoot(numberCoordinatesWhichWarning, 1, -1) == false)
                {
                    countNoShoot++;
                }
                else
                {
                    directions.Add(-1);
                }
                if (countNoShoot == 4)
                {
                    return false;
                }

            }
            int j;
            int counterOfGoodShoot;
            for (int i = 0; i < directions.Count; i++)
            {
                j = 2;
                counterOfGoodShoot = 0;
                while (j <= counter)
                {
                    numberCoordinate += directions[i];
                    numberCoordinatesWhichWarning = GetNumberCoordinatesWhichWarning();
                    if (IsTrueShoot(numberCoordinatesWhichWarning, 1, directions[i]) == true)
                    {
                        counterOfGoodShoot++;
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }
                if (counterOfGoodShoot == counter - 1)
                {
                    numberCoordinate = saveNumberCoordinate;
                    return true;
                }
                numberCoordinate = saveNumberCoordinate;
            }
            return false;
        }

        public void StopKill()
        {
            foreach(var oneCoordinateShip in coordinatesKillShips)
            {
                if (oneCoordinateShip == 0)
                {
                    computerMap[oneCoordinateShip + 1] = "SB";
                    computerMap[oneCoordinateShip + 10] = "SB";
                    computerMap[oneCoordinateShip + 11] = "SB";
                }
                else if (oneCoordinateShip == 9)
                {
                    computerMap[oneCoordinateShip - 1] = "SB";
                    computerMap[oneCoordinateShip + 9] = "SB";
                    computerMap[oneCoordinateShip + 10] = "SB";
                }
                else if (oneCoordinateShip == 90)
                {
                    computerMap[oneCoordinateShip - 10] = "SB";
                    computerMap[oneCoordinateShip - 9] = "SB";
                    computerMap[oneCoordinateShip + 1] = "SB";
                }
                else if (oneCoordinateShip == 99)
                {
                    computerMap[oneCoordinateShip - 11] = "SB";
                    computerMap[oneCoordinateShip - 10] = "SB";
                    computerMap[oneCoordinateShip - 1] = "SB";
                }
                else if (oneCoordinateShip < 9)
                {
                    computerMap[oneCoordinateShip + 1] = "SB";
                    computerMap[oneCoordinateShip - 1] = "SB";
                    computerMap[oneCoordinateShip + 10] = "SB";
                    computerMap[oneCoordinateShip + 9] = "SB";
                    computerMap[oneCoordinateShip + 11] = "SB";
                }
                else if (oneCoordinateShip % 10 == 0)
                {
                    computerMap[oneCoordinateShip - 10] = "SB";
                    computerMap[oneCoordinateShip - 9] = "SB";
                    computerMap[oneCoordinateShip + 1] = "SB";
                    computerMap[oneCoordinateShip + 10] = "SB";
                    computerMap[oneCoordinateShip + 11] = "SB";
                }
                else if (oneCoordinateShip % 10 == 9)
                {
                    computerMap[oneCoordinateShip - 11] = "SB";
                    computerMap[oneCoordinateShip - 10] = "SB";
                    computerMap[oneCoordinateShip - 1] = "SB";
                    computerMap[oneCoordinateShip + 10] = "SB";
                    computerMap[oneCoordinateShip + 9] = "SB";
                }
                else if (oneCoordinateShip > 90)
                {
                    computerMap[oneCoordinateShip - 11] = "SB";
                    computerMap[oneCoordinateShip - 10] = "SB";
                    computerMap[oneCoordinateShip - 9] = "SB";
                    computerMap[oneCoordinateShip - 1] = "SB";
                    computerMap[oneCoordinateShip + 1] = "SB";
                }
                else
                {
                    computerMap[oneCoordinateShip + 1] = "SB";
                    computerMap[oneCoordinateShip - 1] = "SB";
                    computerMap[oneCoordinateShip + 9] = "SB";
                    computerMap[oneCoordinateShip - 9] = "SB";
                    computerMap[oneCoordinateShip + 10] = "SB";
                    computerMap[oneCoordinateShip - 10] = "SB";
                    computerMap[oneCoordinateShip + 11] = "SB";
                    computerMap[oneCoordinateShip - 11] = "SB";
                }
            }
        }

        public string GetMessage(string resultShot)
        {
            List<string> messagesThematics = new List<string> ();
            ICollection keys = computerMessages.Keys;
            foreach (string key in keys)
            {
                if (computerMessages[key].ToString() == resultShot)
                {
                    messagesThematics.Add(key);
                }
            }
            int indexOnList = randomize.Next(0, messagesThematics.Count);
            return messagesThematics[indexOnList];
        }

        public int GetNumberCoordinatesWhichWarning(int term = 0)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3)
                {
                    if (numbersCoordinatesWhichWarning[i][i - i] == numberCoordinate)
                    {
                        return i;
                    }
                }
                else
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (numbersCoordinatesWhichWarning[i][j] == numberCoordinate)
                        {
                            return i;
                        }
                    }
                }
            }
            return 9;
        }

        public bool IsTrueShoot(int number, int factor, int directionThink)
        {
            if (directionThink == 1)
            {
                if (number == 0 || number == 2 || number == 4 || number == 6 || number == 7 || number == 9)
                {
                    if (computerMap[numberCoordinate + 1 * factor] != "SB")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (directionThink == 10)
            {
                if (number == 0 || number == 1 || number == 4 || number == 5 || number == 7 || number == 9)
                {
                    if (computerMap[numberCoordinate + 10 * factor] != "SB")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (directionThink == -10)
            {
                
                if (number == 2 || number == 3 || number == 5 || number == 6 || number == 7 || number == 9)
                {
                    if (computerMap[numberCoordinate - 10 * factor] != "SB")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (number == 1 || number == 3 || number == 4 || number == 5 || number == 6 || number == 9)
                {
                    if (computerMap[numberCoordinate - 1 * factor] != "SB")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}