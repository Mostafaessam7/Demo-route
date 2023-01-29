using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface IDistrictRep
    {
        IEnumerable<District> Get();
        District GetById(int id);
    }
}
