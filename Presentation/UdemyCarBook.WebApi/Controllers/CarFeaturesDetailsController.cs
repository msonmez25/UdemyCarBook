using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.CarFeatureDetailCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.CarFeatureDetailQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> CarFeatureDetailByCarId(int id)
        {
            var value = await _mediator.Send(new GetCarFeatureDetailByCarIdQuery(id));
            return Ok(value);
        }


        [HttpGet("CarFeatureAvaibleChangeToFalse")]
        public async Task<IActionResult> CarFeatureAvaibleChangeToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvaibleChangeToFalseCommand(id));
            return Ok("Güncelleme Yapıldı.");
        }


        [HttpGet("CarFeatureAvaibleChangeToTrue")]
        public async Task<IActionResult> CarFeatureAvaibleChangeToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvaibleChangeToTrueCommand(id));
            return Ok("Güncelleme Yapıldı.");
        }


        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme Yapıldı.");
        }
    }
}
