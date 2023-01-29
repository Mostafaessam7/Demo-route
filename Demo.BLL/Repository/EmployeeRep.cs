using Demo.BLL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly ProjectDbContext Db;
        public EmployeeRep(ProjectDbContext Db)
        {
            this.Db = Db;
        }


        public IEnumerable<Employee> Get()
        {
            var data = Db.Employee.Include("Department").Include("District").Select(x => x);
            return data;
        }
        public Employee GetById(int id)
        {
            var data = Db.Employee.Include("Department").Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
        public IEnumerable<Employee> SearchByName(string name)
        {
            var data = Db.Employee.Include("Department").Where(x => x.Name == name).Select(x => x);
            return data;
        }


        public void Create(Employee obj)
        {
            Db.Employee.Add(obj);
            Db.SaveChanges();
        }
        public void Edit(Employee obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public void Delete(Employee obj)
        {
            Db.Employee.Remove(obj);
            Db.SaveChanges();
        }

    }
}
