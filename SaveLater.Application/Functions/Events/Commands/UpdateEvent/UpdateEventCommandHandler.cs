using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Functions.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Unit>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventsRepository eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = _mapper.Map<Event>(request);

            await _eventsRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}
