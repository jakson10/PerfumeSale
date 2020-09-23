using PerfumeSale.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Abstract
{
    public interface IUserDetailService
    {
        Task<bool> AddUserDetailAsync(UserDetail userDetail);

        Task<bool> DeleteUserDetailAsync(UserDetail userDetail);

        Task<bool> UpdateUserDetailAsync(UserDetail userDetail);

        Task<IEnumerable<UserDetail>> GetUserDetailsAsync();

        Task<UserDetail> GetUserDetailByIdAsync(int id);

        Task<UserDetail> SignInAsync(string firstName, string lastName);

        Task<UserDetail> GetUserDetailByUserNameAsync(string userName);
    }
}
