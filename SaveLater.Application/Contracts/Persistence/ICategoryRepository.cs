using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Application.Functions.Categories.Queries.GetCategoryListWithPosts;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchCategory);
    }
}
