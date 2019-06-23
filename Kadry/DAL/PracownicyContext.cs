using Kadry.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Kadry.DAL
{
    public class PracownicyContext : DbContext
    {
        public PracownicyContext() : base("DefaultConnection")
        {

        }

        public DbSet<Dział> Działy { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Umowa> Umowy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}