using System;
using System.Data.Entity;

namespace SeaBattle
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DataBaseConnectionString")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<DataUser> DataUsers { get; set; }
    }
}