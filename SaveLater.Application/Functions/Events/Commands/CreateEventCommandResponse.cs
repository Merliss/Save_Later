using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using SaveLater.Application.Responses;

namespace SaveLater.Application.Functions.Events.Commands
{
    public class CreateEventCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public CreateEventCommandResponse() : base()
        {
            
        } 
    

        public CreateEventCommandResponse(string message) : base(message)
        {
        }

        public CreateEventCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateEventCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateEventCommandResponse(int eventId)
        {
            Id = eventId;
        }
    }
}
