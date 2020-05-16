using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDCore.Models
{
    public partial class CtRoles
    {
        public CtRoles()
        {
            CtUsers = new HashSet<CtUsers>();
        }

        public int Id { get; set; }
        [Display(Name = "Rolito")]
        public string Role { get; set; }

        public virtual ICollection<CtUsers> CtUsers { get; set; }
    }
}
