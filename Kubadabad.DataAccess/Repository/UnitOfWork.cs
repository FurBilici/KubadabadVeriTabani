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
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IAçmaListesiRepository AçmaListesi { get; private set; }
        public IRaporRepository AçmaRapor { get; private set; }
        public IBuluntularRepository Buluntular { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AçmaListesi = new AçmaListesiRepository(_db);
            AçmaRapor = new RaporRepository(_db);
            Buluntular = new BuluntularRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
