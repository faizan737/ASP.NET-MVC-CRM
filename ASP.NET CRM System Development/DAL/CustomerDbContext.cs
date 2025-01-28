using ASP.NET_CRM_System_Development.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ASP.NET_CRM_System_Development.DAL
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext():base("name=DefaultConnection"){}
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);          //Primary Key

            modelBuilder.Entity<Customer>().Property(x=>x.Name)
                                           .IsRequired()                //NotNull
                                           .HasMaxLength(100);          //Max Length (100)
            modelBuilder.Entity<Customer>().Property(x => x.Email)
                                           .IsRequired()                //NotNull
                                           .HasMaxLength(100)           //Max Length (100)
                                           .IsUnicode(false);           //using non-unicde for efficiency
            modelBuilder.Entity<Customer>().HasIndex(x => x.Email)
                                           .IsUnique();                 //MAking Email Unique
            modelBuilder.Entity<Customer>().Property(x => x.Phone)
                                           .IsRequired()                //NotNull
                                           .HasMaxLength(15);          //Max Length (15)

            base.OnModelCreating(modelBuilder);
        }
    }
}