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
    public class CountryRep : ICountryRep
    {
        private readonly ProjectDbContext Db;
        public CountryRep(ProjectDbContext Db)
        {
            this.Db = Db;
        }
        public IEnumerable<Country> Get()
        {
            var data = Db.Country.Select(x => x);
            return data;
        }
        public Country GetById(int id)
        {
            var data = Db.Country.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
    }
}
