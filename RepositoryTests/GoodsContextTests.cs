using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Tests
{
    [TestClass()]
    public class GoodsContextTests
    {
        [TestMethod()]
        public void 產生Car假資料()
        {
            int count = 0;
            var context = new GoodsContext();
            var a = new List<Car>();
            for (int i = 0; i < 254; i++)
            {
                a.Add(new Car() { Id = i, Name = ((char)i).ToString(), UnitPrice = 100+count, Year = i });
            }
            context.Cars.AddRange(a);
            context.SaveChanges();
        }
    }
}