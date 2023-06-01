using Kubadabad.DataAccess.Data;
using Kubadabad.DataAccess.Repository.IRepository;
using Kubadabad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kubadabad.DataAccess.Repository
{
    public class BuluntularRepository : Repository<Buluntular>, IBuluntularRepository
    {
        private ApplicationDbContext _db;
        public BuluntularRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Buluntular obj)
        {
            _db.Buluntulars.Update(obj);
        }
    }
}
