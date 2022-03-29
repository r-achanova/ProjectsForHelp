using DentalSystem.Data;
using DentalSystem.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalSystem.Seeds
{
    public static class ApplicatioBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);
            await SeedDocs(services);

            return app;
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "Patient", "Doctor" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync
                           ("admin@admin.com") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                

                var result = await userManager.CreateAsync
                (user, "123!@#qweQWE");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }
        }


        private static async Task SeedDocs(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

            if (await userManager.FindByNameAsync
                           ("doctor1@abv.bg") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "doctor1";
                user.Email = "doctor1@abv.bg";
                

                var result = await userManager.CreateAsync
                (user, "Ivanov1!");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Doctor").Wait();

                    Doctor doctor = new Doctor()
                    {
                       FirstName = "Ivan",
                    LastName = "Ivanov",
                    EGN = "0000000000",
                    Phone = "0000000000",
                    Speciality = "Hirurg",
                        Biography = "Medical University, Sofia",
                        UserId = user.Id
                    };

                    await db.Doctors.AddAsync(doctor);
                    await db.SaveChangesAsync();
                }
            }
            if (await userManager.FindByNameAsync
                           ("doctor2@abv.bg") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "doctor2";
                user.Email = "doctor2@abv.bg";
                

                var result = await userManager.CreateAsync
                (user, "Ivanova1!");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Doctor").Wait();

                    Doctor doctor = new Doctor()
                    {
                        FirstName = "Ani",
                        LastName = "Ivanova",
                        EGN = "0000000000",
                        Phone = "0000000000",
                        Speciality = "Vutresni bolesti",
                        Biography = "Medical University, Plovdiv 2000",
                        UserId = user.Id
                    };

                    await db.Doctors.AddAsync(doctor);
                    await db.SaveChangesAsync();
                }
            }
            if (await userManager.FindByNameAsync
                           ("doctor3@abv.bg") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "doctor3";
                user.Email = "doctor3@abv.bg";
                
                var result = await userManager.CreateAsync
                (user, "Petrov1!");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Doctor").Wait();

                    Doctor doctor = new Doctor()
                    {
                        FirstName = "Asen",
                        LastName = "Petrov",
                        EGN = "0000000000",
                        Phone = "0000000000",
                        Speciality = "Hirurg",
                        Biography = "Medical University, Sofia",
                        UserId = user.Id
                    };

                    await db.Doctors.AddAsync(doctor);
                    await db.SaveChangesAsync();
                }
            }



        }
    }
}
