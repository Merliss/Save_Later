using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveLater.Application.Functions.Categories.Queries.GetCategoryListWithPosts
{
    public class CategoryPostListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ICollection<CategoryPostDto> Posts { get; set; }
    }
}
