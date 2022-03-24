using Eventures2022.Domain;
using Eventures2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures2022.Controllers
{
    [Authorize(Roles="Administrator")]
    public class EventureUsersController : Controller
    {
        private readonly UserManager<EventuresUser> userManager;

        public EventureUsersController(UserManager<EventuresUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //списък на всички потребители
            var users = this.userManager.Users
                 .Select(u => new UserListingViewModel
                 {
                     Id = u.Id,
                     UserName = u.UserName,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Email = u.Email,

                 }).ToList();

            // Id на всички администратори
            var adminIds = (await this.userManager.GetUsersInRoleAsync("Administrator"))
                .Select(a => a.Id).ToList();

            //Ако потребителят е в списъка, то IsAdmin става true
            foreach (var user in users)
            {
                user.IsAdmin = adminIds.Contains(user.Id);
            }

             //сортираме първо админите по юзърнейм, после останалите потребители по юзърнейм
            var orderedUsers = users
        .OrderByDescending(u => u.IsAdmin)
        .ThenBy(u => u.UserName);

            //връщаме списъка
            return this.View(orderedUsers);
        }

        [HttpPost]
        public async Task<IActionResult> Promote(string userId)
        {
            if (userId == null)
            {
                return this.RedirectToAction("Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null || await this.userManager.IsInRoleAsync(user, "Administrator"))
            {
                return this.RedirectToAction("Index");
            }

            await this.userManager.AddToRoleAsync(user, "Administrator");

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Demote(string userId)
        {
            if (userId == null)
            {
                return this.RedirectToAction("Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);

            if (user == null || !await this.userManager.IsInRoleAsync(user, "Administrator"))
            {
                return this.RedirectToAction("Index");
            }

            await this.userManager.RemoveFromRoleAsync(user, "Administrator");

            return this.RedirectToAction("Index");
        }
    }
}
