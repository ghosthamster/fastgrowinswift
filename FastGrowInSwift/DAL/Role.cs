using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class Role : IEntity<int>
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
