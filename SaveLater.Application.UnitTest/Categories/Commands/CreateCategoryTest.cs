using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Application.Functions.Categories.Commands;
using SaveLater.Application.Mapper;
using SaveLater.Application.UnitTest.Mocks;
using Shouldly;

namespace SaveLater.Application.UnitTest.Categories.Commands
{
    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CreateCategoryTest()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }


        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);

            var allCategoriesBeforeCount = (await _mockCategoryRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreateCategoryCommand()
            {
                Name = "Testowa",
                DisplayName = "Test",

            },CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allCategories.Count.ShouldBe(allCategoriesBeforeCount + 1);
            response.CategoryId.ShouldNotBeNull();



        }

    }
}
