using FluentValidation;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.BLL.ValidationRules.FluentValidation
{
    public class UserDetailValidator : AbstractValidator<UserDetail>
    {
        public UserDetailValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.FirstName).NotNull().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.LastName).NotNull().WithMessage("Soyisim adı boş geçilemez");
            RuleFor(x => x.Email).NotNull().WithMessage("Mail adı boş geçilemez");
            RuleFor(x => x.Phone).NotNull().WithMessage("Telefon numarası  boş geçilemez");
            RuleFor(x => x.Address).NotNull().WithMessage("Adres  boş geçilemez");
        }
    }
}
