using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Domain.Entities;

namespace SaveLater.Persistence.EF.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        //private readonly SaveLaterContext _dbContext;
        public PostRepository(SaveLaterContext dbContext) : base(dbContext) 
        {
            
        }
        public Task<bool> IsNameAndAuthorAlreadyExist(string title, string author)
        {
            var matches = _dbContext.Posts.Any(a => a.Title.Equals(title) && a.Author.Equals(author));

            return Task.FromResult(matches);
        }
    }
}
