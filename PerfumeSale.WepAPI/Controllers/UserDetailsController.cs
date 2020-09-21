using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Entities;

namespace PerfumeSale.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailService _userDetailService;
        public UserDetailsController(IUserDetailService userDetailService)
        {
           _userDetailService = userDetailService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
            return Ok(await _userDetailService.GetUserDetailsAsync());
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<UserDetail>> GetUserDetailById(int id)
        {
            return Ok(await _userDetailService.GetUserDetailById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostUserDetail(UserDetail userDetail)
        {
            await _userDetailService.AddUserDetailAsync(userDetail);
            return Created("", userDetail);
        }

        [HttpPut]
        public async Task<IActionResult> PutUserDetail(UserDetail userDetail)
        {
            await _userDetailService.UpdateUserDetailAsync(userDetail);
            return Created("", userDetail);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetail(int id)
        {
            await _userDetailService.DeleteUserDetailAsync(await _userDetailService.GetUserDetailById(id));
            return NoContent();
        }
    }
}
