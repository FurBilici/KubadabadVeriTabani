using Kubadabad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kubadabad.DataAccess.Repository.IRepository
{
    public interface IRaporRepository : IRepository<AçmaRapor>
    {
        void Update(AçmaRapor obj);
    }
}
