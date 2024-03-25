﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Domain.Entities;

namespace SaveLater.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);

            post = await _postRepository.AddAsync(post);

            return post.Id;
        }
    }
}
