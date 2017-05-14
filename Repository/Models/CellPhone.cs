using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class CellPhone : Product
    {
        public string Brand { get; set; }

        public double ScreenSize { get; set; }

        public int StorageCapacity { get; set; }
    }
}
