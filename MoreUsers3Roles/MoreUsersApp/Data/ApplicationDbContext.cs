using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MoreUsersApp.Models;
using MoreUsersApp.Models.Employee;
using MoreUsersApp.Models.Client;

namespace MoreUsersApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<MoreUsersApp.Models.Employee.CreateEmployeeVM> CreateEmployeeVM { get; set; }
        public DbSet<MoreUsersApp.Models.Client.ClientListingVM> ClientListingVM { get; set; }
        public DbSet<MoreUsersApp.Models.Client.CreateClientVM> CreateClientVM { get; set; }
    }  
}
