using BP.Api.Models;
using FluentValidation;

namespace BP.Api.Validations
{
    public class ContactValidator:AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.FullName).NotEmpty().WithMessage("isim soy isim giriniz");
            RuleFor(x => x.Id).LessThan(100).WithMessage("id 100 den fazla olamaz");

        }
    }
}
