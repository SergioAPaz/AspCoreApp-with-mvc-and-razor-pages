using System;
using System.Collections.Generic;

namespace MyApi.Models
{
    public partial class CtRoles
    {
        public CtRoles()
        {
            CtUsers = new HashSet<CtUsers>();
        }

        public int Id { get; set; }
        public string Role { get; set; }

        public virtual ICollection<CtUsers> CtUsers { get; set; }
    }
}
