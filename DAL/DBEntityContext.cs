using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBEntityContext: DbContext
    {
        public DBEntityContext():base("name=defaultConnection")
        {
            Database.SetInitializer<DBEntityContext>(new DbInitializer());
        }
        public DbSet<Category> Categories { get; set; }
    }
}
