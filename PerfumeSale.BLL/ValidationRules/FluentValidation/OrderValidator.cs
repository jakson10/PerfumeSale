using FluentValidation;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.BLL.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.ShipAddress).NotNull().WithMessage("Teslimat adresi boş geçilemez");
            RuleFor(x => x.Phone).NotNull().WithMessage("Telefon numarası boş geçilemez");
        }
    }
}
