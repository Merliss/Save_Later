using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Functions.Posts
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<PostInListViewModel>>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetPostsListQueryHandler (IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }


        public async Task<List<PostInListViewModel>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            var all = await _postRepository.GetAllAsync();
            var allordered = all.OrderBy(p => p.Created);

            return _mapper.Map<List<PostInListViewModel>>(all);
        }
    }
}
