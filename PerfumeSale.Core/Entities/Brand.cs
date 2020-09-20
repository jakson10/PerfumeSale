using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Perfume> Perfumes { get; set; }
    }
}
