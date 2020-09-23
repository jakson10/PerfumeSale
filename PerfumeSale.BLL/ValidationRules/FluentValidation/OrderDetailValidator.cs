using FluentValidation;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.BLL.ValidationRules.FluentValidation
{

    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            RuleFor(x => x.Price).NotNull().WithMessage("Fiyat boş geçilemez");
            RuleFor(x => x.Count).NotNull().WithMessage("Adet boş geçilemez");
        }
    }
}
