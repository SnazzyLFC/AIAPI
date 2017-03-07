using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository.Repo
{
    public class Context : IdentityDbContext<User>
    {
        public Context()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public static Context Create()
        {
            return new Context();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany<Product>(p => p.Products)
                .WithOptional(o => o.Order)
                .HasForeignKey(m => m.OrderId);
        }
    }
}