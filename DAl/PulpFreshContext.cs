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
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    }
}
