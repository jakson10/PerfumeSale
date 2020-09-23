using Microsoft.EntityFrameworkCore;
using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Abstract;
using PerfumeSale.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Concrete.EntityFrameworkCore
{
    public class EfUserDetailService : IUserDetailService
    {
        private readonly IUserDetailRepository _userDetailRepository;
        public EfUserDetailService(IUserDetailRepository userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }
        public async Task<bool> AddUserDetailAsync(UserDetail userDetail)
        {
            await _userDetailRepository.Add(userDetail);
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> DeleteUserDetailAsync(UserDetail userDetail)
        {
            await _userDetailRepository.Delete(userDetail);
            return await Task.FromResult<bool>(true);
        }

        public async Task<UserDetail> GetUserDetailByIdAsync(int id)
        {
            var entity = _userDetailRepository.Get(id);
            return await Task.FromResult(entity).Result;
        }

        public async Task<UserDetail> GetUserDetailByUserNameAsync(string userName)
        {
            var entity = await _userDetailRepository.Find(x => x.UserName == userName).FirstOrDefaultAsync();
            return await Task.FromResult(entity);
        }


        public async Task<UserDetail> SignInAsync(string firstName, string lastName)
        {
            var entity = await _userDetailRepository.Find(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefaultAsync();
            return await Task.FromResult(entity);
        }

        public async Task<IEnumerable<UserDetail>> GetUserDetailsAsync()
        {
            var list = _userDetailRepository.GetAll();
            return await Task.FromResult(list.AsEnumerable());

        }

        public async Task<bool> UpdateUserDetailAsync(UserDetail userDetail)
        {
            await _userDetailRepository.Edit(userDetail);
            return await Task.FromResult<bool>(true);
        }

    }
}
