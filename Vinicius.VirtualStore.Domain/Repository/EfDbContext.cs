using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinicius.VirtualStore.Domain.Entities;

namespace Vinicius.VirtualStore.Domain.Repository
{
    public class EfDbContext: DbContext
    { 
        public DbSet<Products> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Products>().ToTable("Produtos");
        }
    }
}
