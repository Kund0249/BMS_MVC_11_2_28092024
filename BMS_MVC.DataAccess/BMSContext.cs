using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BMS_MVC.DataAccess.Entity;

namespace BMS_MVC.DataAccess
{
    internal class BMSContext : DbContext
    {
        public BMSContext():base("name=EFBMSDBCON")
        {
            
        }

        public DbSet<BookEntity> Books { get; set; }
    }
}
