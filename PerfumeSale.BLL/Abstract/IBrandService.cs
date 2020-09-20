using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Abstract
{
    public interface IBrandService
    {
        Task<bool> AddBrandAsync(Brand brand);

        Task<bool> DeleteBrandAsync(Brand brand);

        Task<bool> UpdateBrandAsync(Brand brand);

        Task<IEnumerable<Brand>> GetBrandsAsync();

        Task<Brand> GetBrandById(int id);
    }
}
