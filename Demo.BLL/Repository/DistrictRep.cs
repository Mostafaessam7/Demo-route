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
    public class DistrictRep : IDistrictRep
    {
        private readonly ProjectDbContext Db;
        public DistrictRep(ProjectDbContext Db)
        {
            this.Db = Db;
        }
        public IEnumerable<District> Get()
        {
            var data = Db.District.Select(x => x);
            return data;
        }
        public District GetById(int id)
        {
            var data = Db.District.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
    }
}
