using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
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
        //[EnableQuery]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return Ok(await _brandService.GetBrandsAsync());
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<Brand>> GetBrandById(int id)
        {
            return Ok(await _brandService.GetBrandByIdAsync(id));
        }



        [HttpGet("[action]/{brandName}")]
        [EnableQuery]
        public async Task<ActionResult<Brand>> GetBrandByBrandName(string brandName)
        {
            var entity = await _brandService.GetBrandByBrandNameAsync(brandName);
            if (entity != null)
            {
                return BadRequest("Null entity");
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostBrand(Brand brand)
        {
            await _brandService.AddBrandAsync(brand);
            return Created("", brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            if (id != brand.BrandId)
                return BadRequest("geçersiz id");

            var updateBrand = await _brandService.GetBrandByIdAsync(brand.BrandId);
            updateBrand.BrandName = brand.BrandName;
            updateBrand.Description = brand.Description;
            await _brandService.UpdateBrandAsync(updateBrand);
            return Created("", updateBrand);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteBrandAsync(await _brandService.GetBrandByIdAsync(id));
            return NoContent();
        }
    }
}
