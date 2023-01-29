using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Models
{
    public class CountryVM
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<City> City { get; set; }

    }
}
