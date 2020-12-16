using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Entities.Dto;

namespace TravelGuide.Business.Validation
{
    public class RegisterValidator:AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Name).NotNull().Length(2,100).WithMessage("İsim alanı boş geçielemez");
            RuleFor(r => r.Surname).NotNull().Length(2, 100).WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(r => r.Username).NotNull().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(r => r.Password).NotNull().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(r => r.RePassword).NotNull().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(r => r.Password).Equal(r => r.RePassword).WithMessage("Şifreler uyuşmuyor");
            RuleFor(r => r.Email).NotNull().EmailAddress().WithMessage("Geçerli bir mail girin");
        }
    }
}
