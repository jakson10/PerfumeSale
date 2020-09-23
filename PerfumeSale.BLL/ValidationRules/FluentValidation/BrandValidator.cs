using FluentValidation;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.BLL.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x=>x.BrandName).NotNull().WithMessage("Marka ismi boş geçilemez");
            RuleFor(x => x.Description).NotNull().WithMessage("Marka açıklaması boş geçilemez");
        }
    }
}
