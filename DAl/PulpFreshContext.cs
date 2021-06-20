using System;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace DAl
{
    public class PulpFreshContext: DbContext
    {

        public PulpFreshContext(DbContextOptions Options):base(Options){
            
        }

        public DbSet<Product> Products{get;set;}
        public DbSet<Presentation> Presentations{get;set;}
        public DbSet<Category> Categories{get;set;}
        public DbSet<Client> Clients{get;set;}
        public DbSet<User> Users {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p=>p.Category)
            .WithOne(p=>p.Product)
            .HasForeignKey<Product>(b => b.CategoryId);

            modelBuilder.Entity<Category>()
            .HasMany(p=>p.Presentations)
            .WithMany(p=>p.Categories)
            .UsingEntity(j => j.ToTable("CategoriesPresentations"));


        }

    }
}
