using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Abstract
{
    public interface IPerfumeService
    {
        Task<bool> AddPerfumeAsync(Perfume perfume);

        Task<bool> DeletePerfumeAsync(Perfume perfume);

        Task<bool> UpdatePerfumeAsync(Perfume perfume);

        Task<IEnumerable<Perfume>> GetPerfumesAsync();

        Task<Perfume> GetPerfumeById(int id);

    }
}

