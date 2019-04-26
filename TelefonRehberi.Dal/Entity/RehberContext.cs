using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Dal.Migrations;
using TelefonRehberi.Entity;

namespace TelefonRehberi.Dal.Entity
{
   public class RehberContext:DbContext
    {
        public RehberContext():base("DbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RehberContext, Configuration>("DbConnection"));
        }

        public virtual DbSet<Calisan> Calisan { get; set; }
        public virtual DbSet<Departman> Departman { get; set; }

    }
}
