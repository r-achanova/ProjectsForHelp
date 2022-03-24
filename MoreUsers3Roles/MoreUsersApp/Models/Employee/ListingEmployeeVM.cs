using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Models.Employee
{
    public class ListingEmployeeVM
    {
        public int Id { get; set; }
       
        [Display(Name = "Username")]
        public string Username { get; set; }
       
        [Display(Name = "Email")]
        public string Email { get; set; }
               
        [Display(Name = "First Name")]
       
        public string FirstName { get; set; }
               
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
              
        public string Phone { get; set; }
        
        public string JobTitle { get; set; }
    }
}
