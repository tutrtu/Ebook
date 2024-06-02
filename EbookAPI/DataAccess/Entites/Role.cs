﻿using System;
using System.Collections.Generic;

namespace EbookAPI.DataAccess.Entites
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleDesc { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
