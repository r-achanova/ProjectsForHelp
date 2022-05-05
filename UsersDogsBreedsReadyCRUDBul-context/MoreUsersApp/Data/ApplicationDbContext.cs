using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MoreUsersApp.Models;
using MoreUsersApp.Models.Employee;
using MoreUsersApp.Models.Dog;

namespace MoreUsersApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<MoreUsersApp.Models.Employee.CreateEmployeeVM> CreateEmployeeVM { get; set; }
        public DbSet<MoreUsersApp.Models.Dog.DogCreateVM> DogCreateVM { get; set; }
        public DbSet<MoreUsersApp.Models.Dog.DogListVM> DogListVM { get; set; }
        public DbSet<MoreUsersApp.Models.Dog.DogDetailsVM> DogDetailsVM { get; set; }
    }  
}
