using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SaveLater.Application.Contracts.Persistence;

namespace SaveLater.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatedPostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        private readonly IPostRepository _postRepository;
        public CreatedPostCommandValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;

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


            RuleFor(p => p)
                .MustAsync(IsNameAndAuthorAlreadyExist)
                .WithMessage("Post with the same Title and Author already exist");

        }

        private async Task<bool> IsNameAndAuthorAlreadyExist(CreatePostCommand e, CancellationToken cancellationToken)
        {
            var check = await _postRepository.IsNameAndAuthorAlreadyExist(e.Title, e.Author);
            return !check;
        }

    }
}
