using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaveLater.Application.Contracts.Persistence;

namespace SaveLater.Application.Functions.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Unit>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IEventsRepository eventsRepository, IMapper mapper)
        {
            _eventsRepository = eventsRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventsRepository.GetByIdAsync(request.Id);

            await _eventsRepository.DeleteAsync(eventToDelete);

            return Unit.Value;
        }
    }
}
