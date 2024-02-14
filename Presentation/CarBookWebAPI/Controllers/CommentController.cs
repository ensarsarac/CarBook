using Application.Interfaces;
using Application.Mediator.Commands.CommentCommands;
using Application.Mediator.Queries.CommentQueries;
using Application.Mediator.Results.CommentResults;
using CarBookDomain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentList()
        {
            var values = await _mediator.Send(new GetCommentListQueryResult());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var values = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCommand(CreateCommentCommand createCommentCommand)
        {
            await _mediator.Send(createCommentCommand);
            return Ok("Kayıt eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCommand(UpdateCommentCommands updateCommentCommands)
        {
            await _mediator.Send(updateCommentCommands);
            return Ok("Kayıt güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> UpdateCommand(RemoveCommentCommand removeCommentCommand)
        {
            await _mediator.Send(removeCommentCommand);
            return Ok("Kayıt silindi");
        }
        [HttpGet("GetCommentListByBlog")]
        public async Task<IActionResult> GetCommentListByBlog(int id)
        {
            var values = await _mediator.Send(new GetCommentByblogQuery(id));
            return Ok(values);
        }
    }
}
