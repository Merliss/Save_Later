using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SaveLater.Application.Functions.Posts.Queries.GetPostsList
{
    public class GetPostsListQuery : IRequest<List<PostInListViewModel>>
    {


    }
}
