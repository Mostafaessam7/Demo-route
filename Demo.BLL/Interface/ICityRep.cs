using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface ICityRep
    {
        IEnumerable<City> Get();
        City GetById(int id);
    }
}
