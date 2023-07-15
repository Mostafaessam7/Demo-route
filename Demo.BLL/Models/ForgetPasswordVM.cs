using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
