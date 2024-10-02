using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DepartmentName { get; set; }

        [StringLength(50)]
        public string DepartmentCode { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

    }
}
