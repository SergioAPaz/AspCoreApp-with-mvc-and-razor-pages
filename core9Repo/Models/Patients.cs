using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCore.Models
{
    public class Patients
    {
        public int Id { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? Date { get; set; }
        public long ClientId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Phone { get; set; }

        public string Rfc { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string FamiliarPhone { get; set; }


    }
}
