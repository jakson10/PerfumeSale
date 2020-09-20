using PerfumeSale.Core.Abstract;
using PerfumeSale.Core.Concrete.EntityFrameworkCore.Context;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPerfumeRepository : EfGenericRepository<Perfume>, IPerfumeRepository
    {
        public EfPerfumeRepository(PsDatabaseContext context) : base(context)
        {
        }
        public PsDatabaseContext DatabaseContext
        {
            get { return _context as PsDatabaseContext; }
        }
    }
}
