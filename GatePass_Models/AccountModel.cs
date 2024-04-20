using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "Password and confirmation password do not match.")]
        public string confirmPassword { get; set; }
        public string companyKey { get; set; }
        public string fullName { get; set; }
        public string? phoneNumber { get; set; }
    }

    public class LoginModel {
        public string email { get; set; }
        public string password { get; set; }
    }

}
