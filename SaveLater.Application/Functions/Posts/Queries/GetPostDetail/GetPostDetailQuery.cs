﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SaveLater.Application.Functions.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQuery : IRequest<PostDetailViewModel>
    {
        public int Id { get; set; }
    }
}
