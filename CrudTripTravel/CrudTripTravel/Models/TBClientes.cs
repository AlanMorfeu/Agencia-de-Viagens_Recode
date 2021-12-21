using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTripTravel.Models.NovaPasta
{
    public class TBClientes
    {   
        [Key]
        public int id_clientes { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
