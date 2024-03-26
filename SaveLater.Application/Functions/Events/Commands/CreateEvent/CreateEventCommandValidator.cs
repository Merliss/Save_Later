using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SaveLater.Application.Functions.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(e => e.ImageUrl)
                .NotEmpty()
                .NotNull();
            RuleFor(e => e.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(100);
            RuleFor(e => e.FacebookEventUrl)
                .NotEmpty()
                .NotNull();

            RuleFor(e => e.Date)
                .GreaterThan(DateTime.Now.AddYears(-1));
        }

    }
}
