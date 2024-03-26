using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SaveLater.Application.Functions.Events.Queries.GetEvent
{
    public class GetEventQuery : IRequest<EventViewModel>
    {
        public int Id { get; set; }
    }
}
