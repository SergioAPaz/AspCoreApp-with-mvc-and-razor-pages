using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDCore.Models
{
    public partial class CtUsers
    {
        public int Id { get; set; }
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        
        public string Password { get; set; }
        [Display(Name = "Rol")]
        public int? Role { get; set; }
        [Display(Name = "Fecha de creacion")]
        public DateTime? CreationDate { get; set; }
        [Display(Name = "Ultimo acceso")]
        public DateTime? LastAccess { get; set; }

        public string Especialidad { get; set; }
        public long? NoCedula { get; set; }

        public virtual CtRoles RoleNavigation { get; set; }
    }
}
