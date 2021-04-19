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
    }
}
