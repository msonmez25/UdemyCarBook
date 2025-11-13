using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.VitesQueries;

namespace UdemyCarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDetailsController : ControllerBase
	{

		private readonly IMediator _mediator;

		public CarDetailsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCarDetailByCarId(int id)
		{
			var value = await _mediator.Send(new GetCarDetailByCarIdOuery(id));
			return Ok(value);
		}

        [HttpGet("GetCarInfoByCarId/{id}")]
        public async Task<IActionResult> GetCarInfoByCarId(int id)
        {
            var value = await _mediator.Send(new GetCarInfoByCarIdQuery(id));
            return Ok(value);
        }
    }
}
