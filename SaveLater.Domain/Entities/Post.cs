using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveLater.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public int Rate { get; set; }


    }
}
