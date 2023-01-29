using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface ICountryRep
    {
        IEnumerable<Country> Get();
        Country GetById(int id);
    }
}
