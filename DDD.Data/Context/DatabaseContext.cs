using System;
using DDD.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using DDD.Data.EntityConfig;

namespace DDD.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DatabaseContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(x => x.Name == x.ReflectedType + "Id").Configure(x => x.IsKey());
            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(200));

            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OfferConfiguration());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
