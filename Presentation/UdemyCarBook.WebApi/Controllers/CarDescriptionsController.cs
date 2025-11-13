using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionsController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet]
		public async Task<IActionResult> CarDescriptionList()
		{
			var values = await _mediator.Send(new GetCarDescriptionQuery());
			return Ok(values);
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetCarDescription(int id)
		{
			var value = await _mediator.Send(new GetCarDescriptionByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCarDescription(CreateCarDescriptionCommand command)
		{
			await _mediator.Send(command);
			return Ok("Araç Açıklaması Eklendi");
		}


		[HttpDelete]
		public async Task<IActionResult> RemoveCarDescription(int id)
		{
			await _mediator.Send(new RemoveCarDescriptionCommand(id));
			return Ok("Araç Açıklaması Silindi");
		}


		[HttpPut]
		public async Task<IActionResult> UpdateCarDescription(UpdateCarDescriptionCommand command)
		{
			await _mediator.Send(command);
			return Ok("Araç Açıklaması Güncellendi");
		}


		[HttpGet("GetCarDescriptionByCarId")]
		public async Task<IActionResult> GetCarDescriptionByCarId(int id)
		{
			var value = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			return Ok(value);
		}
	}
}
