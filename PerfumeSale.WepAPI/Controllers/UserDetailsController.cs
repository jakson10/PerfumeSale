using System.Threading.Tasks;
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

        [HttpGet("[action]/{firstName}/{lastName}")]
        public async Task<IActionResult> SignIn(string firstName, string lastName)
        {
            var user = await _userDetailService.SignInAsync(firstName, lastName);
            if (user == null)
            {
                return BadRequest("Böyle bir kullanıcı mevcut değil");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostBrand(UserDetail userDetail)
        {
            await _userDetailService.AddUserDetailAsync(userDetail);
            return Created("", userDetail);
        }


    }
}
