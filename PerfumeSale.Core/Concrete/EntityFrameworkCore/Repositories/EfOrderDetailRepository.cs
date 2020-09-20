using PerfumeSale.Core.Abstract;
using PerfumeSale.Core.Concrete.EntityFrameworkCore.Context;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Repositories
{
    public class EfOrderDetailRepository : EfGenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public EfOrderDetailRepository(PsDatabaseContext context) : base(context)
        {
        }
        public PsDatabaseContext DatabaseContext
        {
            get { return _context as PsDatabaseContext; }
        }
    }
}
