using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.PhoneRepository.Validation
{
    public class PhoneValidator:AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(p => p.Number).NotEmpty().WithMessage("Number cannot be empty");
            RuleFor(p => p.PersonId).NotEmpty().WithMessage("PersonId cannot be empty");
        }
    }
}