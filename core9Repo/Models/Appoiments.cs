using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCore.Models
{
    public class Appoiments
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public long ClientId { get; set; }
        public string PatientNames { get; set; }
        public string PatientLastNames { get; set; }
    }
}
