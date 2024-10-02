using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    [Table("District")]
    public class District
    {
        public District()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

    }
}
