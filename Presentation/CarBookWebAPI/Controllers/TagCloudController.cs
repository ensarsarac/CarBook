using Application.Mediator.Commands.TagCloudCommands;
using Application.Mediator.Queries.TagCloudQueries;
using Application.Mediator.Results.TagCloudResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetTagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQueryResult());
            return Ok(values);
        }
        [HttpGet("GetTagCloudListByIdWithBlog")]
        public async Task<IActionResult> GetTagCloudListByIdWithBlog(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdWithBlogQuery(id));
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudById(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand createTagCloudCommands)
        {
            await _mediator.Send(createTagCloudCommands);
            return Ok("Kayıt eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(RemoveTagCloudCommand removeTagCloudCommands)
        {
            await _mediator.Send(removeTagCloudCommands);
            return Ok("Kayıt silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand updateTagCloudCommands)
        {
            await _mediator.Send(updateTagCloudCommands);
            return Ok("Kayıt güncellendi");
        }
    }
}
