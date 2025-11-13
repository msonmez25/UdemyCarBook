using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.CommentQueries;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _mediator.Send(new GetCommentQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Yorum Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum Güncellendi");
        }


        [HttpGet("GetCommettByBlogId")]
        public async Task<IActionResult> GetCommettByBlogId(int id)
        {
            var values = await _mediator.Send(new GetCommetByBlogIdQuery(id));
            return Ok(values);
        }


        [HttpGet("GetCommentsByBlogCategoryName")]
        public async Task<IActionResult> GetCommentsByBlogCategoryName()
        {
            var values = await _mediator.Send(new GetCommentWithBlogNameQuery());
            return Ok(values);
        }


        [HttpGet("CountCommentByBlogId")]
        public async Task<IActionResult> CountCommentByBlogId(int id)
        {
            var value = await _mediator.Send(new GetCountCommentByBlogIdQuery(id));
            return Ok(value);
        }

    }
}
