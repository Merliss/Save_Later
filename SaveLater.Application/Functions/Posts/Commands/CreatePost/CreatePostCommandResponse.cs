using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using SaveLater.Application.Responses;

namespace SaveLater.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatePostCommandResponse : BaseResponse
    {
        public int? PostId { get; set; }

        public CreatePostCommandResponse() : base()
        {
            
        }

        public CreatePostCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
            
        }

        public CreatePostCommandResponse(string message) : base(message)
        {

        }

        public CreatePostCommandResponse(string message,bool success) : base(message, success)
        {
            
        }

        public CreatePostCommandResponse(int postId)
        {
            PostId = postId;
        }



    }
}
