using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPraktika.Models
{
    public partial class User
    {
        public User()
        {
            Reports = new HashSet<Report>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
