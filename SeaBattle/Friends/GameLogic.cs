using System;
using System.Collections.Generic;

namespace SeaBattle
{
    class GameLogic
    {
        private int id;
        public bool Checking_login(string login)
        {
            int count = 0;
            using (var DataContext = new DatabaseContext())
            {
                int i = 1;
                User user = new User();
                while(user != null)
                {
                    user = DataContext.Users.Find(i);
                    if (user != null)
                    {
                        if (user.Login == login)
                        {
                            count++;
                            id = i;
                        }
                    }
                    i++;
                }
            }
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Checking_password(string pin)
        {
            int count = 0;
            using (var DataContext = new DatabaseContext())
            {
                User user = new User();
                user = DataContext.Users.Find(id);
                if (user.Password == pin)
                {
                    count++;
                }
            }
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetNick()
        {
            using (var Context = new DatabaseContext())
            {
                DataUser DataUser = new DataUser();
                DataUser = Context.DataUsers.Find(id);
                return DataUser.Nickname;
            }
        }
        public bool Checking_scan(int number_symbols, string word)
        {
            if (number_symbols >= word.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SavingData(string nick, string login, string password)
        {
            using (var Context = new DatabaseContext())
            {
                User user = new User
                {
                    Login = login,
                    Password = password
                };
                Context.Users.Add(user);
                Context.SaveChanges();
                DataUser DataBaseUser = new DataUser
                {
                    Nickname = nick,
                    Rank = "Матрос",
                    NumberOfGames = 0,
                    NumberOfWins = 0,
                    PercentWins = 0.0,
                    Users = user
                };
                Context.DataUsers.Add(DataBaseUser);
                Context.SaveChanges();
            }
        }
        public string GetRank()
        {
            using (var Context = new DatabaseContext())
            {
                DataUser data = new DataUser();
                data = Context.DataUsers.Find(id);
                return data.Rank;
            }
        }
        public long? GetNumberGames()
        {
            using (var Context = new DatabaseContext())
            {
                DataUser data = new DataUser();
                data = Context.DataUsers.Find(id);
                return data.NumberOfGames;
            }
        }
        public long? GetNumberWins()
        {
            using (var Context = new DatabaseContext())
            {
                DataUser data = new DataUser();
                data = Context.DataUsers.Find(id);
                return data.NumberOfWins;
            }
        }
        public double? GetPercentOfWins()
        {
            using (var Context = new DatabaseContext())
            {
                DataUser data = new DataUser();
                data = Context.DataUsers.Find(id);
                return data.PercentWins;
            }
        }
    }
}