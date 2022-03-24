using Eventures2022.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Eventures2022.Models;

namespace Eventures2022.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventuresUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Eventures2022.Models.OrderListingViewModel> OrderListingViewModel { get; set; }
    }
}
