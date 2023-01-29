using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        [MaxLength(50, ErrorMessage = "Max len 50")]
        [MinLength(3, ErrorMessage = "Min len 3")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Enter Department code")]
        public string DepartmentCode { get; set; }

        public ICollection<Employee> Employee { get; set; }

    }
}
