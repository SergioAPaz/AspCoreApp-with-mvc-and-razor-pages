﻿using System;
using System.Collections.Generic;

namespace CRUDCore.Models
{
    public partial class CtUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }

        public virtual CtRoles RoleNavigation { get; set; }
    }
}
