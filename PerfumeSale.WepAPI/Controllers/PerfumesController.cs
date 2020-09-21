using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Entities;
using PerfumeSale.WepAPI.Models;

namespace PerfumeSale.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumesController : BaseController
    {
        private readonly IPerfumeService _perfumeService;
        private readonly IMapper _mapper;
        public PerfumesController(IPerfumeService perfumeService, IMapper mapper)
        {
            _perfumeService = perfumeService;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Perfume>>> GetPerfumes()
        {
            return Ok(await _perfumeService.GetPerfumesAsync());
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<Perfume>> GetPerfumeById(int id)
        {
            return Ok(await _perfumeService.GetPerfumeById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostPerfume([FromForm] PerfumeAddModel perfume)
        {
            var uploadModel = await UploadFileAsync(perfume.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                perfume.PhotoPath = uploadModel.NewName;
                await _perfumeService.AddPerfumeAsync(_mapper.Map<Perfume>(perfume));
                return Created("", perfume);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                perfume.PhotoPath = "default.jpg";
                await _perfumeService.AddPerfumeAsync(_mapper.Map<Perfume>(perfume));
                return Created("", perfume);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfume(int id, [FromForm] PerfumeUpdateModel perfume)
        {
            if (id != perfume.PerfumeId)
                return BadRequest("geçersiz id");

            var uploadModel = await UploadFileAsync(perfume.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                var updatePerfume = await _perfumeService.GetPerfumeById(perfume.PerfumeId);
                updatePerfume.PerfumeName = perfume.PerfumeName;
                updatePerfume.Price = perfume.Price;
                updatePerfume.PhotoPath = uploadModel.NewName;

                await _perfumeService.UpdatePerfumeAsync(updatePerfume);
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var updatePerfume = await _perfumeService.GetPerfumeById(perfume.PerfumeId);
                updatePerfume.PerfumeName = perfume.PerfumeName;
                updatePerfume.Price = perfume.Price;

                await _perfumeService.UpdatePerfumeAsync(updatePerfume);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfume(int id)
        {
            await _perfumeService.DeletePerfumeAsync(await _perfumeService.GetPerfumeById(id));
            return NoContent();
        }
    }
}
