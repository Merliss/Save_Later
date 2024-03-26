using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SaveLater.Application.Functions.Categories.Commands
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .MinimumLength(2).MaximumLength(20)
                .WithMessage("{PropertyName} length must be between 2 and 20");

            RuleFor(c => c.DisplayName)
                .MinimumLength(2).MaximumLength(20)
                .WithMessage("{PropertyName} length must be between 2 and 20");
        }
    }
}
