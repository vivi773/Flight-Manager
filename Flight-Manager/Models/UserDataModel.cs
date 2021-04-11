using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Flight_Manager.Models
{
    public class UserDataModel : IdentityUser
    {
        [Required(ErrorMessage = "Enter your First name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your Last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your EGN")]
        public string EGN { get; set; }
        [Required(ErrorMessage = "Enter your adress")]
        public string Address { get; set; }
        
    }
}
