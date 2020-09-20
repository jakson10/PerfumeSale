using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Abstract;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Concrete.EntityFrameworkCore
{
    public class EfBrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public EfBrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> AddBrandAsync(Brand brand)
        {
            await _brandRepository.Add(brand);
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> DeleteBrandAsync(Brand brand)
        {
            await _brandRepository.Delete(brand);
            return await Task.FromResult<bool>(true);
        }

        public async Task<Brand> GetBrandById(int id)
        {
            var entity = _brandRepository.Get(id);
            return await Task.FromResult(entity).Result;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            var list = _brandRepository.GetAll();
            return await Task.FromResult(list.AsEnumerable());
        }

        public async Task<bool> UpdateBrandAsync(Brand brand)
        {
            await _brandRepository.Edit(brand);
            return await Task.FromResult<bool>(true);
        }
    }
}


