using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Functions.Events.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventViewModel>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<EventViewModel> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var singleEvent = await _eventRepository.GetByIdAsync(request.Id);
            var singleEventDto = _mapper.Map<EventViewModel>(singleEvent);

            return singleEventDto;

        }
    }
}
