using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Abstract
{
    public interface IOrderDetailService
    {
        Task<bool> AddOrderDetailAsync(OrderDetail orderDetail);

        Task<bool> DeleteOrderDetailAsync(OrderDetail orderDetail);

        Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail);

        Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync();

        Task<OrderDetail> GetOrderDetailById(int id);
    }
}
