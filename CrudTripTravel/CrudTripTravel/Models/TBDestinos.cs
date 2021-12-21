using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTripTravel.Models.NovaPasta
{
    public class TBDestinos
    {   
        [Key]
        public int id_destinos { get; set; }
        public string destino { get; set; }
        public string local_destino { get; set; }
        public string data { get; set; }
    }
}
