using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using SaveLater.Application.Responses;

namespace SaveLater.Application.Functions.Categories.Commands
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public int? CategoryId { get; set; }

        public CreateCategoryCommandResponse() : base()
        {
            
        }

        public CreateCategoryCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
            
        }

        public CreateCategoryCommandResponse(string message) : base(message)
        {
            
        }

        public CreateCategoryCommandResponse(string message, bool success) : base(message, success)
        {
            
        }

        public CreateCategoryCommandResponse(int categoryId)
        {
            CategoryId = categoryId;
        }

    }
}
