using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MoreUsersApp.Models;
using MoreUsersApp.Models.Employee;

namespace MoreUsersApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<MoreUsersApp.Models.Employee.CreateEmployeeVM> CreateEmployeeVM { get; set; }
    }  
}
