using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Abstract
{
    public interface IUserDetailService
    {
        Task<bool> AddUserDetailAsync(UserDetail userDetail);

        Task<bool> DeleteUserDetailAsync(UserDetail userDetail);

        Task<bool> UpdateUserDetailAsync(UserDetail userDetail);

        Task<IEnumerable<UserDetail>> GetUserDetailsAsync();

        Task<UserDetail> GetUserDetailById(int id);
    }
}
