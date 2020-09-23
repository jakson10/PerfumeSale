using FluentValidation;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.BLL.ValidationRules.FluentValidation
{
    public class PerfumeValidator:AbstractValidator<Perfume>
    {
        public PerfumeValidator()
        {
            RuleFor(x => x.PerfumeName).NotNull().WithMessage("Parfüm ismi boş geçilemez");
            RuleFor(x => x.Price).NotNull().WithMessage("Parfüm fiyatı boş geçilemez");
        }
    }
}
