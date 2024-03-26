using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SaveLater.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatedPostCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(80)
                .WithMessage("{PropertyName} must not exceed 80 characters");

            RuleFor(p => p.Date)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .LessThan(DateTime.Now.AddDays(1));
            RuleFor(p => p.Rate)
                .InclusiveBetween(0, 100)
                .WithMessage("{PropertyName} must be between 0 and 100");

        }

    }
}
