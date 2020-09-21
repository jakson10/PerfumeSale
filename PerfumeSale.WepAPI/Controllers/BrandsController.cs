using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Entities;

namespace PerfumeSale.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return Ok(await _brandService.GetBrandsAsync());
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {
            return Ok(await _brandService.GetBrandById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostBrand(Brand brand)
        {
            await _brandService.AddBrandAsync(brand);
            return Created("", brand);
        }

        [HttpPut]
        public async Task<IActionResult> PutBrand(Brand brand)
        {
            await _brandService.UpdateBrandAsync(brand);
            return Created("", brand);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteBrandAsync(await _brandService.GetBrandById(id));
            return NoContent();
        }
    }
}
