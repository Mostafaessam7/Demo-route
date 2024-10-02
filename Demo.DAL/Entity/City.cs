using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entity
{
    [Table("City")]
    public class City
    {
        //HashSet تكرار
        public City()
        {
            District = new HashSet<District>();
        }
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual ICollection<District> District { get; set; }


    }
}
