using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interface
{
    public interface IEmployeeRep
    {
        IEnumerable<Employee> Get();
        Employee GetById(int id);
        IEnumerable<Employee> SearchByName(string name);
        void Create(Employee obj);
        void Edit(Employee obj);
        void Delete(Employee id);
    }
}
