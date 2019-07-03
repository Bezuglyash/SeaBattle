using System.Collections.Generic;

namespace SeaBattle
{
    class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection <DataUser> DataUsers { get; set; }
    }
}