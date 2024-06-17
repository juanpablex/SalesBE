using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.ProductRepository.Validation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(p => p.BrandId).NotEmpty().WithMessage("BrandId cannot be empty");
            RuleFor(p => p.ModelId).NotEmpty().WithMessage("ModelId cannot be empty");
            RuleFor(p => p.ColorId).NotEmpty().WithMessage("ColorId cannot be empty");
            RuleFor(p => p.Chasis).NotEmpty().WithMessage("Chasis cannot be empty");
        }
    }
}