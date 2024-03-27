using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Application.Functions.Categories.Commands;
using SaveLater.Application.Functions.Events.Commands.CreateEvent;
using SaveLater.Application.Mapper;
using SaveLater.Application.UnitTest.Mocks;
using Shouldly;

namespace SaveLater.Application.UnitTest.Events.Commands
{
    public class CreateEventsTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEventsRepository> _mockEventsRepository;

        public CreateEventsTest()
        {
            _mockEventsRepository = RepositoryMocks.GetEventRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidEvent_AddedToEventRepo()
        {
            var handler = new CreateEventCommandHandler(_mockEventsRepository.Object, _mapper);
            
            var allEventsBeforeCount = (await _mockEventsRepository.Object.GetAllAsync()).Count;

            var command = new CreateEventCommand()
            {
                ImageUrl = "Jak",
                Title = "TittleTitle",
                FacebookEventUrl = "JsonJsonSjon",
                Date = DateTime.Now.AddDays(-10)


            };

            var response = await handler.Handle(command, CancellationToken.None);
            var allEvents = await _mockEventsRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allEvents.Count.ShouldBe(allEventsBeforeCount + 1);
            response.Id.ShouldNotBeNull();
        }


    }
}
