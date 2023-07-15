using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Models
{
    public class RegistrationVM
    {
        [Required(ErrorMessage ="Mail Required")]
        [EmailAddress(ErrorMessage ="Enter Valid Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mail Required")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="Min len 3")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mail Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min len 3")]
        [Compare("Password",ErrorMessage ="Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


    }
}
