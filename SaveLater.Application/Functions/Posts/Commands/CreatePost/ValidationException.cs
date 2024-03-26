using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace SaveLater.Application.Functions.Posts.Commands.CreatePost
{
    public class ValidationException : ApplicationException
    {
        public List<string> ErrorMessages { get; set; }

        public ValidationException(ValidationResult validationResult)

        {
            ErrorMessages = new List<string>();
            
            foreach (var item in validationResult.Errors)
            {
                ErrorMessages.Add(item.ErrorMessage);
            }
        }
    }
}
