using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CarDealership.Models
{
    public class DealershipContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<RequestInfo> Requests { get; set; }
    }
}

