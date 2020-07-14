using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCore.Models
{
    public class Patients
    {

        public int Id { get; set; }
        [Display(Name = "Fecha:")]
        public DateTime? CreationDate { get; set; }
        public long ClientId { get; set; }
        [Required(ErrorMessage = "Favor de llenar este campo.")]
        [Display(Name = "Nombre:")]
        public string Names { get; set; }
        [Required(ErrorMessage = "Favor de llenar este campo.")]
        [Display(Name = "Apellidos:")]
        public string LastNames { get; set; }
        [Required(ErrorMessage = "Favor de llenar este campo.")]
        [Display(Name = "Telefono:")]
        public string Phone { get; set; }
        [Display(Name = "RFC:")]
        public string Rfc { get; set; }
        public string Calle { get; set; }
        [Display(Name = "Numero de casa:")]
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        [Display(Name = "Telefono 2:")]
        public string FamiliarPhone { get; set; }
       


    }
}
