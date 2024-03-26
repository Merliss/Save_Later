using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SaveLater.Application.Functions.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
