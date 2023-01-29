using Demo.BLL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly ProjectDbContext Db;
        public CityRep(ProjectDbContext Db)
        {
            this.Db = Db;
        }
        public IEnumerable<City> Get()
        {
            var data = Db.City.Select(x => x);
            return data;
        }
        public City GetById(int id)
        {
            var data = Db.City.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
    }
}
