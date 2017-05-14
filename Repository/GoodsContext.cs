using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GoodsContext : DbContext
    {
        public GoodsContext()
          : base("GoodsContext") // connectionString's name
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CellPhone> CellPhones { get; set; }
    }
}
