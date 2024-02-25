using Application.Mediator.Queries.AppUserQueries;
using Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignInController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SignInController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Index(GetCheckAppUserQuery query)
		{
			var values = await _mediator.Send(query);
			if(values.IsExist)
			{
				return Created("", JwtTokenGenerator.GenerateToken(values));
			}
			else
			{
				return BadRequest("Kullanıcı adı veya şifre hatalıdır");
			}
		}


	}
}
