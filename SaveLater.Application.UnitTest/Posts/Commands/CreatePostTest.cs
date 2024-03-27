using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Application.Functions.Posts.Commands.CreatePost;
using SaveLater.Application.Mapper;
using SaveLater.Application.UnitTest.Mocks;
using Shouldly;

namespace SaveLater.Application.UnitTest.Posts.Commands
{
    public class CreatePostTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPostRepository> _mockPostRepository;

        public CreatePostTest()
        {
            _mockPostRepository = RepositoryMocks.GetPostRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidPost_AddedToPostRepository()
        {
            var handler = new CreatePostCommandHandler(_mockPostRepository.Object, _mapper);

            var allPostBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count();

            var command = new CreatePostCommand()
            {
                Title = "Test",
                Date = DateTime.Now.AddDays(-5),
                Rate = 20,
                Author = "Boromir"
            };

            var response = await handler.Handle(command, CancellationToken.None);
            var allPosts = await _mockPostRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allPosts.Count.ShouldBe(allPostBeforeCount + 1);
            response.PostId.ShouldNotBeNull();

        }

        [Fact]
        public async Task Handle_Not_ValidPost_AddedToPostRepository()
        {
            var handler = new CreatePostCommandHandler(_mockPostRepository.Object, _mapper);

            var allPostBeforeCount = (await _mockPostRepository.Object.GetAllAsync()).Count();

            var command = new CreatePostCommand()
            {
                Title =new string('a',101),
                Date = DateTime.Now.AddDays(-5),
                Rate = 20,
                Author = "Boromir"
            };

            var response = await handler.Handle(command, CancellationToken.None);
            var allPosts = await _mockPostRepository.Object.GetAllAsync();

            response.Success.ShouldBe(false);
            response.ValidationErrors.Count.ShouldBe(1);
            allPosts.Count.ShouldBe(allPostBeforeCount);
            response.PostId.ShouldBeNull();

        }

    }
}
