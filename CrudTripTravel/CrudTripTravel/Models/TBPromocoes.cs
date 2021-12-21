using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTripTravel.Models.NovaPasta
{
    public class TBPromocoes
    {
        [Key]
        public int id_promocoes { get; set; }
        [ForeignKey("TBClientes")]
        public int id_clientes { get; set; }
        public virtual TBClientes TBClientes { get; set; }
        [ForeignKey("TBDestinos")]
        public int id_destinos { get; set; }
        public virtual TBDestinos TBDestinos { get; set; }
        public string promocao { get; set; }
    }
}
