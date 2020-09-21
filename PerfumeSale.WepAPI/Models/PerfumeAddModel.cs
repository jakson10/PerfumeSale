using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfumeSale.WepAPI.Models
{
    public class PerfumeAddModel
    {
        public string PerfumeName { get; set; }
        public int BrandId { get; set; }
        public double Price { get; set; }
        public string PhotoPath { get; set; }

        public IFormFile Image { get; set; }
    }
}
