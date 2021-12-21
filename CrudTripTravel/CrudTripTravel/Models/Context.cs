using CrudTripTravel.Models.NovaPasta;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTripTravel.Models
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<TBClientes> clientes { get; set; }
        public DbSet<TBDestinos> destinos { get; set; }
        public DbSet<TBPromocoes> promocoes { get; set; }

    }
}
