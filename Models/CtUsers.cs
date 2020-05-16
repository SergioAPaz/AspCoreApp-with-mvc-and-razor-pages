using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDCore.Models
{
    public partial class CtUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Passito")]
        public string Password { get; set; }
        public int? Role { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual CtRoles RoleNavigation { get; set; }
    }
}
