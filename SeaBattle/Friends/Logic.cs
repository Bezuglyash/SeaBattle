using System;
using System.Collections.Generic;
using SQLite;

namespace SeaBattle
{
    public class Logic
    {
        private int id;
        private const string NAME_DATA_BASE = "SeaBattle.db";
        private SQLiteConnection dataBase;
        private User user;
        private bool itWasOpen;

        public Logic()
        {
            id = 0;
            try
            {
                itWasOpen = true;
                dataBase = new SQLiteConnection(NAME_DATA_BASE, SQLiteOpenFlags.ReadWrite, true);
            }
            catch (Exception)
            {
                itWasOpen = false;
            }
            user = new User();
        }

        ~Logic()
        {
            dataBase.Dispose();
        }

        public bool CheckingLoginAndPassword(string login, string password, out int checkLoginOrPassword)
        {
            if (itWasOpen == false)
            {
                checkLoginOrPassword = 0;
                return false;
            }
            else
            {
                dataBase = new SQLiteConnection(NAME_DATA_BASE, SQLiteOpenFlags.ReadWrite, true);
                var users = dataBase.Table<User>();
                foreach(var userCheck in users)
                {
                    if (login == userCheck.Login)
                    {
                        if (password == userCheck.Password)
                        {
                            user = userCheck;
                            id = user.Id;
                        }
                        else
                        {
                            checkLoginOrPassword = 2;
                            return false;
                        }
                    }
                }
                if (id != 0)
                {
                    checkLoginOrPassword = 3;
                    return true;
                }
                else
                {
                    checkLoginOrPassword = 1;
                    return false;
                }
            }
        }

        public bool CheckingScan(string nick, string login, string password, out int numberString)
        {
            if (itWasOpen == true)
            {
                var users = dataBase.Table<User>();
                foreach (var oneUser in users)
                {
                    if (oneUser.Login == login)
                    {
                        numberString = 4;
                        return false;
                    }
                }
            }
            if (nick.Length > 12)
            {
                numberString = 1;
                return false;
            }
            else if (login.Length > 19)
            {
                numberString = 2;
                return false;
            }
            else if (password.Length > 19)
            {
                numberString = 3;
                return false;
            }
            else
            {
                numberString = 0;
                return true;
            }
        }

        public void SavingNewAccountData(string nick, string login, string password)
        {
            if (itWasOpen == false)
            {
                dataBase = new SQLiteConnection(NAME_DATA_BASE, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, true);
                dataBase.CreateTable<User>();
            }
            user.Login = login;
            user.Password = password;
            user.Nickname = nick;
            user.Rank = "Матрос";
            user.NumberOfGames = 0;
            user.NumberOfWins = 0;
            user.PercentWins = 0;
            user.NumberDefeatsConsecutive = 0;
            id = dataBase.Insert(user);
        }

        public string GetNick()
        {
            return user.Nickname;
        }

        public string GetRank()
        {
            return user.Rank;
        }

        public long GetNumberGames()
        {
            return user.NumberOfGames;
        }

        public long GetNumberWins()
        {
            return user.NumberOfWins;
        }

        public int GetPercentOfWins()
        {
            return user.PercentWins;
        }

        public long GetNumberDefeatsConsecutive()
        {
            return user.NumberDefeatsConsecutive;
        }

        public void SetNewLogin(string login)
        {
            user.Login = login;
            UpdateData();
        }

        public void SetNewPassword(string password)
        {
            user.Password = password;
            UpdateData();
        }

        public void SetNewNickname(string nick)
        {
            user.Nickname = nick;
            UpdateData();
        }

        public void SetNewRank(string rank)
        {
            user.Rank = rank;
        }

        public void SetNewNumberOfGames(long number)
        {
            user.NumberOfGames = number;
        }

        public void SetNewNumberOfWins(long number)
        {
            user.NumberOfWins = number;
        }

        public void SetNewPercentWins(int percent)
        {
            user.PercentWins = percent;
        }

        public void SetNewNumberDefeatsConsecutive(long number)
        {
            user.NumberDefeatsConsecutive = number;
        }

        public void UpdateData()
        {
            dataBase.Update(user);
        }

        public void ExitDataBase()
        {
            dataBase.Dispose();
        }
    }
}