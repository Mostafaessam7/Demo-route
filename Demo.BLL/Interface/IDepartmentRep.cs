using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface IDepartmentRep
    {
        IEnumerable<Department> Get();
        Department GetById(int id);
        IEnumerable<Department> SearchByName(string name);
        void Create(Department obj);
        void Edit(Department obj);
        void Delete(Department id);
    }
}
