using IRunes.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using IRunes.Models;

namespace IRunes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Order> Orders { get; set; }
          
        

       
    }
}
