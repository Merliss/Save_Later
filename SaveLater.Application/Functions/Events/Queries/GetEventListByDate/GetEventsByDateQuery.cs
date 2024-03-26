using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SaveLater.Application.Functions.Events.Queries.GetEventListByDate
{
    public class GetEventsByDateQuery : IRequest<PageEventByDateViewModel>
    {
        public DateTime? Date { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public SearchEventsOptions Options { get; set; }
    }
}
