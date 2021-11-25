﻿using System;
using System.Collections.Generic;

#nullable disable

namespace EasyCSharpApi.DAL
{
    public partial class UserRole : IEntity<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int Id { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
