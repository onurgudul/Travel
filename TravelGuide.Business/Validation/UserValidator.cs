using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Business.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotNull();
            RuleFor(u => u.Name).Length(2, 100);
            RuleFor(u => u.Surname).NotNull().WithMessage("Soyadı alanı zorunludur");
            RuleFor(u => u.Surname).Length(2, 100);
            RuleFor(u => u.Username).NotNull();
            RuleFor(u => u.Username).Length(2, 100).WithMessage("Kullanıcı adınız 2 ile 100 arasında olmalıdır");
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).NotNull();
        }
    }
}
