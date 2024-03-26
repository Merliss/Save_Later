using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaveLater.Application.Contracts.Persistence;

namespace SaveLater.Application.Functions.Events.Queries.GetEventListByDate
{
    public class GetEventsByDateQueryHandler : IRequestHandler<GetEventsByDateQuery, PageEventByDateViewModel>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IMapper _mapper;


        public GetEventsByDateQueryHandler(IEventsRepository eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }
        public async Task<PageEventByDateViewModel> Handle(GetEventsByDateQuery request, CancellationToken cancellationToken)
        {
            var list = await _eventsRepository.GetPagedEventsForDate(request.Options, request.Page, request.PageSize, request.Date);

            var events = _mapper.Map<List<EventsByDateViewModel>>(list);
            var count = await _eventsRepository.GetTotalCountOfEventsForDate(request.Options, request.Date);

            return new PageEventByDateViewModel()
            {
                AllCount = count,
                Events = events,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
