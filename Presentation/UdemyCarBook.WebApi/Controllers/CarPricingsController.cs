using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.VitesCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.VitesQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetCarPricingWithCarList")]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }


		[HttpGet("GetCarPricingWithTimePeriod")]
		public async Task<IActionResult> GetCarPricingWithTimePeriod()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(values);
		}


        [HttpGet("GetCarPricingByCarIdToPricingName")]
        public async Task<IActionResult> GetCarPricingByCarIdToPricingName(int id)
        {
            var values = await _mediator.Send(new GetCarPricingByCarIdToPricingNameQuery(id));
            return Ok(values);
        }


        [HttpGet("GetCarPricingByCarIdToDaily")]
        public async Task<IActionResult> GetCarPricingByCarIdToDaily(int id)
        {
            var values = await _mediator.Send(new GetCarPricingByCarIdToDailyQuery(id));
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> CarPricingList()
        {
            var values = await _mediator.Send(new GetCarPricingQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarPricing(int id)
        {
            var value = await _mediator.Send(new GetCarPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kiralama Türü Eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveCarPricing(int id)
        {
            await _mediator.Send(new RemoveCarPricingCommand(id));
            return Ok("Kiralama Türü Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kiralama Türü Güncellendi");
        }
    }
}
