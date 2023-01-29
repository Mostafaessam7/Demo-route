using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }

        public string PhotoUrl { get; set; }
        public string CvUrl { get; set; }


        public int DepartmentId { get; set; }
        public int DistrictId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

    }
}
