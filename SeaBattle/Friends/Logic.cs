using System;
using System.Collections.Generic;
using SQLite;

namespace SeaBattle
{
    public class Logic
    {
        private int id;
        private const string nameDataBase = "SeaBattle.db";
        private SQLiteConnection dataBase;
        private User user;
        private bool itWasOpen;

        public Logic()
        {
            id = 0;
            try
            {
                itWasOpen = true;
                dataBase = new SQLiteConnection(nameDataBase, SQLiteOpenFlags.ReadWrite, true);
            }
            catch (Exception)
            {
                itWasOpen = false;
            }
            user = new User();
        }

        public bool Checking_login_and_password(string login, string password, out int checkLoginOrPassword)
        {
            if (itWasOpen == false)
            {
                checkLoginOrPassword = 0;
                return false;
            }
            else
            {
                dataBase = new SQLiteConnection(nameDataBase, SQLiteOpenFlags.ReadWrite, true);
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

        public bool Checking_scan(string nick, string login, string password, out int numberString)
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

        public void SavingNewData(string nick, string login, string password)
        {
            if (itWasOpen == false)
            {
                dataBase = new SQLiteConnection(nameDataBase, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, true);
                dataBase.CreateTable<User>();
            }
            user.Login = login;
            user.Password = password;
            user.Nickname = nick;
            user.Rank = "Матрос";
            user.NumberOfGames = 0;
            user.NumberOfWins = 0;
            user.PercentWins = 0.0;
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

        public double GetPercentOfWins()
        {
            return user.PercentWins;
        }
    }
}