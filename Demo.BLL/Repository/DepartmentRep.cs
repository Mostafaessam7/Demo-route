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
    public class DepartmentRep : IDepartmentRep
    {
        private readonly ProjectDbContext Db;
        public DepartmentRep(ProjectDbContext Db)
        {
            this.Db = Db;
        }

        public IEnumerable<Department> Get()
        {
            var data = Db.Department.Select(x => x);
            return data;
        }
        public Department GetById(int id)
        {
            var data = Db.Department.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }


        //public object SearchByName(string searchValue)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Department> SearchByName(string name)
        {
            var data = Db.Department.Where(x => x.DepartmentName == name).Select(x => x);
            return data;
        }

        public void Create(Department obj)
        {
            Db.Department.Add(obj);
            Db.SaveChanges();
        }
        public void Edit(Department obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(Department obj)
        {
            Db.Department.Remove(obj);
            Db.SaveChanges();
        }

    }
}
