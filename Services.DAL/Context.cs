using Services.DAL.Configurations;
using Services.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL
{
    public class Context : DbContext
    {
        public Context() : base("Server=(LocalDb)\\MSSQLLocalDB; Initial Catalog=CSharp; Integrated Security=true")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
