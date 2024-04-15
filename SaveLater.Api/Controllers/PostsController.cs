using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaveLater.Application.Functions.Posts.Commands.CreatePost;
using SaveLater.Application.Functions.Posts.Commands.DeletePost;
using SaveLater.Application.Functions.Posts.Commands.UpdatePost;
using SaveLater.Application.Functions.Posts.Queries.GetPostDetail;
using SaveLater.Application.Functions.Posts.Queries.GetPostsList;

namespace SaveLater.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPosts")]
        public async Task<ActionResult<List<PostInListViewModel>>> GetAllPosts()
        {
            var list = await _mediator.Send(new GetPostsListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PostDetailViewModel>> GetPostById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetPostDetailQuery() { Id = id});
            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<int>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            var result = await _mediator.Send(createPostCommand);
            return Ok(result.PostId);
        }

        [HttpPut(Name = "UpdatePost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return Ok();
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deletePostCommand = new DeletePostCommand() { PostId = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }

    }
}
