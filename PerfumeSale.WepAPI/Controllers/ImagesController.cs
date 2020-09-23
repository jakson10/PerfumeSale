using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeSale.BLL.Abstract;

namespace PerfumeSale.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IPerfumeService _perfumeService;

        public ImagesController(IPerfumeService perfumeService)
        {
            _perfumeService = perfumeService;

        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPerfumeImageById(int id)
        {
            var entity = await _perfumeService.GetPerfumeByIdAsync(id);
            if (string.IsNullOrWhiteSpace(entity.PhotoPath))
                return NotFound("Resim yok");
            return File($"/img/{entity.PhotoPath}", "image/jpeg");
        }

    }
}
