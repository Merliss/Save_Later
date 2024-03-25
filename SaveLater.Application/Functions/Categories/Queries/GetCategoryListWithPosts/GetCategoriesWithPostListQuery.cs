using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SaveLater.Application.Functions.Categories.Queries.GetCategoryListWithPosts
{
    public class GetCategoriesWithPostListQuery : IRequest<List<CategoryPostListViewModel>>
    {
        public SearchCategoryOptions searchCategory { get; set; }
    }
}
