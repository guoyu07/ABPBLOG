using ABPEntity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPEntity.DBEntity
{
    public class Dbentities : DbContext
    {
        public Dbentities() : base("name=ABPBLOG")
        {

        }
        public DbSet<ABPUser> userinfo { get; set; }
    }
}
