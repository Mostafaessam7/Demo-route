using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Models
{
    public class EmployeeVM
    {
        //public EmployeeVM()
        //{
        //    HireDate = DateTime.Now;

        //}
        public int Id { get; set; }

        [Required(ErrorMessage = "enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "enter Email")]
        [EmailAddress(ErrorMessage = "enter valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "enter salary")]
        [Range(2000, 10000, ErrorMessage = "Range 2000:10000")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "enter Address")]
        [RegularExpression("[0-9]{1,4}-[a-zA-Z]{1,5}-[a-zA-Z]{1,5}-[a-zA-Z]{1,5}", ErrorMessage = "EX. 12-street-city-country")]
        public string Address { get; set; }

        [Required(ErrorMessage = "enter HireDate")]
        public DateTime HireDate { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }
        public string PhotoUrl { get; set; }
        public string CvUrl { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Cv { get; set; }


        [Required(ErrorMessage = "enter DepartmentId")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "enter DistrictId")]
        public int DistrictId { get; set; }


        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

    }
}
