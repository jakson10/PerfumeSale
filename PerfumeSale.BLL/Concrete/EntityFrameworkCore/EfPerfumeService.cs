using Microsoft.EntityFrameworkCore;
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
    public class EfPerfumeService : IPerfumeService
    {
        private readonly IPerfumeRepository _perfumeRepository;
        public EfPerfumeService(IPerfumeRepository perfumeRepository)
        {
            _perfumeRepository = perfumeRepository;
        }
        public async Task<bool> AddPerfumeAsync(Perfume perfume)
        {
            await _perfumeRepository.Add(perfume);
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> DeletePerfumeAsync(Perfume perfume)
        {
            await _perfumeRepository.Delete(perfume);
            return await Task.FromResult<bool>(true);
        }

        public async Task<Perfume> GetPerfumeByIdAsync(int id)
        {
            var entity = _perfumeRepository.Get(id);
            return await Task.FromResult(entity).Result;
        }
        public async Task<Perfume> GetPerfumeByPerfumeNameAsync(string perfumeName)
        {
            var entity = await _perfumeRepository.Find(x => x.PerfumeName == perfumeName).FirstOrDefaultAsync(); 
            return await Task.FromResult(entity);
        }
        
        public async Task<IEnumerable<Perfume>> GetPerfumesAsync()
        {
            var list = _perfumeRepository.GetAll().AsEnumerable();
            return await Task.FromResult(list.AsEnumerable());
        }

        public async Task<bool> UpdatePerfumeAsync(Perfume perfume)
        {
            await _perfumeRepository.Edit(perfume);
            return await Task.FromResult<bool>(true);
        }

    }
}





