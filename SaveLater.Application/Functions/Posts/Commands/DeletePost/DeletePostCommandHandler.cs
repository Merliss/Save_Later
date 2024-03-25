using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaveLater.Application.Contracts.Persistence;

namespace SaveLater.Application.Functions.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postToDelete = await _postRepository.GetByIdAsync(request.PostId);

            await _postRepository.DeleteAsync(postToDelete);

            return Unit.Value;
        }
    }
}
