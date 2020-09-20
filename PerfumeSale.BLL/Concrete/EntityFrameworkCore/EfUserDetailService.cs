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

        public async Task<UserDetail> GetUserDetailById(int id)
        {
            var entity = _userDetailRepository.Get(id);
            return await Task.FromResult(entity).Result;

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
