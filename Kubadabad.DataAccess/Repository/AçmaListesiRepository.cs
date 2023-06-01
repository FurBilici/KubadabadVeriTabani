using Kubadabad.DataAccess.Data;
using Kubadabad.DataAccess.Repository.IRepository;
using Kubadabad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kubadabad.DataAccess.Repository
{
    public class AçmaListesiRepository : Repository<AçmaListesi>, IAçmaListesiRepository
    {
        private ApplicationDbContext _db;
        public AçmaListesiRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AçmaListesi obj)
        {
            _db.AçmaListesis.Update(obj);
        }
    }
}
