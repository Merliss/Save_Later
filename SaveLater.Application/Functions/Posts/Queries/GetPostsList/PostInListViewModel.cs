using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveLater.Application.Functions.Posts.Queries.GetPostsList
{
    public class PostInListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }

        public int Rate { get; set; }

    }
}
