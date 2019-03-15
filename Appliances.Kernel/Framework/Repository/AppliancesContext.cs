using Appliances.Kernel.Framework.Modules;
using Appliances.Kernel.Framework.Modules.ProductManagement;
using Appliances.Kernel.Framework.Modules.StoreManagement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Kernel.Framework.Repository
{
    public class AppliancesContext : DbContext
    {
        public AppliancesContext() : base("AppliancesContext")
        {
            //Database.SetInitializer<EuphoriaContext>(new DropCreateDatabaseIfModelChanges<EuphoriaContext>());
            Database.SetInitializer<AppliancesContext>(null);

            //this.Database.Log = s => File.AppendAllLines(@"c:\DBQueries.txt",new string[] { s + Environment.NewLine });
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("ryan");
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<ExhibitorStore> ExhibitorStores { get; set; }
        public DbSet<ExhibitorAddress> ExhibitorAddresses { get; set; }
    }
}
