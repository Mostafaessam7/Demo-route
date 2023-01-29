using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    [Table("Country")]
    public class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<City> City { get; set; }



    }
}
