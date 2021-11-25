using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class User : IEntity<int>
    {
        public User()
        {
            Answers = new HashSet<Answer>();
            Progres = new HashSet<Progress>();
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfRegister { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Progress> Progres { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
